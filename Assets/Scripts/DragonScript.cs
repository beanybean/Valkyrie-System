using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonScript : MonoBehaviour {
    const int TIMER_MAX = 3;
    const float POINTS_RATE = 1;
    const float SPEED_MODIFIER = 0.01f;
    const float ATTACK_SPEED = 1.0f;
    const float DRAGON_HEALTH = 5000.0f;
    const float DOOMSDAY_SPEED = 10.0f;
    const float defaultPhAtk = 100.0f;
    const float defaultMaAtk = 100.0f;
    const float defaultPhDef = 50.0f;
    const float defaultMaDef = 50.0f;
    const float defaultRes = 50.0f;
    const float defaultSpd = 50.0f;
    const Element defaultElement = Element.Water;
    HealthBar healthBar = new HealthBar(DRAGON_HEALTH);
    int timerCount = 0;

    AttackAtt myTailSwipe;
    AttackAtt myFireball;
    AttackAtt myEarthquake;
    AttackAtt myHaze;


    [SerializeField]
    private Text dragonText;

    [SerializeField]
    private Image doomsdayTimer;

    [SerializeField]
    private Image attackTimer;

    DamageModule damageModule = new DamageModule();
    ActionPoints actionPoints = new ActionPoints(0);
    ActionPoints actionPoints2 = new ActionPoints(0);

    GameObject GameController;
    GameObject attributes;

    public void takeDamage(float phDamage, float maDamage)
    {
        float totalDamage = 0;
        totalDamage += damageModule.phDamageReduction(phDamage, damageModule.getAttribute(Attribute.PhysicalDefense));
        totalDamage += damageModule.maDamageReduction(maDamage, damageModule.getAttribute(Attribute.MagicalDefense));
        healthBar.takeDamage(totalDamage);
    }

	// Use this for initialization
	void Start () {
        damageModule.setAttribute(Attribute.PhysicalAttack, defaultPhAtk);
        damageModule.setAttribute(Attribute.MagicalAttack, defaultMaAtk);
        damageModule.setAttribute(Attribute.PhysicalDefense, defaultPhDef);
        damageModule.setAttribute(Attribute.MagicalDefense, defaultMaDef);
        damageModule.setAttribute(Attribute.Resistance, defaultRes);
        damageModule.setAttribute(Attribute.Speed, defaultSpd);
        damageModule.setWeakness(defaultElement);
        GameController = GameObject.Find("GameController");
        attributes = GameObject.Find("CharacterAttributes");
        setTimerColor(doomsdayTimer);
        myTailSwipe = attributes.GetComponent<CharacterAttributes>().getAttackAtt("DragonTailSwipe");
        myFireball = attributes.GetComponent<CharacterAttributes>().getAttackAtt("DragonFireball");
        myEarthquake = attributes.GetComponent<CharacterAttributes>().getAttackAtt("DragonEarthquake");
        myHaze = attributes.GetComponent<CharacterAttributes>().getAttackAtt("DragonHaze");
    }

    // Update is called once per frame
    void Update() {
        dragonText.text = healthBar.getHealth().ToString() + " / " + DRAGON_HEALTH.ToString();
        addPoints();
        if (actionPoints2.isReady())
        {
            tailSwipe();
            actionPoints2.usePoints();
        }
        if (timerCount == TIMER_MAX)
            GameController.GetComponent<GameController>().gameOver();
        else if (actionPoints.isReady())
        {
            ++timerCount;
            if (timerCount < TIMER_MAX)
            {
                powerUp();
                setTimerColor(doomsdayTimer);
            }
        }
	}

    void addPoints()
    {
        float points = POINTS_RATE * DOOMSDAY_SPEED * SPEED_MODIFIER * ATTACK_SPEED;
        actionPoints.addPoints(points);
        actionPoints.getMeter(doomsdayTimer);
        points = POINTS_RATE * (damageModule.getAttribute(Attribute.Speed)) * SPEED_MODIFIER * ATTACK_SPEED;
        actionPoints2.addPoints(points);
        actionPoints2.getMeter(attackTimer);

    }

    void setTimerColor(Image image)
    {
        switch(timerCount)
        {
            case 0:
                image.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
                return;
            case 1:
                image.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
                return;
            case 2:
                image.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                return;
        }
    }

    void powerUp()
    {
        actionPoints.usePoints();
        actionPoints.getMeter(doomsdayTimer);
    }

    void tailSwipe()
    {
        int targetNumber = 1;
        Target[] targets = new Target[targetNumber];
        targets[0] = Target.Aria;
        attackCommand(myTailSwipe, targets, 1);
    }

    void fireball()
    {

    }

    void earthquake()
    {

    }

    void haze()
    {

    }

    void attackCommand(AttackAtt myAttack, Target[] targets, int targetNumber)
    {
        EnemyAttack attack;
        attack.phDamage = damageModule.phAttackDamage(myAttack, 1.0f);
        attack.maDamage = damageModule.maAttackDamage(myAttack, 1.0f);
        attack.targets = new Target[4];
        for (int i = 0; i < targetNumber; ++i)
            attack.targets[i] = targets[i];
        attack.targetNumber = targetNumber;
        GameController.GetComponent<GameController>().EnemyQueue.Enqueue(attack);
    }
}

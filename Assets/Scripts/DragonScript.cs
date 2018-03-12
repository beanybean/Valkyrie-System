using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonScript : MonoBehaviour {
    const int TIMER_MAX = 3;
    const float POINTS_RATE = 1;
    const float SPEED_MODIFIER = 0.01f;
    const float ATTACK_SPEED = 1.0f;
    const float DRAGON_HEALTH = 10000.0f;
    const float defaultPhAtk = 100.0f;
    const float defaultMaAtk = 100.0f;
    const float defaultPhDef = 50.0f;
    const float defaultMaDef = 50.0f;
    const float defaultRes = 50.0f;
    const float defaultSpd = 10.0f;
    const Element defaultElement = Element.Water;
    HealthBar healthBar = new HealthBar(DRAGON_HEALTH);
    int timerCount = 0;

    [SerializeField]
    private Text dragonText;

    [SerializeField]
    private Image doomsdayTimer;
    DamageModule damageModule = new DamageModule();
    ActionPoints actionPoints = new ActionPoints(0);

    GameObject GameController;

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
    }
	
	// Update is called once per frame
	void Update () {
        dragonText.text = healthBar.getHealth().ToString() + " / " + DRAGON_HEALTH.ToString();
        addPoints();
        if (actionPoints.isReady())
        {
            ++timerCount;
            if (timerCount == TIMER_MAX)
                GameController.GetComponent<GameController>().gameOver();
            else
                powerUp();
        }
	}

    void addPoints()
    {
        float points = POINTS_RATE * (damageModule.getAttribute(Attribute.Speed)) * SPEED_MODIFIER * ATTACK_SPEED;
        actionPoints.addPoints(points);
        actionPoints.getMeter(doomsdayTimer);
    }

    void powerUp()
    {
        actionPoints.usePoints();
    }

    void tailWhip()
    {

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

}

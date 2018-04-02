using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FireDirection {AY, XB, XY, XA, NONE };
public enum DragonAttack { TailSwipe, Fireball, Earthquake, SnotBomb, None };

public class DragonScript : MonoBehaviour {
    const int TIMER_MAX = 3;
    const float POINTS_RATE = 1;
    const float SPEED_MODIFIER = 0.01f;
    const float ATTACK_SPEED = 1.0f;
    const float DRAGON_HEALTH = 4000.0f;
    const float DOOMSDAY_SPEED = 10.0f;
    const float defaultPhAtk = 80.0f;
    const float defaultMaAtk = 80.0f;
    const float defaultPhDef = 80.0f;
    const float defaultMaDef = 80.0f;
    const float defaultRes = 50.0f;
    const float defaultSpd = 20.0f;
    const float REACTION_PAUSE = 3000f;
    const float EARTHQUAKE_PAUSE = 500f;
    const Element defaultElement = Element.Water;
    HealthBar healthBar = new HealthBar(DRAGON_HEALTH);
    int timerCount = 0;

    AttackAtt myTailSwipe;
    AttackAtt myFireball;
    AttackAtt myEarthquake;
    AttackAtt mySnotbomb;

    [SerializeField]
    private Text dragonText;

    [SerializeField]
    private Image doomsdayTimer;

    [SerializeField]
    private Image attackTimer;

    [SerializeField]
    private Image health;

    DamageModule damageModule = new DamageModule();
    ActionPoints actionPoints = new ActionPoints(0);
    ActionPoints actionPoints2 = new ActionPoints(0);

    GameObject GameController;
    GameObject attributes;
    GameObject Self;

    DragonAttack nextAttack;

    [SerializeField]
    private AudioClip fireballSound;
    [SerializeField]
    private AudioClip earthquakeSound;
    [SerializeField]
    private AudioClip tailswipeSound;
    [SerializeField]
    private AudioClip snotbombSound;
    [SerializeField]
    private AudioClip hitSound;
    private AudioSource audioSource;

    public Queue counterQueue = new Queue();
    private bool counterBool = false;
    private float counterWindow = 0.8f;

    public void takeDamage(float phDamage, float maDamage)
    {
        float totalDamage = 0;
        totalDamage += damageModule.phDamageReduction(phDamage, damageModule.getAttribute(Attribute.PhysicalDefense));
        totalDamage += damageModule.maDamageReduction(maDamage, damageModule.getAttribute(Attribute.MagicalDefense));
        healthBar.takeDamage(totalDamage, health);
        audioSource.PlayOneShot(hitSound);
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
        Self = GameObject.Find("Dragon");
        myTailSwipe = attributes.GetComponent<CharacterAttributes>().getAttackAtt("DragonTailSwipe");
        myFireball = attributes.GetComponent<CharacterAttributes>().getAttackAtt("DragonFireball");
        myEarthquake = attributes.GetComponent<CharacterAttributes>().getAttackAtt("DragonEarthquake");
        mySnotbomb = attributes.GetComponent<CharacterAttributes>().getAttackAtt("DragonHaze");
        setDoomsdayTimer(doomsdayTimer);
        setHealthBar(Self, health);
        nextAttack = getRandomAttack();
        setPositions();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        dragonText.text = healthBar.getHealthString();
        addPoints();
        counterBool = setCounterBool();
        setCounterColor();
        if (counter())
            cancelAttack();
        if (actionPoints2.isReady() && !gameOver())
        {
            doRandomAttack(nextAttack);
            actionPoints2.usePoints();
            nextAttack = getRandomAttack();
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

    void setPositions()
    {
        Self.transform.position = new Vector2(-5f, -1.7f);
        health.transform.position = new Vector2(Self.transform.position.x + 0f, Self.transform.position.y - 2.4f);
        attackTimer.rectTransform.sizeDelta = new Vector2(0.5f, 2f);
        //attackTimer.transform.position = new Vector2(Self.transform.position.x - 5f, Self.transform.position.y - 0f);
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
        for (int i = 0; i < targetNumber; ++i)
            targets[i] = getRandomTarget();
        attackCommand(myTailSwipe, targets, targetNumber, DragonAttack.TailSwipe);
        audioSource.PlayOneShot(tailswipeSound);
    }

    void fireball()
    {
        int targetNumber = 2;
        Target[] targets = new Target[targetNumber];
        FireDirection direction = getFireDirection();
        switch(direction)
        {
            case FireDirection.AY:
                targets[0] = Target.Aria;
                targets[1] = Target.Yazir;
                break;
            case FireDirection.XA:
                targets[0] = Target.Xaine;
                targets[1] = Target.Aria;
                break;
            case FireDirection.XB:
                targets[0] = Target.Xaine;
                targets[1] = Target.Bayl;
                break;
            case FireDirection.XY:
                targets[0] = Target.Xaine;
                targets[1] = Target.Yazir;
                break;
            default:
                break;
        }
        attackCommand(myFireball, targets, targetNumber, DragonAttack.Fireball);
        audioSource.PlayOneShot(fireballSound);
    }

    void earthquake()
    {
        int targetNumber = getEarthquakeNumber();
        Target[] targets = new Target[targetNumber];
        for (int i = 0; i < targetNumber; ++i)
        {
            targets[i] = getRandomTarget();
        }
        attackCommand(myEarthquake, targets, targetNumber, DragonAttack.Earthquake);
        for (int i = 0; i < targetNumber; ++i)
            audioSource.PlayOneShot(earthquakeSound);
    }

    void snotbomb()
    {
        int targetNumber = 1;
        Target[] targets = new Target[targetNumber];
        for (int i = 0; i < targetNumber; ++i)
            targets[i] = getRandomTarget();
        attackCommand(mySnotbomb, targets, targetNumber, DragonAttack.SnotBomb);
        audioSource.PlayOneShot(snotbombSound);
    }

    void attackCommand(AttackAtt myAttack, Target[] targets, int targetNumber, DragonAttack attackName)
    {
        EnemyAttack attack;
        attack.phDamage = damageModule.phAttackDamage(myAttack, 1.0f);
        attack.maDamage = damageModule.maAttackDamage(myAttack, 1.0f);
        attack.attackName = attackName;
        attack.targetNumber = targetNumber;
        attack.targets = new Target[targetNumber];
        attack.ailment = myAttack.ailment;
        attack.ailChance = myAttack.chance;
        for (int i = 0; i < targetNumber; ++i)
            attack.targets[i] = targets[i];
        GameController.GetComponent<GameController>().EnemyQueue.Enqueue(attack);
    }

    Target getRandomTarget()
    {
        float number = Random.Range(1, 100);
        if (number <= 30)
            return Target.Xaine;
        else if (number > 30 && number <= 55)
            return Target.Yazir;
        else if (number > 55 && number <= 80)
            return Target.Aria;
        else if (number > 80 && number <= 100)
            return Target.Bayl;
        else
            return Target.None;
    }

    public bool gameOver()
    {
        return timerCount == TIMER_MAX;
    }

    public bool win()
    {
        return !healthBar.isAlive();
    }

    void setDoomsdayTimer(Image doomsdayTimer)
    {
        doomsdayTimer.rectTransform.sizeDelta = new Vector2(0.75f * Screen.width, 0.05f * Screen.height);
        setTimerColor(doomsdayTimer);
    }

    void setHealthBar(GameObject Self, Image health)
    {
        Vector2 selfPosition = Self.GetComponent<Transform>().position;
        health.rectTransform.sizeDelta = new Vector2(healthBar.getMaxHealth() / 600f, 0.3f);
        health.transform.position = new Vector2(selfPosition.x + 0f, selfPosition.y - 1.2f);
        health.color = new Color(0, 255, 0, 255);
    }

    FireDirection getFireDirection()
    {
        float number = Random.Range(1, 100);
        if (number <= 25)
            return FireDirection.AY;
        else if (number > 25 && number <= 50)
            return FireDirection.XA;
        else if (number > 50 && number <= 75)
            return FireDirection.XB;
        else if (number > 75 && number <= 100)
            return FireDirection.XY;
        else
            return FireDirection.NONE;
    }

    int getEarthquakeNumber()
    {
        float number = Random.Range(1, 100);
        if (number <= 33)
            return 2;
        else if (number > 33 && number <= 66)
            return 3;
        else if (number > 66 && number <= 90)
            return 4;
        else if (number > 90 && number <= 100)
            return 5;
        else
            return 0;
    }

    void doRandomAttack(DragonAttack attack)
    {
        switch(attack)
        {
            case DragonAttack.TailSwipe:
                tailSwipe();
                return;
            case DragonAttack.Fireball:
                fireball();
                return;
            case DragonAttack.Earthquake:
                earthquake();
                return;
            case DragonAttack.SnotBomb:
                snotbomb();
                return;
            default:
                return;
        }
    }

    DragonAttack getRandomAttack()
    {
        float number = Random.Range(1, 100);
        if (number <= 30)
            return DragonAttack.TailSwipe;
        else if (number > 30 && number <= 60)
            return DragonAttack.Fireball;
        else if (number > 60 && number <= 85)
            return DragonAttack.Earthquake;
        else if (number > 85 && number <= 100)
            return DragonAttack.SnotBomb;
        else
            return DragonAttack.None;
    }

    public DragonAttack getNextAttack()
    {
        attackTimer.transform.position = new Vector2(Self.transform.position.x - 5f, Self.transform.position.y - 0f);
        return nextAttack;
    }

    bool counter()
    {
        if (counterQueue.Count > 0)
        {
            float meterPercent = 0.8f;
            Attack playerAttack = (Attack)counterQueue.Dequeue();
            if (nextAttack == DragonAttack.TailSwipe && playerAttack.hero == Hero.Yazir &&
                playerAttack.action == Action.Special && counterBool)
            {
                return true;
            }
            else if (nextAttack == DragonAttack.Fireball && playerAttack.hero == Hero.Bayl &&
                playerAttack.action == Action.Special && counterBool)
            {
                return true;
            }
            else if (nextAttack == DragonAttack.Earthquake && playerAttack.hero == Hero.Xaine &&
                playerAttack.action == Action.Special && counterBool)
            {
                return true;
            }
            else if (nextAttack == DragonAttack.SnotBomb && playerAttack.hero == Hero.Aria &&
                playerAttack.action == Action.Special && counterBool)
            {
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }

    void cancelAttack()
    {
        actionPoints2.emptyMeter();
        nextAttack = getRandomAttack();
    }

    bool setCounterBool()
    {
        return actionPoints2.getMeter() > counterWindow;
    }

    void setCounterColor()
    {
        if (counterBool)
        {
            attackTimer.color = new Color(255, 0, 0, 255);
        }
        else
        {
            attackTimer.color = new Color(255, 132, 0, 255);
        }
    }

    public void resetAttackTimerPos()
    {
        attackTimer.transform.position = new Vector2(-100, -100);
    }
}
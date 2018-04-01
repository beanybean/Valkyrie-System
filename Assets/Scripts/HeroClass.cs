using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroClass
{
    const float DEFAULT_HEALTH = 1000f;
    DamageModule damageModule = new DamageModule();
    ActionPoints actionPoints = new ActionPoints();
    HealthBar healthBar = new HealthBar(DEFAULT_HEALTH);
    bool GAME_OVER = false;

    const float POINTS_RATE = 1;
    const float SPEED_MODIFIER = 0.01f;
    const float ATTACK_SPEED = 1.0f;
    const float METER_OFFSET_X = 100;
    const float METER_OFFSET_Y = -100;
    float defaultPhAtk = 50f;
    float defaultMaAtk = 50f;
    float defaultPhDef = 50f;
    float defaultMaDef = 50f;
    float defaultRes = 50f;
    float defaultSpd = 50f;
    Element defaultElement = Element.Earth;

    float attackSpeed;

    string CharacterName;

    public HeroClass ()
    {
        damageModule.setAttribute(Attribute.PhysicalAttack, defaultPhAtk);
        damageModule.setAttribute(Attribute.MagicalAttack, defaultMaAtk);
        damageModule.setAttribute(Attribute.PhysicalDefense, defaultPhDef);
        damageModule.setAttribute(Attribute.MagicalDefense, defaultMaDef);
        damageModule.setAttribute(Attribute.Resistance, defaultRes);
        damageModule.setAttribute(Attribute.Speed, defaultSpd);
        damageModule.setWeakness(defaultElement);
        attackSpeed = ATTACK_SPEED;
    }
	
	public HeroClass(float PA, float MA, float PD, float MD, float R, float S, Element E )
    {
        defaultPhAtk = PA;
        defaultMaAtk = MA;
        defaultPhDef = PD;
        defaultMaDef = MD;
        defaultRes = R;
        defaultSpd = S;
        defaultElement = E;
        damageModule.setAttribute(Attribute.PhysicalAttack, PA);
        damageModule.setAttribute(Attribute.MagicalAttack, MA);
        damageModule.setAttribute(Attribute.PhysicalDefense, PD);
        damageModule.setAttribute(Attribute.MagicalDefense, MD);
        damageModule.setAttribute(Attribute.Resistance, R);
        damageModule.setAttribute(Attribute.Speed, S);
        damageModule.setWeakness(E);
        attackSpeed = ATTACK_SPEED;
        
    }

    public void setName(string name)
    {
        CharacterName = name;
    }

    public string getName()
    {
        return CharacterName;
    }

    public void utility(Text newText)
    {
        newText.text = CharacterName + " Utility";
    }

    public void ultimate(Text newText)
    {
        newText.text = CharacterName + " Ultimate";
    }

    public void normal(Text newText)
    {
        newText.text = CharacterName + " Normal";
    }

    public void special(Text newText)
    {
        newText.text = CharacterName + " Special";
    }

    public void setAtkAtt(ref AttackAtt attackName, float atkSpd, float phPercent, float maPercent, float atkPwr, int status, float chance, Ailment ailment)
    {
        //Function to specifically designate the values each hero will have to their individual attacks
        attackName.AtkSpd = atkSpd;
        attackName.phPercent = phPercent;
        attackName.maPercent = maPercent;
        attackName.atkPwr = atkPwr;
        attackName.status = status;
        attackName.chance = chance;
        attackName.ailment = ailment;
    }

    public DamageModule getDamageModule()
    {
        return damageModule;
    }

    public ActionPoints getActionPoints()
    {
        return actionPoints;
    }

    public void addPoints(Image actionMeter, Image health)
    {
        if (!GAME_OVER)
        {
            float points = POINTS_RATE * (damageModule.getAttribute(Attribute.Speed)) * SPEED_MODIFIER * attackSpeed;
            actionPoints.addPoints(points);
            if (actionPoints.isKO() && actionPoints.isReady())
                revive(actionMeter, health);
        }
    }

    public void positionMeter(ref Image actionMeter, Vector2 myPosition)
    {
        actionMeter.rectTransform.position.Set(myPosition.x + METER_OFFSET_X, myPosition.y + METER_OFFSET_Y, 0);
    }

    public void displayUpdates(Text myText, Image actionMeter)
    {
        actionPoints.setHeroColor(actionMeter);
        actionPoints.getMeter(actionMeter);
        myText.text = healthBar.getHealthString();
    }

    public void displayUpdates(Text myText, Image actionMeter, HealthBar healthBar)
    {
        actionPoints.setHeroColor(actionMeter);
        actionPoints.getMeter(actionMeter);
        myText.text = healthBar.getHealthString();
    }

    public void displayDamage(Text myText, float phDamage, float maDamage)
    {
        myText.text = (phDamage + maDamage).ToString() + " damage!";
    }

    public void setAttackSpeed(AttackAtt myAttack)
    {
        attackSpeed = myAttack.AtkSpd;
    }

    public void attackCommand(GameObject GameController, Text myText, Text newText, string attackName, AttackAtt myAttack)
    {
        newText.text = getName() + attackName;
        Attack attack;
        attack.phDamage = getDamageModule().phAttackDamage(myAttack, 1.0f);
        attack.maDamage = getDamageModule().maAttackDamage(myAttack, 1.0f);
        GameController.GetComponent<GameController>().AttackQueue.Enqueue(attack);
        setAttackSpeed(myAttack);
        getActionPoints().usePoints();
    }

    public void takeDamage(Image actionMeter, float phDamage, float maDamage, Image health)
    {
        if (healthBar.isAlive())
        {
            float totalDamage = phDamage + maDamage;
            totalDamage += getDamageModule().phDamageReduction(phDamage, getDamageModule().getAttribute(Attribute.PhysicalDefense));
            totalDamage += getDamageModule().maDamageReduction(maDamage, getDamageModule().getAttribute(Attribute.MagicalDefense));
            healthBar.takeDamage(totalDamage, health);
            if (healthBar.getHealth() == 0)
            {
                actionPoints.KO(actionMeter);
                attackSpeed = 0.5f;
            }
        }
    }

    public bool isAlive()
    {
        return healthBar.isAlive();
    }

    void revive(Image actionMeter, Image health)
    {
        actionPoints.revive(actionMeter);
        healthBar.fill(health);
    }

    public void kill(Image actionMeter, Text myText)
    {
        GAME_OVER = true;
        actionPoints.KO(actionMeter);
        actionPoints.getMeter(actionMeter);
        healthBar.KO();
        myText.text = healthBar.getHealthString();
    }

    public void setUIPosition(GameObject Self, Image actionMeter, ref Text text, Image health)
    {
        setActionBar(Self, actionMeter, text);
        setHealthBar(Self, health);
    }

    public void setHealthBar(GameObject Self, Image health)
    {
        Vector2 selfPosition = Self.GetComponent<Transform>().position;
        health.rectTransform.sizeDelta = new Vector2(healthBar.getMaxHealth() / 600f, 0.3f);
        health.transform.position = new Vector2(selfPosition.x + 0f, selfPosition.y - 1.2f);
        health.color = new Color(0, 255, 0, 255);
    }

    void setActionBar(GameObject Self, Image actionMeter, Text text)
    {
        Vector2 selfPosition = Self.GetComponent<Transform>().position;
        text.transform.position = selfPosition;
        actionMeter.rectTransform.sizeDelta = new Vector2(0.2f, 0.8f);
        actionMeter.transform.position = new Vector2(selfPosition.x + 1.2f, selfPosition.y - 0.8f);
    }

    public bool getChance(float chance)
    {
        float number = Random.Range(1, 100);
        return number < 100 * chance;
    }

    public void restoreStats()
    {
        damageModule.setAttribute(Attribute.PhysicalAttack, defaultPhAtk);
        damageModule.setAttribute(Attribute.MagicalAttack, defaultMaAtk);
        damageModule.setAttribute(Attribute.PhysicalDefense, defaultPhDef);
        damageModule.setAttribute(Attribute.MagicalDefense, defaultMaDef);
        damageModule.setAttribute(Attribute.Resistance, defaultRes);
        damageModule.setAttribute(Attribute.Speed, defaultSpd);
        damageModule.setWeakness(defaultElement);
    }
}
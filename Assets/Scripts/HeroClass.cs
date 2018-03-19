using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroClass
{
    DamageModule damageModule = new DamageModule();
    ActionPoints actionPoints = new ActionPoints();

    const float POINTS_RATE = 1;
    const float SPEED_MODIFIER = 0.01f;
    const float ATTACK_SPEED = 1.0f;
    const float METER_OFFSET_X = 100;
    const float METER_OFFSET_Y = -100;
    const float defaultPhAtk = 50f;
    const float defaultMaAtk = 50f;
    const float defaultPhDef = 50f;
    const float defaultMaDef = 50f;
    const float defaultRes = 50f;
    const float defaultSpd = 50f;
    const Element defaultElement = Element.Earth;

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

    public void addPoints()
    {
        float points = POINTS_RATE * (damageModule.getAttribute(Attribute.Speed)) * SPEED_MODIFIER * attackSpeed;
        actionPoints.addPoints(points);
    }

    public void positionMeter(ref Image actionMeter, Vector2 myPosition)
    {
        actionMeter.rectTransform.position.Set(myPosition.x + METER_OFFSET_X, myPosition.y + METER_OFFSET_Y, 0);
    }

    public void displayUpdates(Text myText, Image actionMeter)
    {
        //myText.text = actionPoints.getPoints().ToString() + " / " + actionPoints.getCap().ToString();
        actionPoints.getMeter(actionMeter);
    }

    public void displayUpdates(Text myText, Image actionMeter, HealthBar healthBar)
    {
        //myText.text = actionPoints.getPoints().ToString() + " / " + actionPoints.getCap().ToString();
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
        //displayDamage(myText, attack.phDamage, attack.maDamage);
        GameController.GetComponent<GameController>().AttackQueue.Enqueue(attack);
        setAttackSpeed(myAttack);
        getActionPoints().usePoints();
    }
}

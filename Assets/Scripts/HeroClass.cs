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

    const float defaultPhAtk = 50f;
    const float defaultMaAtk = 50f;
    const float defaultPhDef = 50f;
    const float defaultMaDef = 50f;
    const float defaultRes = 50f;
    const float defaultSpd = 50f;
    const Element defaultElement = Element.Earth;

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
        float points = POINTS_RATE * (damageModule.getAttribute(Attribute.Speed)) * SPEED_MODIFIER * ATTACK_SPEED;
        actionPoints.addPoints(points);
    }
}

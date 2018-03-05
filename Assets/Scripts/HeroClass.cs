using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroClass{

    DamageModule damageModule = new DamageModule();

    const float defaultPhAtk = 50f;
    const float defaultMaAtk = 50f;
    const float defaultPhDef = 50f;
    const float defaultMaDef = 50f;
    const float defaultRes = 50f;
    const float defaultSpd = 50f;
    const Element defaultElement = Element.Earth;

    string CharacterName;

    AttackAtt myUtility = new AttackAtt();
    AttackAtt myUltimate = new AttackAtt();
    AttackAtt myNormal = new AttackAtt();
    AttackAtt mySpecial = new AttackAtt();

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
        //AttackAtt Utility;
        //setAttackAtt(Utility, damageModule.getAttribute(Attribute.Speed),
            //damageModule.getAttribute());
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

    public void setAtkAtt(AttackAtt attackName, float atkSpd, float phPercent, float maPercent, float atkPwr, int status, float chance, Ailment ailment)
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
}

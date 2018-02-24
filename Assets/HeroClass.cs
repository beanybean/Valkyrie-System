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

    ActionAttributes myUtility = new ActionAttributes();
    ActionAttributes myUltimate = new ActionAttributes();
    ActionAttributes myNormal = new ActionAttributes();
    ActionAttributes mySpecial = new ActionAttributes();

    // Use this for initialization
    public HeroClass () {
        damageModule.setAttribute(Attribute.PhysicalAttack, defaultPhAtk);
        damageModule.setAttribute(Attribute.MagicalAttack, defaultMaAtk);
        damageModule.setAttribute(Attribute.PhysicalDefense, defaultPhDef);
        damageModule.setAttribute(Attribute.MagicalDefense, defaultMaDef);
        damageModule.setAttribute(Attribute.Resistance, defaultRes);
        damageModule.setAttribute(Attribute.Speed, defaultSpd);
        damageModule.setWeakness(defaultElement);
    }
	
	// Update is called once per frame
	void Update () {
		
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
        AttackAtt Utility;
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

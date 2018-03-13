using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AriaScript : MonoBehaviour
{
    const float defaultPhAtk = 50f;
    const float defaultMaAtk = 50f;
    const float defaultPhDef = 50f;
    const float defaultMaDef = 50f;
    const float defaultRes = 50f;
    const float defaultSpd = 50f;
    const Element defaultElement = Element.Wind;
    [SerializeField]
    private Text myText;

    [SerializeField]
    private Image actionMeter;

    HeroClass heroClass = new HeroClass(defaultPhAtk, defaultMaAtk, defaultPhDef,
        defaultMaDef, defaultRes, defaultSpd, defaultElement);

    AttackAtt myUtility;
    AttackAtt myUltimate;
    AttackAtt myNormal;
    AttackAtt mySpecial;

    GameObject attributes;
    GameObject GameController;

    public void Utility(Text newText)
    {
        if (heroClass.getActionPoints().isReady())
            attackCommand(newText, " Utility", myUtility);
    }

    public void Ultimate(Text newText)
    {
        if (heroClass.getActionPoints().isReady())
            attackCommand(newText, " Ultimate", myUltimate);
    }

    public void Normal(Text newText)
    {
        if (heroClass.getActionPoints().isReady())
            attackCommand(newText, " Normal", myNormal);
    }

    public void Special(Text newText)
    {
        if (heroClass.getActionPoints().isReady())
            attackCommand(newText, " Special", mySpecial);
    }

    // Use this for initialization
    void Start ()
    {
        heroClass.setName("Aria");
        attributes = GameObject.Find("CharacterAttributes");
        myUtility = attributes.GetComponent<CharacterAttributes>().getAttackAtt("XaineUtility");
        myUltimate = attributes.GetComponent<CharacterAttributes>().getAttackAtt("AriaUltimate");
        myNormal = attributes.GetComponent<CharacterAttributes>().getAttackAtt("AriaNormal");
        mySpecial = attributes.GetComponent<CharacterAttributes>().getAttackAtt("AriaSpecial");
        GameController = GameObject.Find("GameController");
    }
	
	// Update is called once per frame
	void Update () {
        heroClass.addPoints();
        heroClass.displayUpdates(myText, actionMeter);
	}

    void attackCommand(Text newText, string attackName, AttackAtt myAttack)
    {
        heroClass.attackCommand(GameController, myText, newText, attackName, myAttack);
    }
}

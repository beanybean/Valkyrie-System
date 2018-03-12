using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XaineScript : MonoBehaviour
{
    const float defaultPhAtk = 50f;
    const float defaultMaAtk = 50f;
    const float defaultPhDef = 50f;
    const float defaultMaDef = 50f;
    const float defaultRes = 50f;
    const float defaultSpd = 50f;
    const Element defaultElement = Element.Lightning;
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
    void Start()
    {
        heroClass.setName("Xaine");
        attributes = GameObject.Find("CharacterAttributes");
        /*myUtility = attributes.GetComponent<CharacterAttributes>().getAttackAtt("XaineUtility");
        myUltimate = attributes.GetComponent<CharacterAttributes>().getAttackAtt("XaineUltimate");
        myNormal = attributes.GetComponent<CharacterAttributes>().getAttackAtt("XaineNormal");
        mySpecial = attributes.GetComponent<CharacterAttributes>().getAttackAtt("XaineSpecial");*/
        heroClass.setAtkAtt(ref myUtility, 0.7f, 0.0f, 1.0f, 0.8f, 0, 0.0f, Ailment.NONE);
        heroClass.setAtkAtt(ref myUltimate, 0.8f, 0.5f, 0.5f, 2.0f, 0, 0.0f, Ailment.NONE);
        heroClass.setAtkAtt(ref myNormal, 1.0f, 0.85f, 0.15f, 0.6f, 0, 0.0f, Ailment.NONE);
        heroClass.setAtkAtt(ref mySpecial, 0.9f, 0.1f, 0.9f, 1.0f, 0, 0.0f, Ailment.NONE);
        GameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        heroClass.addPoints();
        heroClass.displayUpdates(myText, actionMeter);
    }

    void attackCommand(Text newText, string attackName, AttackAtt myAttack)
    {
        newText.text = heroClass.getName() + attackName;
        Attack attack;
        attack.phDamage = heroClass.getDamageModule().phAttackDamage(myAttack, 1.0f);
        attack.maDamage = heroClass.getDamageModule().maAttackDamage(myAttack, 1.0f);
        heroClass.displayDamage(myText, attack.phDamage, attack.maDamage);
        GameController.GetComponent<GameController>().AttackQueue.Enqueue(attack);
        heroClass.setAttackSpeed(myAttack);
        heroClass.getActionPoints().usePoints();
    }
}

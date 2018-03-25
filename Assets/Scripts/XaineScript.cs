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
        if (heroClass.getActionPoints().isReady() && heroClass.isAlive())
            attackCommand(newText, " Utility", myUtility);
    }

    public void Ultimate(Text newText)
    {
        if (heroClass.getActionPoints().isReady() && heroClass.isAlive())
            attackCommand(newText, " Ultimate", myUltimate);
    }

    public void Normal(Text newText)
    {
        if (heroClass.getActionPoints().isReady() && heroClass.isAlive())
            attackCommand(newText, " Normal", myNormal);
    }

    public void Special(Text newText)
    {
        if (heroClass.getActionPoints().isReady() && heroClass.isAlive())
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
        heroClass.addPoints(actionMeter);
        heroClass.displayUpdates(myText, actionMeter);
    }

    void attackCommand(Text newText, string attackName, AttackAtt myAttack)
    {
        heroClass.attackCommand(GameController, myText, newText, attackName, myAttack);
    }

    public void takeDamage(float phDamage, float maDamage)
    {
        heroClass.takeDamage(actionMeter, phDamage, maDamage);
    }

    public void kill()
    {
        heroClass.kill(actionMeter, myText);
    }
}

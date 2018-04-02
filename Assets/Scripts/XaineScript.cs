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

    [SerializeField]
    private Image health;

    [SerializeField]
    private Text nextAttack;

    HeroClass heroClass = new HeroClass(defaultPhAtk, defaultMaAtk, defaultPhDef,
        defaultMaDef, defaultRes, defaultSpd, defaultElement);

    AttackAtt myUtility;
    AttackAtt myUltimate;
    AttackAtt myNormal;
    AttackAtt mySpecial;

    GameObject attributes;
    GameObject GameController;
    GameObject Self;
    GameObject PlayerController;

    bool ailed = false;
    float startAil;
    float ailTimer = 1000f;

    bool utility = false;

    [SerializeField]
    private AudioClip utilitySound;
    [SerializeField]
    private AudioClip normalSound;
    [SerializeField]
    private AudioClip specialSound;
    [SerializeField]
    private AudioClip ultimateSound;
    [SerializeField]
    private AudioClip hitSound;
    private AudioSource audioSource;

    public void Utility(Text newText)
    {
        if (heroClass.getActionPoints().isReady() && heroClass.isAlive())
        {
            scryingShield();
            audioSource.PlayOneShot(utilitySound);
            //attackCommand(newText, " Utility", myUtility);
        }
    }

    public void Ultimate(Text newText)
    {
        if (heroClass.getActionPoints().isReady() && heroClass.isAlive())
        {
            attackCommand(newText, " Ultimate", myUltimate);
            audioSource.PlayOneShot(ultimateSound);
        }
    }

    public void Normal(Text newText)
    {
        if (heroClass.getActionPoints().isReady() && heroClass.isAlive())
        {
            attackCommand(newText, " Normal", myNormal);
            audioSource.PlayOneShot(normalSound);
        }
    }

    public void Special(Text newText)
    {
        if (heroClass.getActionPoints().isReady() && heroClass.isAlive())
        {
            attackCommand(newText, " Special", mySpecial);
            audioSource.PlayOneShot(specialSound);
        }
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
        clearNextAttack();

        Self = GameObject.Find("Xaine");
        heroClass.setUIPosition(Self, actionMeter, ref myText, health);
        PlayerController = GameObject.Find("PlayerController");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        heroClass.addPoints(actionMeter, health);
        heroClass.displayUpdates(myText, actionMeter);
        if (ailed)
        {
            if (Time.time - startAil > ailTimer)
            {
                ailed = false;
                heroClass.restoreStats();
            }
        }
        checkUtilityOver();
    }

    void checkUtilityOver()
    {
        if (utility && heroClass.getActionPoints().isReady())
        {
            utility = false;
            clearNextAttack();
        }
    }

    void attackCommand(Text newText, string attackName, AttackAtt myAttack)
    {
        heroClass.attackCommand(GameController, myText, newText, attackName, myAttack);
    }

    public void takeDamage(float phDamage, float maDamage)
    {
        if (heroClass.isAlive())
        {
            heroClass.takeDamage(actionMeter, phDamage, maDamage, health);
            audioSource.PlayOneShot(hitSound);
        }
    }

    public void statusEffect(Ailment ailment, float ailmentChance)
    {
        bool ail = heroClass.getChance(ailmentChance);
        if (ail)
        {
            ailed = true;
            startAil = Time.time;
            setAilment(ailment);
        }
    }

    void setAilment(Ailment ailment)
    {
        switch (ailment)
        {
            case Ailment.mired:
                heroClass.getDamageModule().lowerAttribute(Attribute.Speed, 10);
                return;
            default:
                return;
        }
    }

    public void kill()
    {
        heroClass.kill(actionMeter, myText);
    }

    public void heal()
    {
        heroClass.healHalf(health);
    }

    public HeroClass getHeroClass()
    {
        return heroClass;
    }

    void clearNextAttack()
    {
        nextAttack.text = "";
    }

    void scryingShield()
    {
        utility = true;
        heroClass.getActionPoints().usePoints();
        DragonAttack attack = GameController.GetComponent<GameController>().getNextAttack();
        displayNextAttack(attack);
    }

    void displayNextAttack(DragonAttack attack)
    {
        switch(attack)
        {
            case DragonAttack.TailSwipe:
                nextAttack.text = "Tail Swipe:\nCounter with Earth";
                return;
            case DragonAttack.Fireball:
                nextAttack.text = "Fireball:\nCounter with Water";
                return;
            case DragonAttack.Earthquake:
                nextAttack.text = "Earthquake:\nCounter with Lightning";
                return;
            case DragonAttack.SnotBomb:
                nextAttack.text = "Snot Bomb:\nCounter with Wind";
                return;
            default:
                return;
        }
    }
}

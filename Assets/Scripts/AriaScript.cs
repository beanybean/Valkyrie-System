﻿using System.Collections;
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

    [SerializeField]
    private Image health;

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

    private Hero hero = Hero.Aria;

    Animator anim;
    int attackHash = Animator.StringToHash("Trigger_Attack");

    [SerializeField]
    GameObject utilityPrefab;
    [SerializeField]
    GameObject ultimatePrefab;
    [SerializeField]
    GameObject normalPrefab;
    [SerializeField]
    GameObject specialPrefab;

    GameObject instantiatedUtility;

    public void Utility(Text newText)
    {
        if (heroClass.getActionPoints().isReady() && heroClass.isAlive())
        {
            //Vector3 enemyPosition = GameController.GetComponent<GameController>().getDragonPosition();
            //enemyPosition.z = -1;
            //Vector3 centerPosition = PlayerController.GetComponent<PlayerController>().getCenterPosition();
            //centerPosition.z = -1;
            //Vector3 iconPosition = heroClass.getPosition();
            //iconPosition.x += 1;
            //iconPosition.y += 1;
            //iconPosition.z = -1;
            anim.SetTrigger(attackHash);
            //instantiatedUtility = Instantiate(utilityPrefab, iconPosition, Quaternion.identity);
            PlayerController.GetComponent<PlayerController>().hastingWind(utilityPrefab);
            audioSource.PlayOneShot(utilitySound);
            hastingWind();
        }
    }

    public void Ultimate(Text newText)
    {
        if (heroClass.getActionPoints().isReady() && heroClass.isAlive())
        {
            anim.SetTrigger(attackHash);
            Vector3 iconPosition = GameController.GetComponent<GameController>().getDragonOffset();
            GameObject icon = Instantiate(ultimatePrefab, iconPosition, Quaternion.identity);
            Destroy(icon, 1);
            audioSource.PlayOneShot(ultimateSound);
            attackCommand(newText, " Ultimate", myUltimate, Action.Ultimate);
        }
    }

    public void Normal(Text newText)
    {
        if (heroClass.getActionPoints().isReady() && heroClass.isAlive())
        {
            anim.SetTrigger(attackHash);
            Vector3 iconPosition = GameController.GetComponent<GameController>().getDragonOffset();
            GameObject icon = Instantiate(normalPrefab, iconPosition, Quaternion.identity);
            Destroy(icon, 1);
            audioSource.PlayOneShot(normalSound);
            attackCommand(newText, " Normal", myNormal, Action.Normal);
        }
    }

    public void Special(Text newText)
    {
        if (heroClass.getActionPoints().isReady() && heroClass.isAlive())
        {
            anim.SetTrigger(attackHash);
            Vector3 iconPosition = GameController.GetComponent<GameController>().getDragonOffset();
            GameObject icon = Instantiate(specialPrefab, iconPosition, Quaternion.identity);
            Destroy(icon, 1);
            audioSource.PlayOneShot(specialSound);
            attackCommand(newText, " Special", mySpecial, Action.Special);
        }
    }

    // Use this for initialization
    void Start ()
    {
        heroClass.setName("Aria");
        attributes = GameObject.Find("CharacterAttributes");
        myUtility = attributes.GetComponent<CharacterAttributes>().getAttackAtt("AriaUtility");
        myUltimate = attributes.GetComponent<CharacterAttributes>().getAttackAtt("AriaUltimate");
        myNormal = attributes.GetComponent<CharacterAttributes>().getAttackAtt("AriaNormal");
        mySpecial = attributes.GetComponent<CharacterAttributes>().getAttackAtt("AriaSpecial");
        GameController = GameObject.Find("GameController");

        Self = GameObject.Find("Aria");
        heroClass.setUIPosition(Self, actionMeter, ref myText, health);
        PlayerController = GameObject.Find("PlayerController");
        audioSource = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
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
            PlayerController.GetComponent<PlayerController>().restoreSpeed();
            //Destroy(instantiatedUtility);
            PlayerController.GetComponent<PlayerController>().destroyHastingWind();
        }
    }

    void attackCommand(Text newText, string attackName, AttackAtt myAttack, Action action)
    {
        heroClass.attackCommand(GameController, myText, newText, attackName, myAttack, action, hero);
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

    void hastingWind()
    {
        PlayerController.GetComponent<PlayerController>().raiseSpeed();
        heroClass.getActionPoints().usePoints();
        utility = true;
    }

    public HeroClass getHeroClass()
    {
        return heroClass;
    }
}

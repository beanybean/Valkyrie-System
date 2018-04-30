using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaylScript : MonoBehaviour
{
    const float defaultPhAtk = 50f;
    const float defaultMaAtk = 80f;
    const float defaultPhDef = 50f;
    const float defaultMaDef = 50f;
    const float defaultRes = 50f;
    const float defaultSpd = 50f;
    const Element defaultElement = Element.Water;
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

    private Hero hero = Hero.Bayl;

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

    public void Utility(Text newText)
    {
        if (heroClass.getActionPoints().isReady() && heroClass.isAlive())
        {
            anim.SetTrigger(attackHash);
            PlayerController.GetComponent<PlayerController>().createIcon(utilityPrefab, Icon.HealingWaters);
            audioSource.PlayOneShot(utilitySound);
            healingRain();
        }
    }

    public void Ultimate(Text newText)
    {
        if (heroClass.getActionPoints().isReady() && heroClass.isAlive())
        {
            anim.SetTrigger(attackHash);
            Vector3 iconPosition = GameController.GetComponent<GameController>().getDragonOffset();
            PlayerController.GetComponent<PlayerController>().playEffect(ultimatePrefab, iconPosition, heroClass.getAttackTime());
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
            PlayerController.GetComponent<PlayerController>().playEffect(normalPrefab, iconPosition, heroClass.getAttackTime());
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
            PlayerController.GetComponent<PlayerController>().playEffect(specialPrefab, iconPosition, heroClass.getAttackTime());
            audioSource.PlayOneShot(specialSound);
            attackCommand(newText, " Special", mySpecial, Action.Special);
        }
    }

    // Use this for initialization
    void Start()
    {
        heroClass.setName("Bayl");
        attributes = GameObject.Find("CharacterAttributes");
        myUtility = attributes.GetComponent<CharacterAttributes>().getAttackAtt("BaylUtility");
        myUltimate = attributes.GetComponent<CharacterAttributes>().getAttackAtt("BaylUltimate");
        myNormal = attributes.GetComponent<CharacterAttributes>().getAttackAtt("BaylNormal");
        mySpecial = attributes.GetComponent<CharacterAttributes>().getAttackAtt("BaylSpecial");
        GameController = GameObject.Find("GameController");

        Self = GameObject.Find("Bayl");
        heroClass.setUIPosition(Self, actionMeter, ref myText, health);
        PlayerController = GameObject.Find("PlayerController");
        audioSource = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
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

    public void healingRain()
    {
        PlayerController.GetComponent<PlayerController>().heal();
        heroClass.getActionPoints().usePoints();
    }

    public HeroClass getHeroClass()
    {
        return heroClass;
    }
}
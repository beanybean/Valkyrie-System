using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YazirScript : MonoBehaviour
{
    const float defaultPhAtk = 50f;
    const float defaultMaAtk = 50f;
    const float defaultPhDef = 50f;
    const float defaultMaDef = 50f;
    const float defaultRes = 50f;
    const float defaultSpd = 50f;
    const Element defaultElement = Element.Earth;

    [SerializeField]
    private Text myText;

    [SerializeField]
    private Image actionMeter;

    [SerializeField]
    private Image health;

    HeroClass heroClass = new HeroClass(defaultPhAtk, defaultMaAtk, defaultPhDef,
        defaultMaDef, defaultRes, defaultSpd, defaultElement);

    AttackAtt myUtility = new AttackAtt();
    AttackAtt myUltimate = new AttackAtt();
    AttackAtt myNormal = new AttackAtt();
    AttackAtt mySpecial = new AttackAtt();

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

    private Hero hero = Hero.Yazir;

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
            audioSource.PlayOneShot(utilitySound);
            strength();
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
    void Start()
    {
        heroClass.setName("Yazir");
        attributes = GameObject.Find("CharacterAttributes");
        myUtility = attributes.GetComponent<CharacterAttributes>().getAttackAtt("YazirUtility");
        myUltimate = attributes.GetComponent<CharacterAttributes>().getAttackAtt("YazirUltimate");
        myNormal = attributes.GetComponent<CharacterAttributes>().getAttackAtt("YazirNormal");
        mySpecial = attributes.GetComponent<CharacterAttributes>().getAttackAtt("YazirSpecial");
        GameController = GameObject.Find("GameController");

        Self = GameObject.Find("Yazir");
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
        checkUtilityOver();
    }

    void checkUtilityOver()
    {
        if (utility && heroClass.getActionPoints().isReady())
        {
            utility = false;
            PlayerController.GetComponent<PlayerController>().restoreStrength();
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

    public HeroClass getHeroClass()
    {
        return heroClass;
    }

    void strength()
    {
        PlayerController.GetComponent<PlayerController>().raiseStrength();
        heroClass.getActionPoints().usePoints();
    }
}

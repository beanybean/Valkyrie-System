using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Hero { Aria, Bayl, Xaine, Yazir, Null };
public enum Action { Utility, Ultimate, Normal, Special, Null };
public enum Direction { DOWN, RIGHT, LEFT, UP, DESELECT, NONE };
public enum Icon { HastingWind, HealingWaters, ScryingShield, BerserkerRoar, Selector};

public class PlayerController : MonoBehaviour {
    private Hero heroSelector;
    private Action actionSelector;
    public Text HeroText;
    public CharacterAttributes characterAttributes;
    GameObject GameController;

    GameObject AriaObject;
    GameObject BaylObject;
    GameObject XaineObject;
    GameObject YazirObject;

    Vector2 centerPosition;

    GameObject AriaHaste;
    GameObject BaylHaste;
    GameObject XaineHaste;
    GameObject YazirHaste;

    GameObject AriaRoar;
    GameObject BaylRoar;
    GameObject XaineRoar;
    GameObject YazirRoar;

    [SerializeField]
    GameObject arrowPrefab;
    GameObject arrow;

    void Awake()
    {
        AriaObject = GameObject.Find("Aria");
        BaylObject = GameObject.Find("Bayl");
        XaineObject = GameObject.Find("Xaine");
        YazirObject = GameObject.Find("Yazir");
        GameController = GameObject.Find("GameController");
        centerPosition = new Vector2(3.5f, -1.3f);
        float xOffset = 3f;
        float yOffset = 1.3f;
        Vector2 AriaPosition = new Vector2(centerPosition.x, centerPosition.y - yOffset);
        Vector2 BaylPosition = new Vector2(centerPosition.x + xOffset, centerPosition.y);
        Vector2 XainePosition = new Vector2(centerPosition.x - xOffset, centerPosition.y);
        Vector2 YazirPosition = new Vector2(centerPosition.x, centerPosition.y + yOffset);
        AriaObject.GetComponent<AriaScript>().getHeroClass().setPosition(AriaPosition);
        BaylObject.GetComponent<BaylScript>().getHeroClass().setPosition(BaylPosition);
        XaineObject.GetComponent<XaineScript>().getHeroClass().setPosition(XainePosition);
        YazirObject.GetComponent<YazirScript>().getHeroClass().setPosition(YazirPosition);
        AriaObject.transform.position = AriaPosition;
        BaylObject.transform.position = BaylPosition;
        XaineObject.transform.position = XainePosition;
        YazirObject.transform.position = YazirPosition;
    }

    void Start()
    {
        resetSelectors();
    }

    void Update()
    {
        getInput(HeroText);
    }

    public void getInput(Text DamageText)
    {
        Direction direction = getDirection();
        if (direction == Direction.DESELECT)
        {
            resetSelectors();
            DamageText.text = "";
            return;
        }
        if (heroSelector == Hero.Null)
        {
            heroSelector = selectHero(direction);
            createIcon(arrowPrefab, heroSelector);
        }
        else if (actionSelector == Action.Null)
            actionSelector = selectAction(direction);
        if (heroSelector != Hero.Null && actionSelector != Action.Null)
        {
            Test(HeroText);
            resetSelectors();
        }
    }

    Hero selectHero(Direction direction)
    {
        switch(direction)
        {
            case Direction.DOWN:
                return Hero.Aria;
            case Direction.RIGHT:
                return Hero.Bayl;
            case Direction.LEFT:
                return Hero.Xaine;
            case Direction.UP:
                return Hero.Yazir;
            default:
                return Hero.Null;
        }
    }

    Action selectAction(Direction direction)
    {
        switch(direction)
        {
            case Direction.DOWN:
                return Action.Utility;
            case Direction.RIGHT:
                return Action.Ultimate;
            case Direction.LEFT:
                return Action.Normal;
            case Direction.UP:
                return Action.Special;
            default:
                return Action.Null;
        }
    }

    void resetSelectors()
    {
        heroSelector = Hero.Null;
        actionSelector = Action.Null;
        destroyArrow();
    }

    Direction getDirection()
    {
        if (Input.GetButtonUp("Down"))
            return Direction.DOWN;
        else if (Input.GetButtonUp("Right"))
            return Direction.RIGHT;
        else if (Input.GetButtonUp("Left"))
            return Direction.LEFT;
        else if (Input.GetButtonUp("Up"))
            return Direction.UP;
        else if (Input.GetButtonUp("Deselect"))
            return Direction.DESELECT;
        else
            return Direction.NONE;
    }

    void Test(Text text)
    {
        if (heroSelector == Hero.Aria)
            hero0Action(text);
        else if (heroSelector == Hero.Bayl)
            hero1Action(text);
        else if (heroSelector == Hero.Xaine)
            hero2Action(text);
        else if (heroSelector == Hero.Yazir)
            hero3Action(text);
        else return;
    }

    void hero0Action(Text text)
    {
        if (actionSelector == Action.Null)
            return;
        else if (actionSelector == Action.Utility)
        {
            AriaObject.GetComponent<AriaScript>().Utility(text);
        }
        else if (actionSelector == Action.Ultimate)
        {
            AriaObject.GetComponent<AriaScript>().Ultimate(text);
        }
        else if (actionSelector == Action.Normal)
        {
            AriaObject.GetComponent<AriaScript>().Normal(text);
        }
        else if (actionSelector == Action.Special)
        {
            AriaObject.GetComponent<AriaScript>().Special(text);
        }
        resetSelectors();
    }

    void hero1Action(Text text)
    {
        if (actionSelector == Action.Null)
            return;
        else if (actionSelector == Action.Utility)
        {
            BaylObject.GetComponent<BaylScript>().Utility(text);
        }
        else if (actionSelector == Action.Ultimate)
        {
            BaylObject.GetComponent<BaylScript>().Ultimate(text);
        }
        else if (actionSelector == Action.Normal)
        {
            BaylObject.GetComponent<BaylScript>().Normal(text);
        }
        else if (actionSelector == Action.Special)
        {
            BaylObject.GetComponent<BaylScript>().Special(text);
        }
        resetSelectors();
    }

    void hero2Action(Text text)
    {
        if (actionSelector == Action.Null)
            return;
        else if (actionSelector == Action.Utility)
        {
            XaineObject.GetComponent<XaineScript>().Utility(text);
        }
        else if (actionSelector == Action.Ultimate)
        {
            XaineObject.GetComponent<XaineScript>().Ultimate(text);
        }
        else if (actionSelector == Action.Normal)
        {
            XaineObject.GetComponent<XaineScript>().Normal(text);
        }
        else if (actionSelector == Action.Special)
        {
            XaineObject.GetComponent<XaineScript>().Special(text);
        }
        resetSelectors();
    }

    void hero3Action(Text text)
    {
        if (actionSelector == Action.Null)
            return;
        else if (actionSelector == Action.Utility)
        {
            YazirObject.GetComponent<YazirScript>().Utility(text);
        }
        else if (actionSelector == Action.Ultimate)
        {
            YazirObject.GetComponent<YazirScript>().Ultimate(text);
        }
        else if (actionSelector == Action.Normal)
        {
            YazirObject.GetComponent<YazirScript>().Normal(text);
        }
        else if (actionSelector == Action.Special)
        {
            YazirObject.GetComponent<YazirScript>().Special(text);
        }
        resetSelectors();
    }

    public void attackPlayer(EnemyAttack attack)
    {
        float time = 2f;
        for (int i = 0; i < attack.targetNumber; ++i)
        {
            Vector3 iconPosition = getHeroPosition(attack.targets[i]);
            playEffect(attack.prefab, iconPosition, time);
            attackTarget(attack.targets[i], attack);
        }
    }

    public void attackPlayerWithDelay(EnemyAttack attack)
    {
        float delay = 0.5f;
        float start = Time.time;
        int counter = 0;
        while(true)
        {
            if (counter == attack.targetNumber)
                break;
            if (Time.time - start > delay)
            {
                start = Time.time;
                attackTarget(attack.targets[counter], attack);
                ++counter;
            }
        }
    }

    void attackTarget(Target target, EnemyAttack attack)
    {
        switch(target)
        {
            case Target.Aria:
                AriaObject.GetComponent<AriaScript>().takeDamage(attack.phDamage, attack.maDamage);
                AriaObject.GetComponent<AriaScript>().statusEffect(attack.ailment, attack.ailChance);
                return;
            case Target.Bayl:
                BaylObject.GetComponent<BaylScript>().takeDamage(attack.phDamage, attack.maDamage);
                BaylObject.GetComponent<BaylScript>().statusEffect(attack.ailment, attack.ailChance);
                return;
            case Target.Xaine:
                XaineObject.GetComponent<XaineScript>().takeDamage(attack.phDamage, attack.maDamage);
                XaineObject.GetComponent<XaineScript>().statusEffect(attack.ailment, attack.ailChance);
                return;
            case Target.Yazir:
                YazirObject.GetComponent<YazirScript>().takeDamage(attack.phDamage, attack.maDamage);
                YazirObject.GetComponent<YazirScript>().statusEffect(attack.ailment, attack.ailChance);
                return;
            default:
                return;
        }
    }

    public void killAll()
    {
        AriaObject.GetComponent<AriaScript>().kill();
        BaylObject.GetComponent<BaylScript>().kill();
        XaineObject.GetComponent<XaineScript>().kill();
        YazirObject.GetComponent<YazirScript>().kill();
    }

    public void heal()
    {
        AriaObject.GetComponent<AriaScript>().heal();
        BaylObject.GetComponent<BaylScript>().heal();
        XaineObject.GetComponent<XaineScript>().heal();
        YazirObject.GetComponent<YazirScript>().heal();
    }

    public void raiseSpeed()
    {
        float amount = 20f;
        AriaObject.GetComponent<AriaScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.Speed, amount);
        BaylObject.GetComponent<BaylScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.Speed, amount);
        XaineObject.GetComponent<XaineScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.Speed, amount);
        YazirObject.GetComponent<YazirScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.Speed, amount);
    }

    public void raiseStrength()
    {
        float amount = 20f;
        AriaObject.GetComponent<AriaScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.PhysicalAttack, amount);
        BaylObject.GetComponent<BaylScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.PhysicalAttack, amount);
        XaineObject.GetComponent<XaineScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.PhysicalAttack, amount);
        YazirObject.GetComponent<YazirScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.PhysicalAttack, amount);
    }

    public void restoreSpeed()
    {
        AriaObject.GetComponent<AriaScript>().getHeroClass().restoreSpeed();
        BaylObject.GetComponent<BaylScript>().getHeroClass().restoreSpeed();
        XaineObject.GetComponent<XaineScript>().getHeroClass().restoreSpeed();
        YazirObject.GetComponent<YazirScript>().getHeroClass().restoreSpeed();
    }

    public void restoreStrength()
    {
        AriaObject.GetComponent<AriaScript>().getHeroClass().restoreStrength();
        BaylObject.GetComponent<BaylScript>().getHeroClass().restoreStrength();
        XaineObject.GetComponent<XaineScript>().getHeroClass().restoreStrength();
        YazirObject.GetComponent<YazirScript>().getHeroClass().restoreStrength();
    }

    public Vector2 getCenterPosition()
    {
        return centerPosition;
    }

    public void createIcon(GameObject prefab, Icon type)
    {
        Vector3 offset = getIconOffset(type);
        if (type == Icon.HastingWind)
        {
            hastingWind(prefab, offset);
        }
        else if (type == Icon.HealingWaters)
        {
            healingWaters(prefab, offset);
        }
        else if (type == Icon.ScryingShield)
        {
            scryingShield(prefab, offset);
        }
        else if (type == Icon.BerserkerRoar)
        {
            berserkerRoar(prefab, offset);
        }
    }

    void createIcon(GameObject prefab, Hero hero)
    {
        if (hero == Hero.Null)
            return;
        Vector3 position = heroPosition(hero);
        Vector3 offset = getIconOffset(Icon.Selector);
        arrow = instantiate(prefab, position + offset);
    }

    void destroyArrow()
    {
        Destroy(arrow);
    }

    Vector3 getHeroPosition(Target target)
    {
        switch (target)
        {
            case Target.Aria:
                return heroPosition(Hero.Aria);
            case Target.Bayl:
                return heroPosition(Hero.Bayl);
            case Target.Xaine:
                return heroPosition(Hero.Xaine);
            case Target.Yazir:
                return heroPosition(Hero.Yazir);
            default:
                return new Vector3(0, 0, 0);
        }
    }

    public Vector3 heroPosition(Hero hero)
    {
        switch(hero)
        {
            case Hero.Aria:
                return AriaObject.GetComponent<AriaScript>().getHeroClass().getPosition();
            case Hero.Bayl:
                return BaylObject.GetComponent<BaylScript>().getHeroClass().getPosition();
            case Hero.Xaine:
                return XaineObject.GetComponent<XaineScript>().getHeroClass().getPosition();
            case Hero.Yazir:
                return YazirObject.GetComponent<YazirScript>().getHeroClass().getPosition();
            default:
                return new Vector3(0, 0, 0);
        }
    }

    void hastingWind(GameObject prefab, Vector3 offset)
    {
        Vector3 ariaPosition = heroPosition(Hero.Aria);
        Vector3 baylPosition = heroPosition(Hero.Bayl);
        Vector3 xainePosition = heroPosition(Hero.Xaine);
        Vector3 yazirPosition = heroPosition(Hero.Yazir);
        AriaHaste = instantiate(prefab, ariaPosition + offset);
        BaylHaste = instantiate(prefab, baylPosition + offset);
        XaineHaste = instantiate(prefab, xainePosition + offset);
        YazirHaste = instantiate(prefab, yazirPosition + offset);
    }

    void healingWaters(GameObject prefab, Vector3 offset)
    {
        float time = 2f;
        Vector3 ariaPosition = heroPosition(Hero.Aria);
        Vector3 baylPosition = heroPosition(Hero.Bayl);
        Vector3 xainePosition = heroPosition(Hero.Xaine);
        Vector3 yazirPosition = heroPosition(Hero.Yazir);
        playEffect(prefab, ariaPosition + offset, time);
        playEffect(prefab, baylPosition + offset, time);
        playEffect(prefab, xainePosition + offset, time);
        playEffect(prefab, yazirPosition + offset, time);
    }

    void scryingShield(GameObject prefab, Vector3 offset)
    {
        float time = 3.667f;
        Vector3 dragonPosition = GameController.GetComponent<GameController>().getDragonPosition();
        playEffect(prefab, dragonPosition + offset, time);
    }

    void berserkerRoar(GameObject prefab, Vector3 offset)
    {
        Vector3 ariaPosition = heroPosition(Hero.Aria);
        Vector3 baylPosition = heroPosition(Hero.Bayl);
        Vector3 xainePosition = heroPosition(Hero.Xaine);
        Vector3 yazirPosition = heroPosition(Hero.Yazir);
        AriaRoar = instantiate(prefab, ariaPosition + offset);
        BaylRoar = instantiate(prefab, baylPosition + offset);
        XaineRoar = instantiate(prefab, xainePosition + offset);
        YazirRoar = instantiate(prefab, yazirPosition + offset);
    }

    Vector3 getIconOffset(Icon type)
    {
        float x = 1.8f;
        float ySpacing = 0.7f;
        float z = -1;
        Vector3 offset = new Vector3(0, 0, 0);
        if (type == Icon.HastingWind)
        {
            offset.x = x;
            offset.y += ySpacing;
            offset.z = z;
        }
        else if (type == Icon.HealingWaters)
        {
            offset.x = x;
            offset.y -= ySpacing;
            offset.z = z;
        }
        else if (type == Icon.ScryingShield)
        {
            offset.x = x;
            offset.y = 3;
            offset.z = z;
        }
        else if (type == Icon.BerserkerRoar)
        {
            offset.x = x;
            offset.y = 0;
            offset.z = z;
        }
        else if (type == Icon.Selector)
        {
            offset.x = 0;
            offset.y = 1.5f;
            offset.z = z;
        }
        return offset;
    }

    public void destroyHastingWind()
    {
        Destroy(AriaHaste);
        Destroy(BaylHaste);
        Destroy(XaineHaste);
        Destroy(YazirHaste);
    }

    public void destroyBerserkerRoar()
    {
        Destroy(AriaRoar);
        Destroy(BaylRoar);
        Destroy(XaineRoar);
        Destroy(YazirRoar);
    }

    public GameObject instantiate(GameObject prefab, Vector3 position)
    {
        return Instantiate(prefab, position, Quaternion.identity);
    }

    public void playEffect(GameObject prefab, Vector3 position, float time)
    {
        GameObject myObject = Instantiate(prefab, position, Quaternion.identity);
        Destroy(myObject, time);
    }
}
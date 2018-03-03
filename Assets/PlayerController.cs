using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Hero { Hero0, Hero1, Hero2, Hero3, Null };
public enum Action { Utility, Ultimate, Normal, Special, Null };
public enum Direction { DOWN, RIGHT, LEFT, UP, NONE };

public class PlayerController : MonoBehaviour{
    private Hero heroSelector;
    private Action actionSelector;
    public Text HeroText;

    // hero0 corresponds to Aria
    // hero1 corresponds to Bayl
    // hero2 corresponds to Xaine
    // hero3 corresponds to Yazir

    GameObject AriaObject;
    GameObject BaylObject;
    GameObject XaineObject;
    GameObject YazirObject;
    //AriaScript Aria = GetComponent<AriaScript>();

    void Start()
    {
        resetSelectors();
        AriaObject = GameObject.Find("Aria");
        BaylObject = GameObject.Find("Bayl");
        XaineObject = GameObject.Find("Xaine");
        YazirObject = GameObject.Find("Yazir");
    }

    void Update()
    {
        getInput(HeroText);
    }

    public void getInput(Text DamageText)
    {
        bool cancel = Input.GetButtonUp("Deselect");
        if (cancel)
        {
            resetSelectors();
            DamageText.text = "";
            return;
        }
        if (heroSelector == Hero.Null)
            heroSelector = selectHero(getDirection());
        else if (actionSelector == Action.Null)
            actionSelector = selectAction(getDirection());
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
                return Hero.Hero0;
            case Direction.RIGHT:
                return Hero.Hero1;
            case Direction.LEFT:
                return Hero.Hero2;
            case Direction.UP:
                return Hero.Hero3;
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
        else
            return Direction.NONE;
    }

    void Test(Text text)
    {
        if (heroSelector == Hero.Hero0)
            hero0Action(text);
        else if (heroSelector == Hero.Hero1)
            hero1Action(text);
        else if (heroSelector == Hero.Hero2)
            hero2Action(text);
        else if (heroSelector == Hero.Hero3)
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
}

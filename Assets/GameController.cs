using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Hero {Hero0, Hero1, Hero2, Hero3, Null };
public enum Action { Utility, Ultimate, Normal, Special, Null};
public enum Direction {UP, DOWN, LEFT, RIGHT, NONE };

public struct Attack
{
    float physicalAttack;
    float magicalAttack;
    Action action;
};

public class GameController : MonoBehaviour {


    Hero heroSelector;
    Action actionSelector;

    HeroClass hero0 = new HeroClass(); // Aria
    HeroClass hero1 = new HeroClass(); // Bayl
    HeroClass hero2 = new HeroClass(); // Xain
    HeroClass hero3 = new HeroClass(); // Yazir

    public Text DamageText;

    // Use this for initialization
    void Start () {
        hero0.setName("Aria");
        hero1.setName("Bayl");
        hero2.setName("Xain");
        hero3.setName("Yazir");
        DamageText.text = "Start";
        resetSelectors();
	}
	
	// Update is called once per frame
	void Update () {
        bool cancel = Input.GetButtonUp("Deselect");
        if (cancel)
        {
            resetSelectors();
            DamageText.text = "";
            return;
        }
        Direction direction = getDirection();
        select(direction);
        execute();
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

    void select(Direction direction)
    {
        if (direction == Direction.NONE)
            return;
        else if (heroSelector == Hero.Null)
        {
            switch(direction)
            {
                case Direction.DOWN:
                    heroSelector = Hero.Hero0;
                    return;
                case Direction.RIGHT:
                    heroSelector = Hero.Hero1;
                    return;
                case Direction.LEFT:
                    heroSelector = Hero.Hero2;
                    return;
                case Direction.UP:
                    heroSelector = Hero.Hero3;
                    return;
                default:
                    return;
            }                
        }
        else if (heroSelector != Hero.Null && actionSelector == Action.Null)
        {
            switch (direction)
            {
                case Direction.DOWN:
                    actionSelector = Action.Utility;
                    return;
                case Direction.RIGHT:
                    actionSelector = Action.Ultimate;
                    return;
                case Direction.LEFT:
                    actionSelector = Action.Normal;
                    return;
                case Direction.UP:
                    actionSelector = Action.Special;
                    return;
                default:
                    return;
            }
        }
        else
            return;
    }

    void execute()
    {
        if (heroSelector == Hero.Null || actionSelector == Action.Null)
            return;
        else if (heroSelector == Hero.Hero0)
        {
            doAction(hero0);
        }
        else if (heroSelector == Hero.Hero1)
        {
            doAction(hero1);
        }
        else if (heroSelector == Hero.Hero2)
        {
            doAction(hero2);
        }
        else if (heroSelector == Hero.Hero3)
        {
            doAction(hero3);
        }
        else
            return;
    }

    void doAction(HeroClass hero)
    {
        if (actionSelector == Action.Null)
            return;
        else if (actionSelector == Action.Utility)
        {
            hero.utility(DamageText);
        }
        else if (actionSelector == Action.Ultimate)
        {
            hero.ultimate(DamageText);
        }
        else if (actionSelector == Action.Normal)
        {
            hero.normal(DamageText);
        }
        else if (actionSelector == Action.Special)
        {
            hero.special(DamageText);
        }
        resetSelectors();
    }
}

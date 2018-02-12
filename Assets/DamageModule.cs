using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attribute {PhysicalAttack, MagicalAttack, PhysicalDefense, MagicalDefense, Resistance, Speed };
public enum Element {Wind, Water, Earth, Lightning };
public struct attackAtt
{
    //These are the attributes for a specific attack (Up, Left, Right, Down attacks)
    float AtkSpd; //set value given to a specific attack representative of how fast will the character recharge after the attack: 0.5 - 1.75
    float phPercent; //percentage of attack that is pysical
    float maPercent; //percentage of attack that is magical
    float atkPwr; //set value given to a specific attack representative of the attack's power: 0.6 - 2.8

};

public class DamageModule : MonoBehaviour {

    float PhAtk;
    float MaAtk;
    float PhDef;
    float MaDef;
    float Res;
    float Spd;
    Element weakness;

    

    public void lowerAttribute(Attribute attribute, float amount)
    {
        switch (attribute)
        {
            case Attribute.PhysicalAttack:
                PhAtk -= amount;
                return;
            case Attribute.MagicalAttack:
                MaAtk -= amount;
                return;
            case Attribute.PhysicalDefense:
                PhDef -= amount;
                return;
            case Attribute.MagicalDefense:
                MaDef -= amount;
                return;
            case Attribute.Resistance:
                Res -= amount;
                return;
            case Attribute.Speed:
                Spd -= amount;
                return;
            default:
                return;
        }
    }

    public void raiseAttribute(Attribute attribute, float amount)
    {
        switch (attribute)
        {
            case Attribute.PhysicalAttack:
                PhAtk += amount;
                return;
            case Attribute.MagicalAttack:
                MaAtk += amount;
                return;
            case Attribute.PhysicalDefense:
                PhDef += amount;
                return;
            case Attribute.MagicalDefense:
                MaDef += amount;
                return;
            case Attribute.Resistance:
                Res += amount;
                return;
            case Attribute.Speed:
                Spd += amount;
                return;
            default:
                return;
        }
    }

    public float getAttribute(Attribute attribute)
    {
        switch (attribute)
        {
            case Attribute.PhysicalAttack:
                return PhAtk;
            case Attribute.MagicalAttack:
                return MaAtk;
            case Attribute.PhysicalDefense:
                return PhDef;
            case Attribute.MagicalDefense:
                return MaDef;
            case Attribute.Resistance:
                return Res;
            case Attribute.Speed:
                return Spd;
            default:
                return -1f;
        }
    }

    public void setAttribute(Attribute attribute, float amount)
    {
        switch (attribute)
        {
            case Attribute.PhysicalAttack:
                PhAtk = amount;
                return;
            case Attribute.MagicalAttack:
                MaAtk = amount;
                return;
            case Attribute.PhysicalDefense:
                PhDef = amount;
                return;
            case Attribute.MagicalDefense:
                MaDef = amount;
                return;
            case Attribute.Resistance:
                Res = amount;
                return;
            case Attribute.Speed:
                Spd = amount;
                return;
            default:
                return;
        }
    }

    public void setWeakness(Element element)
    {
        weakness = element;
    }

    public Element getWeakness()
    {
        return weakness;
    }


}

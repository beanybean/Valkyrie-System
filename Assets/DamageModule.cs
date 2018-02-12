using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attribute {PhysicalAttack, MagicalAttack, PhysicalDefense, MagicalDefense, Resistance, Speed };
public enum Element {Wind, Water, Earth, Lightning };

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

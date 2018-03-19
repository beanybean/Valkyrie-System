using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attribute {PhysicalAttack, MagicalAttack, PhysicalDefense, MagicalDefense, Resistance, Speed };
public enum Element {Wind, Water, Earth, Lightning };
public enum Target {Aria, Bayl, Xaine, Yazir, None};

public struct Attack
{
    internal float phDamage;
    internal float maDamage;
}

public struct EnemyAttack
{
    internal float phDamage;
    internal float maDamage;
    internal Target[] targets;
    internal int targetNumber;
}

public class DamageModule
{

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

    public float phAttackDamage(AttackAtt attackName, float affinity)
    {
        float atkPwr = attackName.atkPwr;
        float phPercent = attackName.phPercent;
        float phAtkSqrt = PhAtk * PhAtk;

        float damage = atkPwr * (((phPercent * phAtkSqrt + 70) + 16) / 16);
        damage *= affinity;

        return damage;
    }

    public float maAttackDamage(AttackAtt attackName, float affinity)
    {
        float atkPwr = attackName.atkPwr;
        float maPercent = attackName.maPercent;
        float maAtkSqrt = MaAtk * MaAtk;

        float damage = atkPwr * (((maPercent * maAtkSqrt + 70) + 16) / 16);
        damage *= affinity;

        return damage;
    }

    /*public float phAttackDamage(AttackAtt attackName, float affinity, float phAtk)
    {
        float atkPwr = attackName.atkPwr;
        float phPercent = attackName.phPercent;
        float phAtkSqrt = phAtk * phAtk;

        float damage = atkPwr * (((phPercent * phAtkSqrt + 70) + 16) / 16);
        damage *= affinity;

        return damage;
    }

    public float maAttackDamage(AttackAtt attackName, float affinity, float maAtk)
    {
        float atkPwr = attackName.atkPwr;
        float maPercent = attackName.maPercent;
        float maAtkSqrt = maAtk * maAtk;

        float damage = atkPwr * (((maPercent * maAtkSqrt + 70) + 16) / 16);
        damage *= affinity;

        return damage;
    }*/

    public float phDamageReduction(float phDamage, float phDefense)
    {
        float dmgReduction = (1 - phDefense / 128);
        float damage = phDamage * dmgReduction;

        return damage;
    }

    public float maDamageReduction(float maDamage, float maDefense)
    {
        float dmgReduction = (1 - maDefense / 128);
        float damage = maDamage * dmgReduction;

        return damage;
    }
}

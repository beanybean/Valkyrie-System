using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageModule : MonoBehaviour {

    public float PhAtk;
    public float MaAtk;
    public float PhDef;
    public float MaDef;
    public float Res;
    public float Spd;

    void lowerAttribute(string attribute, float amount)
    {
        if (attribute == "PhAtk")
            PhAtk -= amount;
        else if (attribute == "MaAtk")
            MaAtk -= amount;
        else if (attribute == "PhDef")
            PhDef -= amount;
        else if (attribute == "MaDef")
            MaDef -= amount;
        else if (attribute == "Res")
            Res -= amount;
        else
            Spd -= amount;
    }

    void raiseAttribute(string attribute, float amount)
    {
        if (attribute == "PhAtk")
            PhAtk += amount;
        else if (attribute == "MaAtk")
            MaAtk += amount;
        else if (attribute == "PhDef")
            PhDef += amount;
        else if (attribute == "MaDef")
            MaDef += amount;
        else if (attribute == "Res")
            Res += amount;
        else
            Spd += amount;
    }

    float getAttribute(string attribute)
    {
        if (attribute == "PhAtk")
            return PhAtk;
        else if (attribute == "MaAtk")
            return MaAtk;
        else if (attribute == "PhDef")
            return PhDef;
        else if (attribute == "MaDef")
            return MaDef;
        else if (attribute == "Res")
            return Res;
        else
            return Spd;
    }

    void setAttribute(string attribute, float amount)
    {
        if (attribute == "PhAtk")
            PhAtk = amount;
        else if (attribute == "MaAtk")
            MaAtk = amount;
        else if (attribute == "PhDef")
            PhDef = amount;
        else if (attribute == "MaDef")
            MaDef = amount;
        else if (attribute == "Res")
            Res = amount;
        else
            Spd = amount;
    }
}

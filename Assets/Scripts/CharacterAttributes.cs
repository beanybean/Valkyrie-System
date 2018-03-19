using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Ailment { empower, haste, mired, vulnerable, slow, minor_slow, weaken, NONE };

public struct AttackAtt
{
    //These are the attributes for a specific attack (Up, Left, Right, Down attacks)
    public float AtkSpd; //set value given to a specific attack representative of how fast will the character recharge after the attack: 0.5 - 1.75
    public float phPercent; //percentage of attack that is pysical, range of 0-1
    public float maPercent; //percentage of attack that is magical, range of 0-1
    public float atkPwr; //set value given to a specific attack representative of the attack's power: 0.6 - 2.8
    public int status;//This is used to see if an attack has a status effect or not. 1 is yes, 0 is not
    public float chance; //This number is to see what are the chances of dealing a status ailments
    public Ailment ailment;//what ailment will this attack cause
};

public class CharacterAttributes : MonoBehaviour
{
    AttackAtt AriaUtility;
    AttackAtt AriaUltimate;
    AttackAtt AriaNormal;
    AttackAtt AriaSpecial;

    AttackAtt BaylUtility;
    AttackAtt BaylUltimate;
    AttackAtt BaylNormal;
    AttackAtt BaylSpecial;

    AttackAtt XaineUtility;
    AttackAtt XaineUltimate;
    AttackAtt XaineNormal;
    AttackAtt XaineSpecial;

    AttackAtt YazirUtility;
    AttackAtt YazirUltimate;
    AttackAtt YazirNormal;
    AttackAtt YazirSpecial;

    AttackAtt DragonTailSwipe;
    AttackAtt DragonFireball;
    AttackAtt DragonEarthquake;
    AttackAtt DragonHaze;

    AttackAtt zeroDamage;
    
    void Start()
    {
        setAtkAtt(ref AriaUtility, 0.7f, 0.0f, 1.0f, 0.8f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref AriaUltimate, 0.6f, 0.5f, 0.5f, 2.0f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref AriaNormal, 1.75f, 0.85f, 0.15f, 0.6f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref AriaSpecial, 0.9f, 0.1f, 0.9f, 1.0f, 0, 0.0f, Ailment.NONE);

        setAtkAtt(ref BaylUtility, 0.7f, 0.0f, 1.0f, 0.8f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref BaylUltimate, 0.5f, 0.5f, 0.5f, 2.0f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref BaylNormal, 1.2f, 0.85f, 0.15f, 0.6f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref BaylSpecial, 0.9f, 0.1f, 0.9f, 1.0f, 0, 0.0f, Ailment.NONE);

        setAtkAtt(ref XaineUtility, 0.7f, 0.0f, 1.0f, 0.8f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref XaineUltimate, 0.6f, 0.5f, 0.5f, 2.0f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref XaineNormal, 1.5f, 0.85f, 0.15f, 0.6f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref XaineSpecial, 0.9f, 0.1f, 0.9f, 1.0f, 0, 0.0f, Ailment.NONE);

        setAtkAtt(ref YazirUtility, 0.7f, 0.0f, 1.0f, 0.8f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref YazirUltimate, 0.6f, 0.5f, 0.5f, 2.0f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref YazirNormal, 1.3f, 0.85f, 0.15f, 0.6f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref YazirSpecial, 0.9f, 0.1f, 0.9f, 1.0f, 0, 0.0f, Ailment.NONE);

        setAtkAtt(ref DragonTailSwipe, 0.7f, 0.0f, 1.0f, 0.8f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref DragonFireball, 0.6f, 0.5f, 0.5f, 2.0f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref DragonEarthquake, 1.3f, 0.85f, 0.15f, 0.6f, 0, 0.0f, Ailment.NONE);
        setAtkAtt(ref DragonHaze, 0.9f, 0.1f, 0.9f, 1.0f, 0, 0.0f, Ailment.mired);

        setAtkAtt(ref zeroDamage, 1.0f, 1.0f, 0.0f, 0.0f, 0, 0.0f, Ailment.NONE);
    }

    public AttackAtt getAttackAtt(string name)
    {
        switch(name)
        {
            case "AriaUtility":
                return AriaUtility;
            case "AriaUltimate":
                return AriaUltimate;
            case "AriaNormal":
                return AriaNormal;
            case "AriaSpecial":
                return AriaSpecial;

            case "BaylUtility":
                return BaylUtility;
            case "BaylUltimate":
                return BaylUltimate;
            case "BaylNormal":
                return BaylNormal;
            case "BaylSpecial":
                return BaylSpecial;

            case "XaineUtility":
                return XaineUtility;
            case "XaineUltimate":
                return XaineUltimate;
            case "XaineNormal":
                return XaineNormal;
            case "XaineSpecial":
                return XaineSpecial;

            case "YazirUtility":
                return YazirUtility;
            case "YazirUltimate":
                return YazirUltimate;
            case "YazirNormal":
                return YazirNormal;
            case "YazirSpecial":
                return YazirSpecial;

            case "DragonTailSwipe":
                return DragonTailSwipe;
            case "DragonFireball":
                return DragonFireball;
            case "DragonEarthquake":
                return DragonEarthquake;
            case "DragonHaze":
                return DragonHaze;

            default:
                return zeroDamage;
        }
    }

    public void setAtkAtt(ref AttackAtt attackName, float atkSpd, float phPercent, float maPercent, float atkPwr, int status, float chance, Ailment ailment)
    {
        //Function to specifically designate the values each hero will have to their individual attacks
        attackName.AtkSpd = atkSpd;
        attackName.phPercent = phPercent;
        attackName.maPercent = maPercent;
        attackName.atkPwr = atkPwr;
        attackName.status = status;
        attackName.chance = chance;
        attackName.ailment = ailment;
    }
}

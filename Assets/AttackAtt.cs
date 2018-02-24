using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
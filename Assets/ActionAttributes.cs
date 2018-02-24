using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAttributes
{
    float attackSpeed; //set value given to a specific attack representative of how fast will the character recharge after the attack: 0.5 - 1.75
    float physicalPercent; //percentage of attack that is pysical, range of 0-1
    float magicalPercent; //percentage of attack that is magical, range of 0-1
    float attackPower; //set value given to a specific attack representative of the attack's power: 0.6 - 2.8
    bool statusEffect;//This is used to see if an attack has a status effect or not. 1 is yes, 0 is not
    float chance; //This number is to see what are the chances of dealing a status ailments
    Ailment ailment;//what ailment will this attack cause

    public ActionAttributes()
    { }

    public ActionAttributes(float speed, float physical, float magical, float power, bool effect, float ch, Ailment ail)
    {
        setSpeed(speed);
        setPhysical(physical);
        setMagical(magical);
        setPower(power);
        setStatus(effect);
        setChance(ch);
        setAilment(ail);
    }

    public void setSpeed(float speed) { attackSpeed = speed; }
    public void setPhysical(float physical) { physicalPercent = physical; }
    public void setMagical(float magical) { magicalPercent = magical; }
    public void setPower(float power) { attackPower = power; }
    public void setStatus(bool effect) { statusEffect = effect; }
    public void setChance(float ch) { chance = ch; }
    public void setAilment(Ailment ail) { ailment = ail; }

    public float getSpeed() { return attackSpeed; }
    public float getPhysical() { return physicalPercent; }
    public float getMagical() { return magicalPercent; }
    public float getPower() { return attackPower; }
    public bool getStatus() { return statusEffect; }
    public float getChance() { return chance; }
    public Ailment getAilment() { return ailment; }
}
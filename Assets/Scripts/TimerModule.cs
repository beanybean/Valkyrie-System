/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerModule
{
    const float DEFAULT_TIMER = 1000;

    float utilityStart;
    float ultimateStart;
    float normalStart;
    float specialStart;

    float utilityCooldown;
    float ultimateCooldown;
    float normalCooldown;
    float specialCooldown;

    public TimerModule()
    {
        utilityStart = Time.time;
        ultimateStart = Time.time;
        normalStart = Time.time;
        specialStart = Time.time;

        setUtility(DEFAULT_TIMER);
        setUltimate(DEFAULT_TIMER);
        setNormal(DEFAULT_TIMER);
        setSpecial(DEFAULT_TIMER);
    }

    public TimerModule(float utility, float ultimate, float normal, float special)
    {
        utilityStart = Time.time;
        ultimateStart = Time.time;
        normalStart = Time.time;
        specialStart = Time.time;

        setUtility(utility);
        setUltimate(ultimate);
        setNormal(normal);
        setSpecial(special);
    }

    
    public void setUtility(float time)
    {
        utilityCooldown = time;
    }

    public void setUltimate(float time)
    {
        ultimateCooldown = time;
    }

    public void setNormal(float time)
    {
        normalCooldown = time;
    }

    public void setSpecial(float time)
    {
        specialCooldown = time;
    }

    public bool isReady(Action action)
    {
        switch (action)
        {
            case Action.Utility:
                if (Time.time - utilityStart > utilityTimer)
                    return true;
                else
                    return false;
            case Action.Ultimate:
                if (Time.time - ultimateStart > ultimateTimer)
                    return true;
                else
                    return false;
            case Action.Normal:
                if (Time.time - normalStart > normalTimer)
                    return true;
                else
                    return false;
            case Action.Special:
                if (Time.time - specialStart > specialTimer)
                    return true;
                else
                    return false;
            default:
                return false;
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPoints
{
    const float POINTS_CAP = 100;
    float actionPoints;
    bool knockout = false;

    public ActionPoints()
    {
        actionPoints = POINTS_CAP;
    }

    public ActionPoints(float points)
    {
        actionPoints = points;
    }

    public void addPoints(float points)
    {
        if (actionPoints + points < POINTS_CAP)
            actionPoints += points;
        else
            actionPoints = 100;
    }

    public void add1Point()
    {
        addPoints(1);
    }

    public float getPoints()
    {
        return actionPoints;
    }

    public float getCap()
    {
        return POINTS_CAP;
    }

    public bool isReady()
    {
        if (actionPoints == POINTS_CAP)
            return true;
        else
            return false;
    }

    public float getMeter()
    {
        return actionPoints / POINTS_CAP;
    }

    public void getMeter(Image meter)
    {
        meter.fillAmount = getMeter();
    }

    public void usePoints()
    {
        if (isReady())
            actionPoints = 0;
    }

    public void KO()
    {
        actionPoints = 0;
        knockout = true;
    }

    public bool isKO()
    {
        return knockout;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPoints
{
    const float POINTS_CAP = 100;
    float actionPoints;

    public ActionPoints()
    {
        actionPoints = 0;
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
}

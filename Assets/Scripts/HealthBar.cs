using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar
{
    const float DEFAULT_HEALTH = 1000.0f;

    float health;

    public HealthBar()
    {
        setHealth(DEFAULT_HEALTH);
    }

    public HealthBar(float newHealth)
    {
        setHealth(newHealth);
    }

    void setHealth(float newHealth)
    {
        health = newHealth;
    }

    public float getHealth()
    {
        return health;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }
}

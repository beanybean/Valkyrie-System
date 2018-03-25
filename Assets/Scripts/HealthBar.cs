using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar
{
    const float DEFAULT_HEALTH = 1000.0f;

    float health;
    float maxHealth;

    public HealthBar()
    {
        setHealth(DEFAULT_HEALTH);
        maxHealth = DEFAULT_HEALTH;
    }

    public HealthBar(float newHealth)
    {
        setHealth(newHealth);
        maxHealth = newHealth;
    }

    void setHealth(float newHealth)
    {
        health = newHealth;
    }

    public float getHealth()
    {
        return health;
    }

    public string getHealthString()
    {
        return (Mathf.RoundToInt(health)).ToString(); // + '/' + maxHealth.ToString();
    }

    public void takeDamage(float damage)
    {
        if (health - damage > 0)
            health -= damage;
        else
            health = 0;
    }

    public bool isAlive()
    {
        return health > 0;
    }

    public void fill()
    {
        health = maxHealth;
    }

    public void KO()
    {
        health = 0;
    }
}

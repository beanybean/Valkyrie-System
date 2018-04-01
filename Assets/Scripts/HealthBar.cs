using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void takeDamage(float damage, Image healthImage)
    {
        if (health - damage > 0)
            health -= damage;
        else
            health = 0;
        healthImage.fillAmount = health / maxHealth;
        setColor(healthImage);
    }

    public bool isAlive()
    {
        return health > 0;
    }

    public void fill(Image healthImage)
    {
        health = maxHealth;
        setColor(healthImage);
        healthImage.fillAmount = health / maxHealth;
    }

    public void fillHalf(Image healthImage)
    {
        if (isAlive())
        {
            float fillAmount = maxHealth / 2;
            if (health + fillAmount > maxHealth)
                health = maxHealth;
            else
                health += fillAmount;
            setColor(healthImage);
            healthImage.fillAmount = health / maxHealth;
        }
    }

    public void KO()
    {
        health = 0;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    void setColor(Image healthImage)
    {
        if (health / maxHealth > 0.5f)
            healthImage.color = new Color(0, 255, 0, 255);
        else if (health / maxHealth > 0.25 && health / maxHealth < 0.5)
            healthImage.color = new Color(255, 255, 0, 255);
        else if (health / maxHealth < 0.25)
            healthImage.color = new Color(255, 0, 0, 255);
    }
}

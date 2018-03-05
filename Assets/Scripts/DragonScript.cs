using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonScript : MonoBehaviour {
    const float DRAGON_HEALTH = 10000.0f;
    const float defaultPhAtk = 100.0f;
    const float defaultMaAtk = 100.0f;
    const float defaultPhDef = 50.0f;
    const float defaultMaDef = 50.0f;
    const float defaultRes = 50.0f;
    const float defaultSpd = 50.0f;
    const Element defaultElement = Element.Water;
    HealthBar healthBar = new HealthBar(DRAGON_HEALTH);
    public Text dragonText;
    DamageModule damageModule = new DamageModule();

    public void takeDamage(float phDamage, float maDamage)
    {
        float totalDamage = 0;
        totalDamage += damageModule.phDamageReduction(phDamage, damageModule.getAttribute(Attribute.PhysicalDefense));
        totalDamage += damageModule.maDamageReduction(maDamage, damageModule.getAttribute(Attribute.MagicalDefense));
        healthBar.takeDamage(totalDamage);
    }

	// Use this for initialization
	void Start () {
        damageModule.setAttribute(Attribute.PhysicalAttack, defaultPhAtk);
        damageModule.setAttribute(Attribute.MagicalAttack, defaultMaAtk);
        damageModule.setAttribute(Attribute.PhysicalDefense, defaultPhDef);
        damageModule.setAttribute(Attribute.MagicalDefense, defaultMaDef);
        damageModule.setAttribute(Attribute.Resistance, defaultRes);
        damageModule.setAttribute(Attribute.Speed, defaultSpd);
        damageModule.setWeakness(defaultElement);
    }
	
	// Update is called once per frame
	void Update () {
        dragonText.text = healthBar.getHealth().ToString() + " / " + DRAGON_HEALTH.ToString();
	}
}

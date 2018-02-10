using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AriaBehavior : MonoBehaviour {

    public Text DamageText;
    DamageModule damageModule = new DamageModule();

	// Use this for initialization
	void Start () {
        damageModule.setAttribute(Attribute.PhysicalAttack, 50.0f);
        damageModule.setAttribute(Attribute.MagicalAttack, 50.0f);
        damageModule.setAttribute(Attribute.PhysicalDefense, 50.0f);
        damageModule.setAttribute(Attribute.MagicalDefense, 50.0f);
        damageModule.setAttribute(Attribute.Resistance, 50.0f);
        damageModule.setAttribute(Attribute.Speed, 50.0f);
    }
	
	// Update is called once per frame
	void Update () {
        bool space = Input.GetKeyUp(KeyCode.Space);
        if (space)
            generateAttack();
            
            //transform.Translate(new Vector3(1f, 0, 0) * Time.deltaTime);
		
	}

    void generateAttack()
    {
        float AttackPower = 1.1f * (((100.0f * Mathf.Pow(damageModule.getAttribute(Attribute.PhysicalAttack), 2) + 70) + 16) / 16);
        DamageText.text = AttackPower.ToString();
    }
}

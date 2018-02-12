using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AriaBehavior : MonoBehaviour {

    const float defaultPhAtk = 50f;
    const float defaultMaAtk = 50f;
    const float defaultPhDef = 50f;
    const float defaultMaDef = 50f;
    const float defaultRes = 50f;
    const float defaultSpd = 50f;
    const Element defaultElement = Element.Earth;

    public DamageModule damageModule = new DamageModule();

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
        bool space = Input.GetKeyUp(KeyCode.Space);
        if (space)
            generateAttack();
            
            //transform.Translate(new Vector3(1f, 0, 0) * Time.deltaTime);
		
	}

    void generateAttack()
    {
        
    }
}

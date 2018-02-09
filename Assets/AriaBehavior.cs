using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AriaBehavior : MonoBehaviour {

    DamageModule damageModule = new DamageModule();

	// Use this for initialization
	void Start () {
        damageModule.setAttribute("PhAtk", 50.0f);
        damageModule.setAttribute("MaAtk", 50.0f);
        damageModule.setAttribute("PhDef", 50.0f);
        damageModule.setAttribute("MaDef", 50.0f);
        damageModule.setAttribute("Res", 50.0f);
        damageModule.setAttribute("Spd", 50.0f);
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
        float AttackPower = 1.1f * (((100.0f * Mathf.Pow(damageModule.getAttribute("PhAtk"), 2) + 70) + 16) / 16);
        Debug.Log
    }
}

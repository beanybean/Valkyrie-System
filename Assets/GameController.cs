using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum Action { Utility, Ultimate, NormalAttack, Special };

public class Node
{
    public Attack attack;
    public Node next;
}

public struct Attack
{
    float physicalAttack;
    float magicalAttack;
    Action action;
};

public class GameController : MonoBehaviour {

    const float AtkPwr;

    AriaBehavior Aria;
    public Text DamageText;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void attack()
    {
        float PhysicalDamage = 1f * ((((1f * Mathf.Pow(Aria.damageModule.getAttribute(Attribute.PhysicalAttack), 2) + 70) * 16) + 16) / 16);
        DamageText.text = PhysicalDamage.ToString();
    }
}

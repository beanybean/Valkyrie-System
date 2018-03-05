using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    GameObject Dragon;
    public Queue AttackQueue = new Queue();

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }
    // Use this for initialization
    void Start () {
        Dragon = GameObject.Find("Dragon");
    }
	
	// Update is called once per frame
	void Update () {
        if (AttackQueue.Count > 0)
        {
            Attack currentAttack = (Attack)AttackQueue.Dequeue();
            Dragon.GetComponent<DragonScript>().takeDamage(currentAttack.phDamage, currentAttack.maDamage);
        }
        //player1.getInput(DamageText);
	}
}

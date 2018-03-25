using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    GameObject Dragon;
    GameObject Player;
    public Queue AttackQueue = new Queue();
    public Queue EnemyQueue = new Queue();

    [SerializeField]
    private Text test;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }
    // Use this for initialization
    void Start () {
        Dragon = GameObject.Find("Dragon");
        Player = GameObject.Find("PlayerController");
    }
	
	// Update is called once per frame
	void Update () {
        if (Dragon.GetComponent<DragonScript>().gameOver())
        {
            killAll();
            gameOver();
        }
        else
        {
            if (AttackQueue.Count > 0)
            {
                Attack currentAttack = (Attack)AttackQueue.Dequeue();
                Dragon.GetComponent<DragonScript>().takeDamage(currentAttack.phDamage, currentAttack.maDamage);
            }
            if (EnemyQueue.Count > 0)
            {
                EnemyAttack currentAttack = (EnemyAttack)EnemyQueue.Dequeue();
                Player.GetComponent<PlayerController>().attackPlayer(currentAttack);
            }
        }
	}

    public void gameOver()
    {
        test.text = "GAME OVER";
    }

    void killAll()
    {
        Player.GetComponent<PlayerController>().killAll();
    }
}

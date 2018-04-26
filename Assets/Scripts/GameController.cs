using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        else if (Dragon.GetComponent<DragonScript>().win())
        {
            SceneManager.LoadScene("Win");
        }
        else
        {
            checkPlayerAttacks();
            checkEnemyAttacks();
        }
	}

    public void gameOver()
    {
        //test.text = "GAME OVER";
        SceneManager.LoadScene("GameOver");
    }

    void killAll()
    {
        Player.GetComponent<PlayerController>().killAll();
    }

    void checkPlayerAttacks()
    {
        if (AttackQueue.Count > 0)
        {
            Attack currentAttack = (Attack)AttackQueue.Dequeue();
            Dragon.GetComponent<DragonScript>().takeDamage(currentAttack.phDamage, currentAttack.maDamage);
            Dragon.GetComponent<DragonScript>().counterQueue.Enqueue(currentAttack);
        }
    }

    void checkEnemyAttacks()
    {
        if (EnemyQueue.Count > 0)
        {
            EnemyAttack currentAttack = (EnemyAttack)EnemyQueue.Dequeue();
            Player.GetComponent<PlayerController>().attackPlayer(currentAttack);
        }
    }

    public DragonAttack getNextAttack()
    {
        return Dragon.GetComponent<DragonScript>().getNextAttack();
    }

    public void resetAttackTimerPos()
    {
        Dragon.GetComponent<DragonScript>().resetAttackTimerPos();
    }

    public Vector2 getDragonPosition()
    {
        return Dragon.GetComponent<DragonScript>().getPosition();
    }

    public Vector3 getDragonOffset()
    {
        Vector3 position = getDragonPosition();
        position.x += 1;
        position.z = -1;
        return position;
    }
}
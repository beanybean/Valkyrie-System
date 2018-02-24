using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text DamageText;
    PlayerController player1 = new PlayerController();

    // Use this for initialization
    void Start () {
        DamageText.text = "Start";
	}
	
	// Update is called once per frame
	void Update () {
        player1.getInput(DamageText);
	}
}

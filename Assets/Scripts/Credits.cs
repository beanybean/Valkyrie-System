﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Deselect"))
            SceneManager.LoadScene("Battle");
        else if (Input.GetButtonUp("Credits"))
            SceneManager.LoadScene("Instructions");
    }
}

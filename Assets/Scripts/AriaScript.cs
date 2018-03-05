using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AriaScript : MonoBehaviour {

    const float defaultPhAtk = 50f;
    const float defaultMaAtk = 50f;
    const float defaultPhDef = 50f;
    const float defaultMaDef = 50f;
    const float defaultRes = 50f;
    const float defaultSpd = 50f;
    const Element defaultElement = Element.Wind;
    public Text AriaText;

    HeroClass AriaBehavior = new HeroClass(defaultPhAtk, defaultMaAtk, defaultPhDef,
        defaultMaDef, defaultRes, defaultSpd, defaultElement);

    public void Utility(Text newText)
    {
        newText.text = AriaBehavior.getName() + " Utility";
    }

    public void Ultimate(Text newText)
    {
        newText.text = AriaBehavior.getName() + " Ultimate";
    }

    public void Normal(Text newText)
    {
        newText.text = AriaBehavior.getName() + " Normal";
    }

    public void Special(Text newText)
    {
        newText.text = AriaBehavior.getName() + " Special";
    }
    // Use this for initialization
    void Start () {
        AriaBehavior.setName("Aria");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

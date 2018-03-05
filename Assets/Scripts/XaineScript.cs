using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XaineScript : MonoBehaviour
{
    const float defaultPhAtk = 50f;
    const float defaultMaAtk = 50f;
    const float defaultPhDef = 50f;
    const float defaultMaDef = 50f;
    const float defaultRes = 50f;
    const float defaultSpd = 50f;
    const Element defaultElement = Element.Lightning;
    public Text XaineText;

    HeroClass XaineBehavior = new HeroClass(defaultPhAtk, defaultMaAtk, defaultPhDef,
        defaultMaDef, defaultRes, defaultSpd, defaultElement);

    public void Utility(Text newText)
    {
        newText.text = XaineBehavior.getName() + " Utility";
    }

    public void Ultimate(Text newText)
    {
        newText.text = XaineBehavior.getName() + " Ultimate";
    }

    public void Normal(Text newText)
    {
        newText.text = XaineBehavior.getName() + " Normal";
    }

    public void Special(Text newText)
    {
        newText.text = XaineBehavior.getName() + " Special";
    }
    // Use this for initialization
    void Start()
    {
        XaineBehavior.setName("Xaine");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

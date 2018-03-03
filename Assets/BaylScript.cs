using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaylScript : MonoBehaviour
{
    const float defaultPhAtk = 50f;
    const float defaultMaAtk = 50f;
    const float defaultPhDef = 50f;
    const float defaultMaDef = 50f;
    const float defaultRes = 50f;
    const float defaultSpd = 50f;
    const Element defaultElement = Element.Water;
    public Text BaylText;

    HeroClass BaylBehavior = new HeroClass(defaultPhAtk, defaultMaAtk, defaultPhDef,
        defaultMaDef, defaultRes, defaultSpd, defaultElement);

    public void Utility(Text newText)
    {
        newText.text = BaylBehavior.getName() + " Utility";
    }

    public void Ultimate(Text newText)
    {
        newText.text = BaylBehavior.getName() + " Ultimate";
    }

    public void Normal(Text newText)
    {
        newText.text = BaylBehavior.getName() + " Normal";
    }

    public void Special(Text newText)
    {
        newText.text = BaylBehavior.getName() + " Special";
    }
    // Use this for initialization
    void Start()
    {
        BaylBehavior.setName("Bayl");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

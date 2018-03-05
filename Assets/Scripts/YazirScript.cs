using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YazirScript : MonoBehaviour
{
    const float defaultPhAtk = 50f;
    const float defaultMaAtk = 50f;
    const float defaultPhDef = 50f;
    const float defaultMaDef = 50f;
    const float defaultRes = 50f;
    const float defaultSpd = 50f;
    const Element defaultElement = Element.Earth;
    public Text YazirText;

    HeroClass YazirBehavior = new HeroClass(defaultPhAtk, defaultMaAtk, defaultPhDef,
        defaultMaDef, defaultRes, defaultSpd, defaultElement);

    public void Utility(Text newText)
    {
        newText.text = YazirBehavior.getName() + " Utility";
    }

    public void Ultimate(Text newText)
    {
        newText.text = YazirBehavior.getName() + " Ultimate";
    }

    public void Normal(Text newText)
    {
        newText.text = YazirBehavior.getName() + " Normal";
    }

    public void Special(Text newText)
    {
        newText.text = YazirBehavior.getName() + " Special";
    }
    // Use this for initialization
    void Start()
    {
        YazirBehavior.setName("Yazir");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

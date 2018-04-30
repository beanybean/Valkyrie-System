using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Instructions : MonoBehaviour {

    GameObject Aria;
    GameObject Bayl;
    GameObject Xaine;
    GameObject Yazir;

    [SerializeField]
    Text ariaText;
    [SerializeField]
    Text baylText;
    [SerializeField]
    Text xaineText;
    [SerializeField]
    Text yazirText;

    [SerializeField]
    Text headerText;
    [SerializeField]
    Text controlsText;
    [SerializeField]
    Text prompt;

    float positionOffset = 1.8f;
    Vector2 center = new Vector2(-3f, -1.9f);
    Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

    Vector2 headerPosition = new Vector2(Screen.width / 2, Screen.height * 0.95f);
    Vector2 textOffset;
    Vector2 ariaPosition;
    Vector2 baylPosition;
    Vector2 xainePosition;
    Vector2 yazirPosition;

	// Use this for initialization
	void Start () {
        Aria = GameObject.Find("Aria");
        Bayl = GameObject.Find("Bayl");
        Xaine = GameObject.Find("Xaine");
        Yazir = GameObject.Find("Yazir");
        ariaPosition = new Vector2(center.x, center.y + 2 * positionOffset);
        baylPosition = new Vector2(center.x, center.y + 1 * positionOffset);
        xainePosition = new Vector2(center.x, center.y + 0 * positionOffset);
        yazirPosition = new Vector2(center.x, center.y + -1 * positionOffset);
        Aria.transform.position = ariaPosition;
        Bayl.transform.position = baylPosition;
        Xaine.transform.position = xainePosition;
        Yazir.transform.position = yazirPosition;
        setText();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Deselect"))
            SceneManager.LoadScene("Battle");
        else if (Input.GetButtonUp("Credits"))
            SceneManager.LoadScene("Credits");
    }

    void setText()
    {
        headerText.transform.position = headerPosition;
        controlsText.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.90f);
        Vector2 offset = new Vector2(0, 150f);
        ariaText.transform.position = screenCenter + offset * 1;
        baylText.transform.position = screenCenter + offset * 0;
        xaineText.transform.position = screenCenter + offset * -1;
        yazirText.transform.position = screenCenter + offset * -2;
        prompt.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.8f);
    }
}

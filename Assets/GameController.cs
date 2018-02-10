using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Action { Utility, Ultimate, NormalAttack, Special };

public class Node
{
    public Attack attack;
    public Node next;
}

public struct Attack
{
    float physicalAttack;
    float magicalAttack;
    Action action;
};

public class LinkedList
{
    public Node head;

    public void add(Node newNode)
    {
        if (head == null)
            head = newNode;
        else

        {
            Node current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = newNode;
        }
    }
}

public class GameController : MonoBehaviour {

    LinkedList attackList;


	// Use this for initialization
	void Start () {
        attackList.head = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

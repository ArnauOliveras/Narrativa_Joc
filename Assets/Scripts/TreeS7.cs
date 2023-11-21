using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeS7 : MonoBehaviour
{
    public GameObject red;
    public GameObject UI;
    GameManeger GM;
    bool playerTrigger;
    float DistanceToTalk = 3;
    public TextNode[] TextAdd;
    public TextNode[] TextAddLast;
    public TextNode[] TextNoAdd;
    public bool addGusano;
    bool firstime = true;
    bool ttt;


    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>();
        ttt = false;
    }


    void Update()
    {
        if (GM.insectos == GM.MAXinsectos)
        {
            firstime = false;
            red.SetActive(false);
            ttt = false;
        }

        if (Vector3.Distance(transform.position, GM.player.transform.position) <= DistanceToTalk && !playerTrigger && firstime)
        {
            playerTrigger = true;
        }

        if (Vector3.Distance(transform.position, GM.player.transform.position) > DistanceToTalk && playerTrigger )
        {
            playerTrigger = false;
            UI.SetActive(false);
        }

        if (playerTrigger && !GM.TM.isTalking && firstime)
        {
            UI.SetActive(true);
        }

        if (ttt && !GM.TM.isTalking)
        {
            ttt = false;
            red.SetActive(false);
            if (addGusano)
            {
                GM.AddGusano();
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && playerTrigger && firstime)
        {
            UI.SetActive(false);
            if (addGusano)
            {
                if (GM.insectos + 1 == GM.MAXinsectos)
                {
                    GM.TM.SetNodesText(TextAddLast);
                }
                else
                {
                    GM.TM.SetNodesText(TextAdd);
                }
            }
            else
            {
                GM.TM.SetNodesText(TextNoAdd);
            }
            ttt = true;
            firstime = false;
        }

    }
}

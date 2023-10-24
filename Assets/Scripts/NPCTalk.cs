using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    GameObject player;
    GameManeger GM;
    public TextNode[] Text1;
    [Header("Posar el segon text en cas de tenir una segona comber, sino deixar a 0")]
    public TextNode[] Text2;
    TextNode[] Text;
    public float DistanceToTalk = 1.5f;
    bool playerTrigger;
    public int textNum = 1;
    bool noMoreTalk = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GM = GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>();
        Text = Text1;
        
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= DistanceToTalk)
        {
            playerTrigger = true;
        }
        else
        {
            playerTrigger = false;
            GM.EperParlar.SetActive(false);
        }

        if (playerTrigger && !GM.TM.isTalking && !noMoreTalk)
        {
            GM.EperParlar.SetActive(true);
        }


        if (Input.GetKeyUp(KeyCode.E) && !GM.TM.isTalking && playerTrigger && !noMoreTalk)
        {
            GM.TM.SetNodesText(Text);
            GM.EperParlar.SetActive(false);
            if (Text2.Length == 0)
            {
                noMoreTalk = true;
            }
            else
            {
                Text = Text2;
            }
        }
    }
}

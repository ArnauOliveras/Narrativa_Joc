using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameFloresStart : MonoBehaviour
{
    public TextNode[] EmpezarMinijuego;
    GameManeger GM;
    public GameObject DoorMinigame;
    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>();
    }
    private void OnTriggerEnter(Collider other)
    {
        GM.TM.SetNodesText(EmpezarMinijuego);
        StartCoroutine(GM.ShiftParaCorrer());
        DoorMinigame.SetActive(true);
        gameObject.SetActive(false);
    }
}

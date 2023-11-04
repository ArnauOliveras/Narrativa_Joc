using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S5minigameSuperado : MonoBehaviour
{
    GameManeger GM;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GM.MinigameSuperado();
    }
}

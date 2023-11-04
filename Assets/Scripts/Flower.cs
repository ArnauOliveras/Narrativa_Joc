using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    GameManeger GM;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && Vector3.Distance(GM.playerController.gameObject.transform.position, transform.position) <= 1)
        {
            GM.AddFlowers();
            gameObject.SetActive(false);
        }
    }
}

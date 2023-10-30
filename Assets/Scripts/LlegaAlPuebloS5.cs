using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlegaAlPuebloS5 : MonoBehaviour
{
    public TextNode[] LlegaAlPueblo;
    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>().TM.SetNodesText(LlegaAlPueblo);
        gameObject.SetActive(false);
    }
}

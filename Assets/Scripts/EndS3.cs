using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndS3 : MonoBehaviour
{
    public TextNode[] TextEnd;

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>().TM.SetNodesText(TextEnd);
    }
}

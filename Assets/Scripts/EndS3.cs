using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndS3 : MonoBehaviour
{
    public TextNode[] TextEnd;
    bool end = false;

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>().TM.SetNodesText(TextEnd);
        end = true;
    }
    private void Update()
    {
        if (end && !GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>().TM.isTalking)
        {
            SceneManager.LoadScene("4_HouseCurandero");
        }
    }
}

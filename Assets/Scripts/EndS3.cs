using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndS3 : MonoBehaviour
{
    public TextNode[] TextEnd;
    bool end = false;
    public Animator animator;
    public PlayerController playerController;
    public GameObject UI;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Ullss3());
        animator.SetTrigger("s3");
        playerController.stop = true;
    }

    IEnumerator Ullss3()
    {
        yield return new WaitForSeconds(4);
        GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>().TM.SetNodesText(TextEnd);
        end = true;
    }
    
    IEnumerator EndS3_2()
    {
        UI.SetActive(false);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("4_HouseCurandero");
    }

    private void Update()
    {
        if (end && !GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>().TM.isTalking)
        {
            StartCoroutine(EndS3_2());
            animator.SetTrigger("s3");

        }
    }
}

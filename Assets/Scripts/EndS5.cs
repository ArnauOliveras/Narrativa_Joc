using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndS5 : MonoBehaviour
{
    public Animator animator;
    public GameObject UI;

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("s5");
        UI.SetActive(false);
        StartCoroutine(EndS5_1());
    }

    IEnumerator EndS5_1()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("6_HouseCurandero");
    }

}

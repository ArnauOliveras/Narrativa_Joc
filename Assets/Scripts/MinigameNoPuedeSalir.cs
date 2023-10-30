using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameNoPuedeSalir : MonoBehaviour
{
    GameManeger GM;
    public GameObject Mensage;
    bool firstTime = true;
    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!firstTime)
        {
            StartCoroutine(NoPuedesSalir());
        }
        else
        {
            firstTime = false;
        }
    }
    public IEnumerator NoPuedesSalir()
    {
        Mensage.SetActive(true);
        yield return new WaitForSeconds(2);
        Mensage.SetActive(false);
    }
}

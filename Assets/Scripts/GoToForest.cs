using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToForest : MonoBehaviour
{
    public GameObject go;
    private void OnTriggerEnter(Collider other)
    {
        go.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        go.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Transition : MonoBehaviour
{
    public Image trans; 
    bool start;

    void Start()
    {
        start = false;
    }

    private void OnDisable()
    {
        
    }

    private void OnEnable()
    {
        start = true;
    }

    void Update()
    {
        if (start)
        {
            trans.tintColor = Color.Lerp(trans.tintColor,Color.clear,Time.deltaTime * 10);
        }
    }
}

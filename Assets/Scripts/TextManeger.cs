using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManeger : MonoBehaviour
{
    public TextNode[] textNodes;
    public GameObject textGO;
    public GameObject nextButton;
    public TextMeshProUGUI nameTMP;
    public TextMeshProUGUI textTMP;
    string thisText;
    string thisName;
    public bool isTalking;
    bool canDoNextNode;
    int nodeNum;
    public float timeContinuar = 2;
    [Header("Desactivar perque sigui com la build")]
    public bool saltarTiempoEnUnity = true;

    void Start()
    {
        isTalking = false;
#if UNITY_EDITOR
        if (saltarTiempoEnUnity)
        {
            timeContinuar = 0;
        }
#endif
    }

    void Update()
    {
        

        if (isTalking)
        {
            nameTMP.text = thisName;
            textTMP.text = thisText;
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) && canDoNextNode)
            {
                SetNextNode();
                StartCoroutine(CanDoNextNode());
                canDoNextNode = false;
                nextButton.SetActive(false);
            }
        }
        else
        {
            textGO.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SetNodesText(textNodes);
        }
    }

    IEnumerator CanDoNextNode()
    {
        yield return new WaitForSeconds(timeContinuar);
        canDoNextNode = true;
        nextButton.SetActive(true);
    }

    void SetNextNode()
    {
        nodeNum++;
        if (nodeNum < textNodes.Length)
        {
            thisName = textNodes[nodeNum].Name;
            thisText = textNodes[nodeNum].Text;
        }
        else
        {
            isTalking = false;
            textNodes = null;
        }
    }


    public void SetNodesText(TextNode[] l_textNodes)
    {
        canDoNextNode = false;
        StartCoroutine(CanDoNextNode());
        nextButton.SetActive(false);
        nodeNum = 0;
        textNodes = l_textNodes;
        isTalking = true;
        textGO.SetActive(true);
        thisName = textNodes[nodeNum].Name;
        thisText = textNodes[nodeNum].Text;
    }


}

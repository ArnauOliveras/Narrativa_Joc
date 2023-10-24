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
    string text;
    string name;
    public bool isTalking;
    public bool isWriting;
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

    int indice = 0;
    bool lent = false;

    void Update()
    {
        if (isWriting)
        {
            bool canContinueName = false;
            bool canContinueText = false;
            List<char> listaDeLetrasNombre = new List<char>(name.ToCharArray());
            List<char> listaDeLetrasTexto = new List<char>(text.ToCharArray());

            if (lent)
            {
                if (listaDeLetrasNombre.Count > indice)
                {
                    thisName = thisName + listaDeLetrasNombre[indice];
                }
                else
                {
                    canContinueName = true;
                }

                if (listaDeLetrasTexto.Count > indice)
                {
                    thisText = thisText + listaDeLetrasTexto[indice];
                }
                else
                {
                    canContinueText = true;
                }

                indice++;
                lent = false;
            }
            else
            {
                lent = true;
            }



            nameTMP.text = thisName;
            textTMP.text = thisText;

            if (canContinueName && canContinueText)
            {
                canDoNextNode = true;
                indice = 0;
                thisName = "";
                thisText = "";
                nextButton.SetActive(true);
                isWriting = false;
            }


        }

        if (isTalking)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) && canDoNextNode)
            {
                SetNextNode();
                //StartCoroutine(CanDoNextNode());
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
            name = textNodes[nodeNum].Name;
            text = textNodes[nodeNum].Text;
            isWriting = true;
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
        //StartCoroutine(CanDoNextNode());
        nextButton.SetActive(false);
        nodeNum = 0;
        textNodes = l_textNodes;
        isTalking = true;
        textGO.SetActive(true);
        name = textNodes[nodeNum].Name;
        text = textNodes[nodeNum].Text;
        isWriting = true;
    }


}

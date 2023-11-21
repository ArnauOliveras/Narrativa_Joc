using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class TextManeger : MonoBehaviour
{
    GameManeger GM;
    public TextNode[] textNodes;
    public GameObject textGO;
    public GameObject nextButton;
    public GameObject options;
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

    bool final;

    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>();
        final = false;
        isTalking = false;
#if UNITY_EDITOR
        if (saltarTiempoEnUnity)
        {
            timeContinuar = 0;
            framesXLetra = 1;
        }
#endif
        lent = framesXLetra;
    }

    int indice = 0;
    int lent = 0;
    public int framesXLetra = 4;

    void Update()
    {
        if (isWriting)
        {
            if (name == " ")
            {
                textTMP.fontStyle = (FontStyles)FontStyle.Italic;
            }
            else
            {
                textTMP.fontStyle = (FontStyles)FontStyle.Normal;
            }
            bool canContinueName = false;
            bool canContinueText = false;
            List<char> listaDeLetrasNombre = new List<char>(name.ToCharArray());
            List<char> listaDeLetrasTexto = new List<char>(text.ToCharArray());

            if (lent == framesXLetra)
            {
                lent = 0;
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
            }
            else
            {
                lent++;
            }



            nameTMP.text = thisName;
            textTMP.text = thisText;

            if (canContinueName && canContinueText)
            {
                canDoNextNode = true;
                indice = 0;
                thisName = "";
                thisText = "";
                if (!final)
                {
                    nextButton.SetActive(true);
                }
                else
                {
                    options.SetActive(true);
                }
                isWriting = false;
                lent = framesXLetra;
            }


        }

        if (isTalking)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) && canDoNextNode && !final)
            {
                SetNextNode();
                canDoNextNode = false;
                nextButton.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && canDoNextNode && final)
            {
                final = false;
                canDoNextNode = false;
                options.SetActive(false);
                GM.setFinal(true);
                SetNextNode();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && canDoNextNode && final)
            {
                final = false;
                canDoNextNode = false;
                options.SetActive(false);
                GM.setFinal(false);
                SetNextNode();
            }
        }
        else
        {
            textGO.SetActive(false);
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
            if (textNodes[nodeNum].optionFinal)
            {
                final = true;
            }
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

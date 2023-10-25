using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public int numScene = 0;
    public TextManeger TM;
    public GameObject EperParlar;
    public GameObject EperInteractuar;

    [Header("Scene3")]

    public TextNode[] TextInit3;
    public TextNode[] TextGoToForest3;
    bool talkS3 = false;

    public TextMeshProUGUI missNum;
    public TextMeshProUGUI missTitle;
    public GameObject GoToForest;
    int personasPorHablar = 6;
    int personasHabladas = 0;

    private void Start()
    {
        if (numScene == 3)
        {
            TM.SetNodesText(TextInit3);
        }
    }

    private void Update()
    {
        if (numScene == 3)
        {
            missNum.text = personasHabladas + "/" + personasPorHablar;
            if (personasPorHablar == personasHabladas)
            {
                GoToForest.SetActive(false);
                if (TM.isTalking == false && !talkS3)
                {
                    talkS3 = true;
                    StartCoroutine(GoToForestS3());
                }
            }
        }
    }
    IEnumerator GoToForestS3()
    {
        yield return new WaitForSeconds(3);
        TM.SetNodesText(TextGoToForest3);
        missNum.gameObject.SetActive(false);
        missTitle.text = "Dirijete al bosque que está al lado de la médica.";
    }
    public void AddPersonasHabladas()
    {
        personasHabladas++;
    }
}

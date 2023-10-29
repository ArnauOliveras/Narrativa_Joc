using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    public int numScene = 0;
    public TextManeger TM;
    public GameObject EperParlar;
    public GameObject EperInteractuar;
    public GameObject player;
    public GameObject camera;
    public GameObject UI;
    int personasHabladas = 0;


    [Header("Transition")]
    public Animator transition;
    public GameObject transitionGO;


    [Header("Scene1")]
    public GameObject mainMenu;
    public GameObject mainMenuButtons;
    public GameObject creditos;
    public GameObject NPCS1;
    public TextNode[] TextInit1;
    public TextNode[] TextCarta1;
    bool activeEatS1 = true;
    bool activeCartaS1 = true;
    bool deactiveCartaS1 = true;
    bool endS1 = true;
    public GameObject EatGM;
    public NPCTalk textNPCS1_1;
    public NPCTalk textNPCS1_2;
    public NPCTalk textNPCS1_3;
    public GameObject Carta;

    [Header("Scene3")]

    public TextNode[] TextInit3;
    public TextNode[] TextGoToForest3;
    bool talkS3 = false;

    public TextMeshProUGUI missNum;
    public TextMeshProUGUI missTitle;
    public GameObject GoToForest;
    int personasPorHablar = 6;

    private void Start()
    {
        transitionGO.SetActive(true);

        if (numScene == 1)
        {

        }
        if (numScene == 3)
        {
            TM.SetNodesText(TextInit3);
            
        }
    }

    private void Update()
    {
        if (numScene == 1)
        {
            if (TM.isTalking == false && personasHabladas == 1 && activeEatS1)
            {
                activeEatS1 = false;
                EatGM.SetActive(true);
            }

            if (TM.isTalking == false && personasHabladas == 2 && !activeEatS1)
            {
                textNPCS1_1.enabled = false;
                textNPCS1_2.enabled = true;
            }

            if (TM.isTalking == false && personasHabladas == 3 && activeCartaS1)
            {
                activeCartaS1 = false;
                Carta.SetActive(true);
                StartCoroutine(ReadCartaS1());
            }
            
            if (TM.isTalking == false && personasHabladas == 4 && deactiveCartaS1)
            {
                deactiveCartaS1 = false;
                Carta.SetActive(false);
                textNPCS1_2.enabled = false;
                textNPCS1_3.enabled = true;
            }
            if (TM.isTalking == false && personasHabladas == 5 && endS1)
            {
                endS1 = false;
                transition.SetTrigger("s1_2");
                StartCoroutine(EndS1());
            }
        }

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

    IEnumerator EndS1()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("2_Hospital");
    }
    
    IEnumerator ReadCartaS1()
    {
        yield return new WaitForSeconds(1);
        TM.SetNodesText(TextCarta1);
        personasHabladas++;
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.1f);
        player.SetActive(true);
        UI.SetActive(true);
        NPCS1.SetActive(true);
        camera.GetComponent<CameraController>().enabled = true;
        mainMenu.SetActive(false);
        yield return new WaitForSeconds(1f);
        TM.SetNodesText(TextInit1);
    }
    public void AddPersonasHabladas()
    {
        personasHabladas++;
    }

    public void StartMM()
    {
        mainMenuButtons.SetActive(false);
        transition.SetTrigger("s1_1");
        StartCoroutine(StartGame());

    }

    public void CreditosMM()
    {
        creditos.SetActive(true);
        mainMenuButtons.SetActive(false);
    }
    public void BackMM()
    {
        creditos.SetActive(false);
        mainMenuButtons.SetActive(true);
    }
    public void QuitMM()
    {
        Application.Quit();
    }

}

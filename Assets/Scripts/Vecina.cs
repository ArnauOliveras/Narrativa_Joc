using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Vecina : MonoBehaviour
{
    NavMeshAgent agent;
    public bool perseguir = false;
    GameManeger GM;
    public Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GM = GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>();
    }

    void Update()
    {

        if (perseguir)
        {
            agent.destination = GM.playerController.gameObject.transform.position;
            if (agent.hasPath)
            {
                animator.SetInteger("Move", 2);
                animator.SetInteger("arms", 2);
            }
            else
            {
                animator.SetInteger("Move", 0);
                animator.SetInteger("arms", 3);
            }
        }
        else
        {
            agent.destination = gameObject.transform.position;
            animator.SetInteger("Move", 0);
            animator.SetInteger("arms", 3);
        }



    }
}

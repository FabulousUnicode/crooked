using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    public static NavMeshAgent agent;
    private Animator animator;

    public void Start()
    {
        

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }


    public void Update()
    {
        
        //idle
        if (agent.velocity.x == 0)
        {
            animator.SetInteger("direction", 0);
        }

        #region movement up/right

        //velocity right is higher than up
        if (agent.velocity.x > 0 && agent.velocity.y > 0 && agent.velocity.x > agent.velocity.y)
        {
            animator.SetInteger("direction", 3);
        }

        //velocity right is lower than up
        if(agent.velocity.x > 0 && agent.velocity.y > 0 && agent.velocity.x < agent.velocity.y)
        {
            animator.SetInteger("direction", 1);
        }

        #endregion

        #region movement down/right

        //velocity right is higher than down
        if(agent.velocity.x > 0 && agent.velocity.y < 0 && agent.velocity.x > Mathf.Abs(agent.velocity.y))
        {
            animator.SetInteger("direction", 3);
        }
        //velocity right is lower than down
        if(agent.velocity.x > 0 && agent.velocity.y < 0 && agent.velocity.x < Mathf.Abs(agent.velocity.y))
        {
            animator.SetInteger("direction", 2);
        }

        #endregion

        #region movement up/left
        //velocity left is higher than up
        if(agent.velocity.x < 0 && agent.velocity.y > 0 && Mathf.Abs(agent.velocity.x) > agent.velocity.y)
        {
            animator.SetInteger("direction", 4);
        }
        if(agent.velocity.x < 0 && agent.velocity.y > 0 && Mathf.Abs(agent.velocity.x) < agent.velocity.y)
        {
            animator.SetInteger("direction", 1);
        }

        #endregion

        #region movement down/left
        if (agent.velocity.x < 0 && agent.velocity.y < 0 && Mathf.Abs(agent.velocity.x) > Mathf.Abs(agent.velocity.y))
        {
            animator.SetInteger("direction", 4);
        }
        if(agent.velocity.x < 0 && agent.velocity.y < 0 && Mathf.Abs(agent.velocity.x) < Mathf.Abs(agent.velocity.y))
        {
            animator.SetInteger("direction", 2);
        }

        #endregion


        /*
        Debug.Log(agent.destination.x);
        Debug.Log(agent.nextPosition.x);
        */
    }

}
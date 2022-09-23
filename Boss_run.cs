using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_run : StateMachineBehaviour
{

    public float speed = 2.5f;
    public float attackRange = 3f;
    public int strong;
    
    Transform player;
    Transform boss;
    Rigidbody rb;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody>();
        boss = animator.transform;
        //strong = 8;
        strong = Random.Range(0, 10);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 target = new Vector3(player.position.x, rb.position.y, player.position.z);
        Vector3 newpos = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newpos);
        boss.LookAt(player);

        if(Vector3.Distance(player.position, rb.position) <= attackRange && strong < 7)
        {
            animator.SetTrigger("Attack");
        }
        else if(Vector3.Distance(player.position, rb.position) <= attackRange && strong >= 7)
        {
            animator.SetTrigger("Strong");
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Strong");
    }

    
}

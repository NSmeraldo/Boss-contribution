using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Strong : StateMachineBehaviour
{

    //public GameObject _attackCollider;

    //public int chargeAmount;
    //public int chargeTotal;
    //public Slider chargeMeter;
    //public GameObject baseAttack;
    //public GameObject strongAttack;
    public GameObject boss;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Strong Attack");
        boss = animator.gameObject;
        


        
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //StartCoroutine("PowerState");
        //_attackCollider = strongAttack;
        boss.GetComponent<Attacker>().enabled = false;
        boss.GetComponent<StrongAttacker>().enabled = true;
       
        
        

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.GetComponent<Attacker>().enabled = true;
        boss.GetComponent<StrongAttacker>().enabled = false;
    }

    


}

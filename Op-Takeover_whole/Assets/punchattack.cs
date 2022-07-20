using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchattack : StateMachineBehaviour
{
    JumboJoeManager jumboJoeManager;
    JumboeJoeHealth jumboeJoeHealth;
    public int _energyDamages;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jumboJoeManager = animator.GetComponent<JumboJoeManager>();
         jumboeJoeHealth = animator.GetComponent<JumboeJoeHealth>();
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jumboeJoeHealth.TakeEnergyAway(_energyDamages);
    }


}

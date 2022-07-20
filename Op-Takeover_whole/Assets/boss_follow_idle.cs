using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_follow_idle : StateMachineBehaviour
{
    JumboJoeManager jumboJoeManager;

    public int speed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jumboJoeManager = animator.GetComponent<JumboJoeManager>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jumboJoeManager.LookAtPlayer();
        jumboJoeManager.follow(speed);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }



}

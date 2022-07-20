using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class special_attack_back : StateMachineBehaviour
{
    JumboJoeManager jumboJoeManager;

    public int speed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jumboJoeManager = animator.GetComponent<JumboJoeManager>();
        jumboJoeManager.Specialattackbackoff();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jumboJoeManager.Specialattackbackoff();

        
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

  
}

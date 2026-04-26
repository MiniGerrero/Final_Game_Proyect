using UnityEngine;

public class DialogoChange : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC_Text_Sistem mapacheMode = animator.GetComponent<NPC_Text_Sistem>();
        if (mapacheMode != null){
            mapacheMode.DialogoAnimator();

        }

    }
}
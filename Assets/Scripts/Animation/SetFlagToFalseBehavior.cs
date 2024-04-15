using UnityEngine;

namespace Animation
{
    public class SetFlagToFalseBehavior : StateMachineBehaviour
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("startSip", false);
        }
    }
}
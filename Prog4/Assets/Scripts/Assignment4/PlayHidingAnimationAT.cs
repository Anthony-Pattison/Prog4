using UnityEngine;
using NodeCanvas.Tasks.Actions;
using NodeCanvas.Framework;
namespace NodeCanvas.Tasks.Actions
{
   
    public class PlayHidingAnimationAT : ActionTask
    {
        public Animator animator;
        protected override void OnExecute()
        {
            animator.SetBool("Sneaking", true);
        }
        protected override void OnStop()
        {
            animator.SetBool("Sneaking", false);
        }
    }
}

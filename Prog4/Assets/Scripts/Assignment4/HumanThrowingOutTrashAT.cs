using UnityEngine;
using NodeCanvas.Framework;
namespace NodeCanvas.Tasks.Actions
{
    public class HumanThrowingOutTrashAT : ActionTask
    {
        public Blackboard CoyoteBBP;
        public BBParameter<bool> HumanPresent;
        protected override void OnExecute()
        {
            CoyoteBBP.SetVariableValue("HumanPresent", HumanPresent.value);
            EndAction();
        }

    }
}

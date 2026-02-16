using UnityEngine;
using NodeCanvas.Framework;
namespace NodeCanvas.Tasks.Actions
{
    public class SetBlackBoardBoolAT : ActionTask
    {
        public Blackboard CoyoteBBP;
        public BBParameter<bool> HumanPresent;
        public string VaribleName;
        protected override void OnExecute()
        {
            CoyoteBBP.SetVariableValue(VaribleName, HumanPresent.value);
            EndAction();
        }

    }
}

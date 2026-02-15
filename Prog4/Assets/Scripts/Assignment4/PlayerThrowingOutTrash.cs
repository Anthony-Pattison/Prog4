using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.Rendering;

namespace NodeCanvas.Tasks.Actions {
    public class PlayerThrowingOutTrash : ActionTask
    {
        public Blackboard CoyoteBBP;
        public BBParameter<bool> GarbageFull;
        protected override void OnExecute()
        {
            //CoyoteBBP.SetVariableValue("GarbageFull", false);
            base.OnExecute();
        }
        protected override void OnUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CoyoteBBP.SetVariableValue("GarbageFull", true);
                EndAction();

            }

        }

    }
    
}

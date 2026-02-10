using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.Rendering;

namespace NodeCanvas.Tasks.Actions {
    public class PlayerThrowingOutTrash : ActionTask
    {
        public Blackboard CoyoteBBP;
        public BBParameter<bool> GarbageFull;
        
        protected override void OnUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GarbageFull.value = true;

            }
            CoyoteBBP.SetVariableValue("GarbageFull", GarbageFull.value);
            if (GarbageFull.value)
                EndAction();
        }

        protected override void OnStop()
        {
            CoyoteBBP.SetVariableValue("GarbageFull", GarbageFull.value);
        }
    }
    
}

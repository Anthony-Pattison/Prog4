using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class SeekTask : ActionTask
    {
        public BBParameter<Vector3> TargetPositionBBP;
        public BBParameter<Transform> SeekTargetBBP;

        public float SeekRadius = 4f;

        protected override void OnUpdate()
        {
            if (SeekTargetBBP.value == null)
                EndAction();
            else
            {
                float distance = Vector3.Distance(agent.transform.position, SeekTargetBBP.value.position);
                if (distance < SeekRadius)
                {
                    TargetPositionBBP.value = SeekTargetBBP.value.position;
                }
            }

        }
    }
}

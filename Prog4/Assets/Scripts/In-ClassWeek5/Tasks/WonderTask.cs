using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
    public class WonderTask : ActionTask
    {
        public BBParameter<float> TimeSinceLastSampleBBP;
        public BBParameter<bool> IsMovingBBP;
        public BBParameter<Vector3> TargetPositionBBP;

        public float WanderDistance = 4f;
        public float WanderRadius = 3f;

        protected override void OnUpdate()
        {
            if (TimeSinceLastSampleBBP.value == 0 && !IsMovingBBP.value)
            {
                if (NavMesh.SamplePosition(CalculatePosition(), out NavMeshHit hitInfo, WanderDistance + WanderRadius, NavMesh.AllAreas))
                {
                    TargetPositionBBP.value = hitInfo.position;
                }
            }
        }

        private Vector3 CalculatePosition()
        {
            Vector3 circleDistance = agent.transform.position + agent.transform.forward * WanderDistance;
            Vector3 randomPoint = Random.insideUnitSphere.normalized * WanderRadius;

            return circleDistance + randomPoint;
        }
    }
}

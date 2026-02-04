using NodeCanvas.Framework;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

namespace NodeCanvas.Tasks.Actions
{
    public class NavagationTask : ActionTask
    {
        public BBParameter<Vector3> TargetPositionBBP;
        public BBParameter<float> TimeSinceLastSampleBBP;
        public BBParameter<bool> IsMovingBBP;

        public float sampleRateInSeconds;
        public float sampleRadiusInUnits;

        private Vector3 LastTargetPosition;
        private NavMeshAgent navMesh;
        protected override string OnInit()
        {
            // get the nav mesh reff
            navMesh = agent.GetComponent<NavMeshAgent>();
            if (navMesh == null)
                Debug.Log($"Unable to find nav mesh agent for {agent.name}");
            return null;
        }

        protected override void OnUpdate()
        {
            // delay the check for a new position
            TimeSinceLastSampleBBP.value += Time.deltaTime;
            // if its time to take a sample for a new position
            if (TimeSinceLastSampleBBP.value > sampleRateInSeconds)
            {
                //reset timer
                TimeSinceLastSampleBBP.value = 0;
                // are we going to a new position
                if (LastTargetPosition != TargetPositionBBP.value)
                {
                    // update positon
                    LastTargetPosition = TargetPositionBBP.value;
                    // taking the positon we want and checking if it can be reached by our agent
                    if (NavMesh.SamplePosition(TargetPositionBBP.value, out NavMeshHit hit, sampleRadiusInUnits, NavMesh.AllAreas))
                    {
                        // if found update to a new path
                        navMesh.SetDestination(TargetPositionBBP.value);
                    }
                }

                IsMovingBBP.value =
                    navMesh.remainingDistance != 0 &&
                    navMesh.remainingDistance != Mathf.Infinity ||
                    navMesh.pathPending; // the path finding takes more than one frame to do

            }

        }
    }
}
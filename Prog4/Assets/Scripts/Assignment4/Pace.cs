using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class Pace : ActionTask {
		public BBParameter<List<Transform>> PacingSpots;
        public BBParameter<float> StopDis;
        Transform MovingTowards;
		NavMeshAgent NavAgent;
		int spot = 0;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			NavAgent = agent.GetComponent<NavMeshAgent>();
			MovingTowards = PacingSpots.value[spot];
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			NavAgent.SetDestination(MovingTowards.position);
			if (Vector3.Distance(agent.transform.position, MovingTowards.position) < StopDis.value) 
			{ 
				ChangeDestination();
			}
		}
		void ChangeDestination()
		{
			spot++;
			if (spot == PacingSpots.value.Count -1)
			{
				spot = 0;
			}
            MovingTowards = PacingSpots.value[spot];
        }
		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
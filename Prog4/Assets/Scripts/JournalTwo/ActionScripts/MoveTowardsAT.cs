using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {
	public class MoveTowardsAT : ActionTask {

        public Transform closet;
		public BBParameter<float> moveSpeed;
        public BBParameter<float> rotationSpeed;
        public BBParameter<float> stoppingDistance;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Vector3 Pos = agent.transform.position;
			Vector3 Destination = Pos - closet.position;
			Quaternion Rotation = Quaternion.LookRotation(Destination);
			agent.transform.SetPositionAndRotation(agent.transform.position + moveSpeed.value * Time.deltaTime * agent.transform.forward, Quaternion.RotateTowards(agent.transform.rotation, Rotation, rotationSpeed.value * Time.deltaTime));
			if (Vector3.Distance(Pos, closet.position) < stoppingDistance.value)
			{
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
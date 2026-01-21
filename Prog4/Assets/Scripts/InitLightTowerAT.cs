using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class InitLightTowerAT : ActionTask {
		public BBParameter<Light> lightBBP;
		public BBParameter<Transform> WorkPadBBP;
		public string WorkPad = "Work Pad";
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			lightBBP.value = agent.GetComponentInChildren<Light>();
			WorkPadBBP = agent.transform.Find(WorkPad);
			if (lightBBP != null && WorkPadBBP.value) return null;
			else return $" agent {this.name} unable to find All refferance";
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
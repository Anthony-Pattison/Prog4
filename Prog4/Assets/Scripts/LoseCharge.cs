using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {
	
	public class LoseCharge : ActionTask {
		public Blackboard agentBlackboard;
		public float Charge;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
            agentBlackboard = agent.GetComponent<Blackboard>();

            if (agentBlackboard != null)
            {
                return null;
            }
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			Charge = agentBlackboard.GetVariableValue<float>("currentCharge");
			Charge = 100;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Charge -= 20 * Time.deltaTime;
			agentBlackboard.SetVariableValue("currentCharge", Charge);

            if (Charge <= 20)
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
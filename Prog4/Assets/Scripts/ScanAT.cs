using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ScanAT : ActionTask {
		public BBParameter<float> ScanRadiusBBP; // add onto any BBparameter a BBP on the end so i dont mess up the blackboard connection
		public BBParameter<Transform> lightTowerTargetBBP;
		public LayerMask ScanLayer;
		public float ScanDuration;
		public Color scanColour;
		public int numberOfScanCirclePoints;

        private float ScanTimer;

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			ScanTimer = 0;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			ScanTimer += Time.deltaTime;
            DrawCircle(agent.transform.position, ScanRadiusBBP.value, scanColour, 12, 1);

            if (ScanTimer > ScanDuration) {
				Collider[] colliders = Physics.OverlapSphere(agent.transform.position, ScanRadiusBBP.value, ScanLayer);
				foreach (Collider collider in colliders)
				{
					IBlackboard blackboard = collider.GetComponentInParent<FSMOwner>().graph.blackboard;
					float RepairValue = blackboard.GetVariableValue<float>("repairValue");
					
					if(RepairValue <= 0)
					{
						lightTowerTargetBBP.value = blackboard.GetVariableValue<Transform>("workpad");
					}
				}
				EndAction(true);
			}
		}

		private void DrawCircle(Vector3 center, float radius, Color colour, int numberOfPoints, float Duration)
		{
			Vector3 startPoint, endPoint;
			int anglePerPoint = 360 / numberOfPoints;
			for (int i = 1; i <= numberOfPoints; i++)
			{
				startPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * (i-1)), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * (i-1)));
				startPoint = center + startPoint * radius;
				endPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * i), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * i));
				endPoint = center + endPoint * radius;
				Debug.DrawLine(startPoint, endPoint, colour, Duration);
			}

			
		}
	}
}
using NodeCanvas.Framework;
using UnityEngine;
using UnityEditor;

namespace NodeCanvas.Tasks.Actions {

	public class MoveObjectAT : ActionTask {

		GameObject MoveableObject;
		float timer;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			MoveableObject = GameObject.FindWithTag("Player");
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            timer = 0;

            //EndAction(true);
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate() {
			MoveableObject.transform.position += 5 * Time.deltaTime * new Vector3(1, 0, 1);
            timer += Time.deltaTime;
			Debug.Log(timer);
            if (timer > 3)
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
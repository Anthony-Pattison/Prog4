using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class CloseDoor : ActionTask {
        public Blackboard HumansBlackboard;
        public Transform ClosetLeft;
        public Transform ClosetRight;
        public BBParameter<bool> startScaring;
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
            bool isWaiting = HumansBlackboard.GetVariable<bool>("waiting").value;
            if (isWaiting == false)
            {
                ClosetLeft.position += new Vector3(5, 0, 0);
                ClosetRight.position += new Vector3(-5, 0, 0);
                startScaring = false;

                EndAction();

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
using UnityEngine;
using NodeCanvas.Framework;
namespace NodeCanvas.Tasks.Actions
{
    public class RepairAT : ActionTask
    {
        public BBParameter<Transform> LightTowerTargetBBP;
        public BBParameter<float> scanRadiusBBP;
        public BBParameter<float> intialScanRadiusBBP;

        public float RepairRateInSeconds = 5f;
        public float FullRepairThreshold = 100f;

        private Blackboard lightTowerBB;
        private float repairValue;

        protected override void OnExecute()
        {
            lightTowerBB = LightTowerTargetBBP.value.GetComponentInParent<Blackboard>();
            repairValue = lightTowerBB.GetVariableValue<float>("repairValue");

            // reset values to start scaning again
            LightTowerTargetBBP.value = null;
            scanRadiusBBP.value = 0;
        }

        protected override void OnUpdate()
        {
            repairValue += RepairRateInSeconds * Time.deltaTime;
            lightTowerBB.SetVariableValue("repairValue", repairValue);

            if (repairValue > FullRepairThreshold)
            {
                EndAction(true);
            }
        }
    }
}

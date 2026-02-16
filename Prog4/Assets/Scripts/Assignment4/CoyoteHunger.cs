using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class CoyoteHunger : ActionTask
    {
        public BBParameter<float> HungerBBP = 100f;
        public BBParameter<bool> FindFoodBBP;
        protected override void OnUpdate()
        {
            if (!FindFoodBBP.value)
            {
                HungerBBP.value -= Time.deltaTime;
            }
        }
    }
}
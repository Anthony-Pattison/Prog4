using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class CoyoteHunger : ActionTask
    {
        public BBParameter<float> Hunger = 100f;
        public BBParameter<bool> FindFood;
        protected override void OnUpdate()
        {

            if (!FindFood.value)
            {
                Hunger.value -= Time.deltaTime;
            }
        }
    }
}
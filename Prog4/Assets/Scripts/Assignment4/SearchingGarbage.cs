using UnityEngine;
using NodeCanvas.Framework;
using System.Runtime.ExceptionServices;
using System.Collections;
namespace NodeCanvas.Tasks.Actions
{
    public class SearchingGarbage : ActionTask
    {
        public BBParameter<bool> IsThereFoodBBP;
        public BBParameter<float> HungerBBP;
        protected override string OnInit()
        {
            StartCoroutine(LookingForFood());
            return base.OnInit();
        }
        protected override void OnUpdate()
        {
            if (IsThereFoodBBP.value)
            {
                EndAction();
            }

            
        }
        protected override void OnStop()
        {
            HungerBBP.value = 100f;
        }
        IEnumerator LookingForFood()
        {
            while (true)
            {
                int timer = 0;
                while (timer <=50)
                {
                    timer++;
                    agent.transform.eulerAngles += new Vector3(0, 20, 0) * Time.deltaTime;
                    yield return null;
                }
                timer = 0;
                yield return new WaitForSeconds(.05f);
                while (timer <= 50)
                {
                    timer++;
                    agent.transform.eulerAngles -= new Vector3(0, 20, 0) * Time.deltaTime;
                    yield return null;
                }
                yield return new WaitForSeconds(.05f);
            }
        }
    }
}
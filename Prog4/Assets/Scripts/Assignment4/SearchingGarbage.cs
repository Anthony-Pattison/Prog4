using UnityEngine;
using NodeCanvas.Framework;
using System.Collections;
namespace NodeCanvas.Tasks.Actions
{
    public class SearchingGarbage : ActionTask
    {
        public BBParameter<bool> TrashFull;
        public BBParameter<float> HungerBBP;
        public BBParameter<bool> FindFoodBBP;
        Coroutine Search;
        protected override string OnInit()
        {
            Search = StartCoroutine(LookingForFood());
            return base.OnInit();
        }
        protected override void OnUpdate()
        {
            
            if (TrashFull.value)
            {
                EndAction();
            }
        }
        protected override void OnStop()
        {
            StopCoroutine(Search);
            HungerBBP.value = 100f;
            FindFoodBBP.value = false;
            TrashFull.value = false;    
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
using UnityEngine;
using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Actions {
    public class ToggleScoutingAT : ActionTask
    {
        public BBParameter<bool> scoutingBBP;
        public AudioSource AS;
        public AudioClip AC;

        protected override void OnExecute()
        {
            scoutingBBP.value = !scoutingBBP.value;

            // play auido clip
            AudioManager.Instance.PlaySoundEffect(AC);
            EndAction();
        }
    }
}

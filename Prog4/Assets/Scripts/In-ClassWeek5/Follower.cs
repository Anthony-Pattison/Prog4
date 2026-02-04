using UnityEditorInternal;
using UnityEngine;
using NodeCanvas.Framework;
public class Follower : MonoBehaviour
{
    public Blackboard blackboard;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Friendly"))
        {
            blackboard.SetVariableValue("SeekTarget", other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Friendly"))
        {
            blackboard.SetVariableValue("SeekTarget", null);
        }
    }
}

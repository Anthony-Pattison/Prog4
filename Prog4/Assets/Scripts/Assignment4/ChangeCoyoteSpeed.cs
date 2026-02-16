using UnityEngine;
using UnityEngine.AI;

public class ChangeCoyoteSpeed : MonoBehaviour
{
    public void SetNavSpeed(float speed)
    {
        print($"Changed Speed to {speed}");
        GetComponent<NavMeshAgent>().speed = speed;
    }
}

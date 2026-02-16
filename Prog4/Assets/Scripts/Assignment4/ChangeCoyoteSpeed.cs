using UnityEngine;
using UnityEngine.AI;

public class ChangeCoyoteSpeed : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void SetNavSpeed(float speed)
    {
        GetComponent<NavMeshAgent>().speed = speed;
    }
}

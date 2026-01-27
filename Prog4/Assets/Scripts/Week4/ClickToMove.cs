using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    public NavMeshAgent navAgent;
    private InputSystem_Actions InputActions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InputActions = new InputSystem_Actions();
        InputActions.Enable();

        InputActions.Player.Attack.performed += OnAttack;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        Ray Mouse = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(Mouse, out RaycastHit hit))
        {
            navAgent.SetDestination(hit.point);
        }
    }


}

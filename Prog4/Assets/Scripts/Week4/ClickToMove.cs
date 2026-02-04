using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    public NavMeshAgent NavAgent;
    private InputSystem_Actions InputActions;
    public LayerMask TerrainLayers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        InputActions = new InputSystem_Actions();
        InputActions.Enable();

        InputActions.Player.Attack.performed += OnAttack;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        Ray MouseRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(MouseRay, out RaycastHit hit, 1f/0f, TerrainLayers))
        {
            NavAgent.SetDestination(hit.point);
        }
    }

    private void OnDisable()
    {
        InputActions.Player.Attack.performed -= OnAttack;
        InputActions.Disable();
    }
}

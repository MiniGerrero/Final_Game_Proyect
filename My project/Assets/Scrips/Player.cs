

using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputPlayer ctrl;
    public float velocidad;
    public Vector2 direcion;
    public Rigidbody2D rigy;
    public LayerMask flootLayer;
    public Transform floorSystem;
    public Vector3 BoxSistem;
    public bool inFloor;
    public float jumpForce;

    
    private void Awake()
    {
        ctrl = new();

    }

    private void OnEnable()
    {
        ctrl.Enable();
        ctrl.Player.Jump.started += _ => Jump();
    }

    private void OnDisable()
    {
        ctrl.Disable();
        ctrl.Player.Jump.started -= _ => Jump();
    }
    
    private void Update()
    {
        direcion = ctrl.Player.Move.ReadValue<Vector2>();
        inFloor = Physics2D.OverlapBox(floorSystem.position, BoxSistem, 0, flootLayer);
    }

    private void FixedUpdate()
    {
        rigy.linearVelocity = new Vector2(direcion.x * velocidad, rigy.linearVelocity.y);
    }
    private void Jump()
    {
        if (inFloor){
            rigy.AddForce(new Vector2 (0, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(floorSystem.position, BoxSistem);
    }

}

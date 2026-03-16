using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Referense")]
    [SerializeField] private Rigidbody2D rigy;
    [SerializeField] private EnemyState enemyState;

    [Header("Movement")]
    [SerializeField] private float baseVelocity;
    [SerializeField] private float actualVelocity;

    [Header("Obtacule Detection")]
    [SerializeField] private Transform controlFront;
    [SerializeField] private LayerMask wallMask;
    [SerializeField] private bool wallTouched;
    [SerializeField] private float distanceLineDetection;



    // Update is called once per frame
    private void start(){
        actualVelocity = baseVelocity;
    }
    private void Update()
    {
        wallTouched = Physics2D.Raycast(controlFront.position, transform.right, distanceLineDetection, wallMask);
    }
    private void FixedUpdate()
    {
        rigy.linearVelocity = new Vector2(actualVelocity, rigy.linearVelocity.y);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controlFront.position, controlFront.position + distanceLineDetection * transform.right);
       
    }
}

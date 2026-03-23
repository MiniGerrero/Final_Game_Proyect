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

    [Header("Damages")]
    public float damage;



    // Update is called once per frame
    private void Start(){
        actualVelocity = baseVelocity;
    }

    private void Update()
    {
        wallTouched = Physics2D.Raycast(controlFront.position, transform.right, distanceLineDetection, wallMask);
    }

    private void FixedUpdate()
    {
        switch (enemyState)
        {
            case EnemyState.Patrol:
                ChangeDirecion();
                break;
            default:
                break;
        }
        rigy.linearVelocity = new Vector2(actualVelocity, rigy.linearVelocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controlFront.position, controlFront.position + distanceLineDetection * transform.right);
       
    }
    
    private void ChangeDirecion()
    {
        if (wallTouched)
        {
            actualVelocity *= -1;

            float rotation = transform.eulerAngles.y == 0 ? 180:0;
            transform.eulerAngles = new Vector3(0, rotation, 0);

        }
    }
}

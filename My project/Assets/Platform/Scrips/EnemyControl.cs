
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Referense")]
    [SerializeField] private Rigidbody2D rigy;
    [SerializeField] private LayerMask player;
    [SerializeField] private Transform playerTransform;

    [Header("Mode State Parameter")]
    [SerializeField] private EnemyState enemyState; // State posible for the enemy
    [SerializeField]private float MaxDistaceDect; // MaxDistace where the enemy will go  to the player for kill it
    [SerializeField]private float lookUpRadios; // Radio that a Enemy will looking for a Enemy
    [Tooltip("You don't have to change those value if don't want, Just put the enemy where you want")]
    [SerializeField]private Vector2 startPoint; // Point Where the enemy will come back, You don't have to touche if you don't want
    
    //Player Detection



    [Header("Movement")]
    [SerializeField] private float baseVelocity; // This will be the max Velocity for the enemy
    [SerializeField] private float actualVelocity; // This is the actual Velocity

    [Header("Obtacule Detection")]
    [SerializeField] private Transform controlFront;
    [SerializeField] private LayerMask wallMask;
    [Tooltip("You can add more Layers if You want")]
    [SerializeField] private bool wallTouched;
    [SerializeField] private float distanceLineDetection;

    [Header("Damages")]
    public float damage;

    [Header("Dead System")]
    [SerializeField] private Vector3 sizeOfBoxKill;
    [SerializeField] private Transform boxKillPosition;
    [SerializeField] private float deadTime = 0;
    private bool isNotAlive;



    // Update is called once per frame
    private void Start()
    
    {
        if (startPoint == Vector2.zero) // This is just when some not is Lazy for assiment a Coordinate
        {
            startPoint = transform.position;
        }

        actualVelocity = baseVelocity;

        
    }

    private void Update()
    {
        wallTouched = Physics2D.Raycast(controlFront.position, transform.right, distanceLineDetection, wallMask );
        isNotAlive = Physics2D.OverlapBox(boxKillPosition.position, sizeOfBoxKill, 0, player);
        Dead();
    }

    private void FixedUpdate(){
        switch (enemyState) // This is for Detect on what state is the Enemy and the case fall will be the function to Ejecute.
        {
            case EnemyState.Patrol:
                StatePatrol();
                break;
            case EnemyState.Waiting:
                StateWait();
                break;
            case EnemyState.Attack:
                PlayerFollow();
                break;
            case EnemyState.ComeBack:
                StateComeBack();
                break;
        }
        
    }

    private void OnDrawGizmos(){ // This is for have a visual for develoment

    
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(boxKillPosition.position , sizeOfBoxKill);

        if (enemyState != EnemyState.Patrol){ // this is for just show the Visual Help when you need it and when not
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookUpRadios);
            Gizmos.color = Color.purple;
            Gizmos.DrawWireSphere(startPoint, MaxDistaceDect);
        }
        else
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(controlFront.position, controlFront.position + distanceLineDetection * transform.right);

        }
    }

    //Posible State Of the enemy Code
    //Enemy Movement
    private void ChangeDirecion() // this is for make Direction change by need it
    {
        actualVelocity *= -1;

        float rotation = transform.eulerAngles.y == 0 ? 180:0; // this is a kind of IF that is saying that if angle is == 0 will do 180, else 0
        transform.eulerAngles = new Vector3(0, rotation, 0); // Don't asking why i didn't this FUE LA UNICA SOLUCION QUE ENCONTRE PARA UN ERROR RARO
    }

    private void Movement()// this is just for Reused on a lot Function
    {
        rigy.linearVelocity = new Vector2(actualVelocity, rigy.linearVelocity.y); // ERE WEBON?, SIGA LEYENDO OTRAS COSAS
    }
    private void StateWait() // This is for enemy that have to wait 
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, lookUpRadios, player);
        if (playerCollider)
        {
            playerTransform = playerCollider.transform;

            enemyState = EnemyState.Attack;
        }
    }
    private void StatePatrol()//PAtrol MODE 
    {
        Movement();
        if (wallTouched) // this is for make a change when the enemy touch the wall
        {
            ChangeDirecion();
        }

    }
    private void PlayerFollow()
    {
        //all this is for the enemy follow the player

        Movement();

        if (playerTransform == null)
        {
            enemyState = EnemyState.ComeBack;
            return;// DON't DELETE THIS
        }

        if (Vector2.Distance(transform.position, startPoint) > MaxDistaceDect || Vector2.Distance(transform.position, playerTransform.position) > MaxDistaceDect)
        {
            enemyState = EnemyState.ComeBack;
            playerTransform = null;
            return; // DON't DELET THIS 

        }
        if ((playerTransform.position.x > transform.position.x && actualVelocity < 0) || (playerTransform.position.x < transform.position.x && actualVelocity > 0))
        {
            ChangeDirecion(); // This is just for make a Direncion change
        }
    }

    private void StateComeBack() // This is for come back to the Inicial position
    {
        Movement();
        if ((startPoint.x > transform.position.x && actualVelocity < 0) || (startPoint.x < transform.position.x && actualVelocity > 0))
        {
            ChangeDirecion();
        }
        if (Vector2.Distance(transform.position, startPoint) < 0.5f)
        {
            enemyState = EnemyState.Waiting;
        
        }
    }

    //Life System
    private void Dead()
    {
        
        if (isNotAlive){
            Debug.Log("He died");
            Destroy(gameObject, deadTime);
        }
    }
}

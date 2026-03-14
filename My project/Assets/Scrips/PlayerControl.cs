
/*If you modificated something please DELETE the Numeral and the ColorDraw that 
by some reason still creating automaticly and without reason
I ALREADY TIRED THAT THIS STILL HAPPEN OMG, I WAS 10 MINUTE LOOKING BY THIS %#@!& ERROR
*/
// If you don't know what mean [SerializeField] this just mean you can modeificate a Privated function on UnityState
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Declaracion Of variable
    
    //Movement of the Player Control X - Y
    private InputPlayer ctrl; //Activading and adding the ctrl Sistem
    [Header("Velocity")]
    [SerializeField]private float velocidad;
    private Vector2 direcion;
    [SerializeField] private Rigidbody2D rigy;

    //All this is for Jump Sistem
    [Header("Jump Sistem")]
    [SerializeField]private LayerMask flootLayer; // this is for know which Layer is for detect the sistem
    [SerializeField]private Transform floorSystem; // this is for detect the floor
    [SerializeField]private Vector3 BoxSistem; // this is for draw and give the size of the Box Detection
    [Tooltip("This is just for Debug")]
    [SerializeField]private bool inFloor; // this is just for know is is touching the ground and activate the jump, maybe a i will adding a extra jump
    [SerializeField]private float jumpForce; 

    //Life Sistem
    [Header("Life System")]
    [SerializeField]private LifeBar lifeBar; // Have a Life Bar Update
    [SerializeField]private float maxLife; // Max Amount of Life(Usually One )
    [Tooltip("Please don't put more life than maxLife, I don't what could happen")]
    [SerializeField]private float amountLife; // Updated the life sistem
    [Tooltip("This is just for Debug")]
    [SerializeField]private bool Alive;
    

    //Function Area

    private void Start(){

        lifeBar.StartLifeSystem(amountLife, maxLife);

    }

    private void Awake() // this are the Declaracion when the Game start
    {
        ctrl = new(); // Para reservar Memoria.

    }

    private void OnEnable() // this is just for activated 
    {
        ctrl.Enable(); // Para activar los controles durantes el juego
        ctrl.Player.Jump.started += _ => Jump(); // Para activar el Button cuando este es precionado, => y esto indica a la funcion que va a llamar
    }

    private void OnDisable()
    {
        ctrl.Disable(); // Para Desactivar los controles
        ctrl.Player.Jump.started -= _ => Jump(); // Para desactivar El Boton de salto
    }
    
    private void Update()
    {
        
        direcion = ctrl.Player.Move.ReadValue<Vector2>();
        inFloor = Physics2D.OverlapBox(floorSystem.position, BoxSistem, 0, flootLayer);
    }

    private void FixedUpdate()
    {
        if (Alive){
            rigy.linearVelocity = new Vector2(direcion.x * velocidad, rigy.linearVelocity.y);
        }

    }
    

    private void Jump() //Jump Sistem
    {

        if (inFloor && Alive){  //This is for avoid the player Jump when isn't on the floor and not Alive

            rigy.AddForce(new Vector2 (0, jumpForce), ForceMode2D.Impulse);

        }

    }

    private void OnDrawGizmos() //this is for draw the box for detext the Ground
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(floorSystem.position, BoxSistem);

    }
    // Life Function

    public void RecoverLife(float RecoverLife){

        if (amountLife < maxLife){
            amountLife += RecoverLife;
        }

        lifeBar.ActualLifeChange(amountLife);
    }

    public void Damage(float Damage){

        if (amountLife > 0 ){
            amountLife -= Damage;
        }else {
            Dead();
        }

        lifeBar.ActualLifeChange(amountLife);

    }

    private void Dead(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}

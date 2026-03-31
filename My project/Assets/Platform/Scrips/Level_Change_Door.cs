using UnityEngine;
using UnityEngine.SceneManagement;

public class LevellChange_Door : MonoBehaviour
{

    [Header("Layers")]
    [Tooltip("If don't work, First Check Layer Name are same")]
    [SerializeField]private string playerLayer = "Player" ; // This is Just the Dafauld Layer
    [Header("Level")]
    [Tooltip("If you are not Adding a Spefisifc level DON'T TOUCH THIS")]
    [SerializeField]private int activeScene;
    private void Start(){
        if (activeScene == 0){
            Debug.Log("Esto Se activado");
            activeScene = SceneManager.GetActiveScene().buildIndex;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D player){

        if ( LayerMask.LayerToName(player.gameObject.layer) == playerLayer){
            LoadLevel();
        }
    }

    private void LoadLevel(){
        SceneManager.LoadScene(activeScene + 1);
    }
}

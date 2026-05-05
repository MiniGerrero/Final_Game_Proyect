using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{

    public void LoadLevel(){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Exiting ... ");
    }
}

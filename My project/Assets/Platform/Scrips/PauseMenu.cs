using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField]private Player actividad;
    public void Resumen()
    {
        if (actividad != null)
        {
            actividad.isPaused = false;
            actividad.pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Exiting ... ");
    }
}

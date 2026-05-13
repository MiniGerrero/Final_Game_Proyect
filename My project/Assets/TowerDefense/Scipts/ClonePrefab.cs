using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ClonePrefab : MonoBehaviour
{
   public GameObject prefab;
   public Camera mainCamera;
   
   public float Money;
   public float MoneySpent;
   public TMP_Text MoneyIndicator;
   public TMP_Text LifeIndicator;
   public int amountLife;
  public GameObject gameOver;
  public int winPoint = 10;
  public int nowPoint = 0;



   public InputAction clickAction;

  void Start()
  {
    Time.timeScale = 1f;
    gameOver.SetActive(false);
  }
   void OnEnable()
   {
    clickAction.Enable();

   }

   void OnDisable()
   {

    clickAction.Disable();

   }



   void Update()
   {
    MoneyIndicator.text = $"Money Amount: {Money:f0}";
    LifeIndicator.text = $"Money Amount: {amountLife:f0}";
    if (clickAction.WasPerformedThisFrame() )
    
    {
      if (Money >= MoneySpent){
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
       
        Instantiate(prefab, mousePos, Quaternion.identity);
        Money = Money-MoneySpent;}
    }
    if (amountLife <= 0)
    {
      Time.timeScale = 0f;
      gameOver.SetActive(true);

    }
    if (winPoint <= nowPoint)
    {
      SceneManager.LoadScene(0);
    }
   }
}

using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ClonePrefab : MonoBehaviour
{
   public GameObject prefab;
   public Camera mainCamera;
   
   public float Money;
   public float MoneySpent;
   public TMP_Text MoneyIndicator;




   public InputAction clickAction;

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
    if (clickAction.WasPerformedThisFrame() )
    
    {
      if (Money >= MoneySpent){
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
       
        Instantiate(prefab, mousePos, Quaternion.identity);
        Money = Money-MoneySpent;}
    }
   }
}

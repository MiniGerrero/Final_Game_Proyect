using UnityEngine;
using UnityEngine.InputSystem;

public class ClonePrefab : MonoBehaviour
{
   public GameObject prefab;
   public Camera mainCamera;
   public int idkplswork = 2;

   
   public float coolTime = 3f;
   private float nextTime = 0;

   public InputAction clickAction;

   void OnEnable()
   {
    clickAction.Enable();
    clickAction.performed += OnClick;
   }

   void OnDisable()
   {
    clickAction.performed -= OnClick;
    clickAction.Disable();
    //Debug.Log("Disabled");
   }
   
   void OnClick(InputAction.CallbackContext context)
   {
   
    Vector2 mousePos = Mouse.current.position.ReadValue();
    Vector3 worldPos = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10)); // 10 units in front of camera
    if (Time.time >= nextTime){
      Instantiate(prefab, worldPos, Quaternion.identity);
      nextTime = Time.time + coolTime;
    }
   }

   void Update()
   {
    if (clickAction.WasPerformedThisFrame())
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Instantiate(prefab, mousePos, Quaternion.identity);
    }
   }
}




using UnityEngine;

public class ClonePrefab : MonoBehaviour
{
   public GameObject prefab;

   void Update()
   {
    if (Input.GetMouseButtonDown(0))
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(prefab, mousePos, Quaternion.identity);
    }
   }
}

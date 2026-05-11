using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    /*void Start() {
        Destroy(gameObject, 3f); //destroys after 5 seconds
    } */

    public new GameObject gameObject;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

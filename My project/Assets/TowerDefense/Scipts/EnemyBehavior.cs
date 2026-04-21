using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //public GameObject gameObject;
    public float Health = 10;

    void Update()
    {
        if (Health <= 0f)
        {
            Destroy (gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Health -= 0.5f;
        }
    }
}

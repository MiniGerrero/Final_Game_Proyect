using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //public GameObject gameObject;
    public float Health = 10;
    //Define Enemy Prefab
    public GameObject EnemyPrefab;
    public float DamageRecived = 0.5f;

    //Checks if health is at or below 0
    void Update()
    {
        if (Health <= 0f)
        {
            Destroy (gameObject);
        }
    }

    //Checks if collision is a bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Health -= DamageRecived;
        }
    }



    /*void OnEnable()
    {
        //Listen for Spawn Event from GameTiming.cs
        GameTiming.Spawn += Update;
    }

    void OnDisable()
    {
        //Un-listen to prevent memory leaks
        GameTiming.Spawn -= Update;
    }*/




}

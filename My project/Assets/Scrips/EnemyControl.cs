using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Referense")]
    [SerializeField] private Rigidbody2D rigy;
    [SerializeField] private EnemyState enemyState;

    [Header("Movement")]
    [SerializeField] private float baseVelocity;
    [SerializeField] private float actualVelocity;


    // Update is called once per frame
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {

    }
}

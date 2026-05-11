using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float range = 5f; //How far to look
    public float fireRate = 1f; //Seconds between shots
    float fireCooldown = 0f;
    public GameObject projectilePrefab; //Assign in Inspector
    public float projectileSpeed = 10f;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        //Find All Colliders with "Enemy" tag in range
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range);
        GameObject nearestEnemy = null;
        float minDist = Mathf.Infinity;

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                float dist = Vector2.Distance(transform.position, hit.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    nearestEnemy = hit.gameObject;
                }
            }
        }

        //if enemy found, aim and shoot
        if (nearestEnemy != null && fireCooldown <= 0f) 
        {
            Vector2 direction = (nearestEnemy.transform.position - transform.position).normalized;
            float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 90;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            GameObject proj = Instantiate(projectilePrefab, transform.position, /*Quaternion.identity,*/ Quaternion.Euler(0,0,angle));
            proj.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileSpeed;
            fireCooldown = fireRate; //Reset timer
            //Destroy(proj, 3.0f);
        }
    }
}
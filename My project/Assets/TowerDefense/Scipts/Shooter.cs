using System.Collections; // REQUISITO: Necesario para usar Corrutinas (IEnumerator)
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Animator animator; 
    public float range = 5f; 
    public float fireRate = 1f; 
    float fireCooldown = 0f;
    public GameObject projectilePrefab; 
    public float projectileSpeed = 10f;
    [SerializeField] private LayerMask enemyLayer; 

    // NUEVO: Tiempo de espera desde que empieza la animación hasta que sale la bala
    [SerializeField] private float retrasoDisparo = 0.2f; 

    private bool estaDisparando = false; // Evita que se inicien múltiples corrutinas a la vez

    void Update()
    {
        if (fireCooldown > 0f)
        {
            fireCooldown -= Time.deltaTime;
        }

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);
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

        if (nearestEnemy != null) 
        {
            // Apuntar siempre al enemigo
            Vector2 direction = (nearestEnemy.transform.position - transform.position).normalized;
            float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // Iniciar la secuencia de disparo si el arma está lista y no hay otra secuencia activa
            if (fireCooldown <= 0f && !estaDisparando)
            {
                StartCoroutine(SecuenciaDisparo(direction, angle));
            }
        }
    }

    // NUEVO: Corrutina que maneja el tiempo de espera
    private IEnumerator SecuenciaDisparo(Vector2 direccionBala, float anguloBala)
    {
        estaDisparando = true;
        fireCooldown = fireRate; // Bloquea el temporizador de inmediato

        // 1. Activar la animación de ataque
        animator.SetBool("IsShooting", true);

        // 2. ESPERAR: Detiene este código por los segundos configurados (ej. 0.2s)
        yield return new WaitForSeconds(retrasoDisparo);

        // 3. DISPARAR: Crear el proyectil después de la espera
        GameObject proj = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, anguloBala));
        proj.GetComponent<Rigidbody2D>().linearVelocity = direccionBala * projectileSpeed;

        // 4. Apagar la animación (puedes ajustar esta espera si la animación es más larga)
        animator.SetBool("IsShooting", false);
        
        estaDisparando = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

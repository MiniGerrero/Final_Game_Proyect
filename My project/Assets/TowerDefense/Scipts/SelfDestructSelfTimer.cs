using UnityEngine;

public class TimedDestruction : MonoBehaviour
{
    public float DestroyAfter = 1;
    void Start()
    {
        // This will delete the GameObject 5 seconds after it spawns
        Destroy(gameObject, DestroyAfter);
    }
}

using UnityEngine;

public class SineMovement : MonoBehaviour
{
    public float amplitude = 1f; // Wave Height (max distances)
    public float frequency = 1f; // Wave Frequency
    public float speed = 1f; // How fast time goes 
    public float sineIncrement = 1f; // Multiples Y
    public float cosineIncrement = 1f; // Multiply X

    private Vector3 startPos; // Create pos. recorder 

    void Start()
    {
        startPos = transform.position; // Save starting pos.
    }

    void Update()
    {
        float t = Time.time * speed;

        float x = Mathf.Cos(t * frequency) * amplitude * cosineIncrement;
        float y = Mathf.Sin(t * frequency) * amplitude * sineIncrement;

        transform.position = startPos + new Vector3(x, y, 0);
    }
}

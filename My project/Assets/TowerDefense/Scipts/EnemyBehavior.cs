using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.Events;

public class EnemyBehavior : MonoBehaviour
{
    #region Variables
    public float Health = 10;
    //public GameObject EnemyPrefab; //Define Enemy Prefab
    public float DamageRecived = 0.5f; //Damage taken on impact
    public UnityEvent OnSplineFinished;
    private SplineAnimate splineAnimate;
    private bool hasTriggered = false;
    #endregion

    void Start() //sets boolean (i think)
    {
        splineAnimate = GetComponent<SplineAnimate>();}

    void Update() //Checks status
    {
        if (!splineAnimate.IsPlaying && !hasTriggered && splineAnimate == true) //checks if touching end
        {
            hasTriggered = true;
            OnSplineFinished?.Invoke();
            //Debug.Log("pls Work crying rn");
            Destroy(gameObject);}

        if (Health <= 0f) //Checks if health is at or below 0
        {
            Destroy (gameObject);}}

    private void OnCollisionEnter2D(Collision2D collision) //Checks if collision is a bullet
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Health -= DamageRecived;
        }}

//#region junkCode1

    /*[SerializeField] private SplineAnimate splineAnimate;

    void OnEnable()
    {
        //Listen for line completion
        if (splineAnimate != null)
            splineAnimate.Completed += OnSplineFinished;
    }

    void OnDisable()
    {
        //unsub to prevent memo leaks
        if (splineAnimate != null)
            splineAnimate.Completed -= OnSplineFinished;
    }

    private void OnSplineFinished()
    {
        Debug.Log("fin");
        Destroy (gameObject);
    }*/
//#region junkCode2
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

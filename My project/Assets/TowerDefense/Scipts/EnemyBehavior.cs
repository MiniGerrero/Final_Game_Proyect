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
    [SerializeField]private int amounMoney;
    [SerializeField]private int loseLife;
    [SerializeField]private string towerManagementName;
    private GameObject towerManage;
    private ClonePrefab moneySitem;
    #endregion

    void Start() //sets boolean (i think)
    {
        towerManage = GameObject.Find(towerManagementName);
        splineAnimate = GetComponent<SplineAnimate>();
        moneySitem = towerManage.GetComponent<ClonePrefab>();
    }

    void Update() //Checks status
    {
        if (!splineAnimate.IsPlaying && !hasTriggered && splineAnimate == true) //checks if touching end
        {
            hasTriggered = true;
            OnSplineFinished?.Invoke();
            moneySitem.amountLife -= loseLife;
            Destroy(gameObject);}

        if (Health <= 0f) //Checks if health is at or below 0
        {
            moneySitem.Money += amounMoney; 
            moneySitem.nowPoint += 1;
            Destroy (gameObject);}}

    private void OnCollisionEnter2D(Collision2D collision) //Checks if collision is a bullet
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Health -= DamageRecived;
        }}


}

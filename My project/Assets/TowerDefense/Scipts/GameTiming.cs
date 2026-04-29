using System;
using UnityEngine;

public class GameTiming : MonoBehaviour
{
    // Enemy spawner
    public GameObject EnemyPrefab;
    public float startWait = 2.0f;
    public float Wait = 2.0f;
    // public static event Action Spawn;

    void Start() {
        // Start after _ seconds, repeat every _ seconds
        InvokeRepeating("SpawnNewEnemy", startWait, Wait);
    }

    void SpawnNewEnemy() {
        GameObject clone = Instantiate(EnemyPrefab);
    }



    /*public void Spawned()
    {
        //trigger & check null for no listeners
        Spawn?.Invoke();
        
        }*/
}

    /*[ContextMenu("Run Function")]
    void MyFunction() {
        Debug.Log("Yay");
    }*/
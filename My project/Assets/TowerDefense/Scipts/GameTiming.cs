using System;
using UnityEngine;

public class GameTiming : MonoBehaviour
{
    // Enemy spawner
    public GameObject EnemyPrefab;
    public float startWait = 2.0f;
    public float Wait = 2.0f;
    public int[] EnemyRound;
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

/*
        OnStart() {
        int VarIndex = 1
        }

        Update();
        RepeatIndex = read item (VarIndex) of EnemyRound

        repeat(RepeatIndex) {
            clone EnemyPrefab
            wait 2 seconds
        }*/

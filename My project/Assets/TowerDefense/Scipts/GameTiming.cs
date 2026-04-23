using System;
using UnityEngine;

public class GameTiming : MonoBehaviour
{
    public static event Action Spawn;

    public void Spawned()
    {
        Spawn?.Invoke();
    }
}

    /*[ContextMenu("Run Function")]
    void MyFunction() {
        Debug.Log("Yay");
    }*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PoolManager poolManager;
    public ZombieManager zombieManager;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }
    }
}

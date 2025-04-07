using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{

    public List<GameObject> zombieList;


    public void AddZombie(GameObject zombie)
    {
        zombieList.Add(zombie);
    }
    public void RemoveZombie(GameObject zombie)
    {
        zombieList.Remove(zombie);
    }
}

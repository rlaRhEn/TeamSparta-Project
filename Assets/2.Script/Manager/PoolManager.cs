using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string key;
        public GameObject prefab;
    }

    public Pool[] pools;

    private Dictionary<string, List<GameObject>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, List<GameObject>>();

        foreach (var pool in pools)
        {
            poolDictionary.Add(pool.key, new List<GameObject>());
        }
    }

    public GameObject SpawnFromPool(string key, Transform parent = null)
    {
        if (!poolDictionary.ContainsKey(key)) return null;

        foreach (var obj in poolDictionary[key])
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        var prefab = pools.FirstOrDefault(p => p.key == key)?.prefab;
        if (prefab == null) return null;

        var newObj = Instantiate(prefab, parent);
        poolDictionary[key].Add(newObj);
        return newObj;
    }
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.rotation = Quaternion.identity;
        obj.transform.SetParent(this.transform);
        if (obj.TryGetComponent<Rigidbody2D>(out var rigid))
            rigid.velocity = Vector2.zero;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float attackPower;

    [SerializeField]
    private float destroyTime;
    private void OnEnable()
    {
        
        destroyTime = 0;
        gameObject.SetActive(true);
    }
    private void Update()
    {
        destroyTime += Time.deltaTime;
        if(destroyTime >= 3)
        {
            ProjectileSetActive();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(collision.transform.position);
            collision.GetComponent<Zombie>()?.TakeDamage(attackPower,pos); 
            ProjectileSetActive();
        }
       

    }
    void ProjectileSetActive()
    {
        GameManager.Instance.poolManager.ReturnToPool(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField]
    private float attackRange, attackSpeed, attackTimer , attackPower;
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform firePoint;

    int bulletCount = 5;
    float spreadAngle = 30f;
    public Hero hero;

    private Transform target;
    HeroAnimationController animationController;

    private void Awake()
    {
        animationController = GetComponent<HeroAnimationController>();
    }


    public void SerachTarget()
    {
        //animationController.IdleAni();
        float closetDistance = Mathf.Infinity;
        Transform closetTarget = null;

        foreach(GameObject zombie in GameManager.Instance.zombieManager.zombieList)
        {
            if (!zombie.activeSelf) continue;
            float distance = Vector3.Distance(zombie.transform.position, transform.position);
            if(distance <= attackRange && distance <= closetDistance)
            {
                closetDistance = distance;
                closetTarget = zombie.transform;
            }
        }
      

        if(closetTarget != null)
        {
            target = closetTarget;
            hero.ChangeState(BaseState.state.attack);
        }
    }
    public void AttackTarget()
    {

        if(target == null || !target.gameObject.activeSelf)
        {
           
            hero.ChangeState(BaseState.state.move);
        }
        attackTimer += Time.deltaTime;
        if(attackTimer > attackSpeed)
        {
            animationController.ShootAni();
            FireShot();
            attackTimer = 0;

        }
    }
    
    public void FireShot()
    {
        if (target == null) return;
        Vector2 dir = (target.position - firePoint.position).normalized;
        float baseAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;  // 기준
        float startAngle = baseAngle - (spreadAngle / 2f);            // 시작
        float angleStep = spreadAngle / (bulletCount - 1);            // 각도

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = startAngle + (angleStep * i);
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            GameObject projectile = GameManager.Instance.poolManager.SpawnFromPool("Projectile");
            projectile.transform.position = firePoint.transform.position;
            projectile.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.right * 10f;
            projectile.GetComponent<Projectile>().attackPower = attackPower;
        }
    }
}

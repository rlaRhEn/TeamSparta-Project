using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ZombieMovement), typeof(ZombieAnimationController))]

public class Zombie : BaseState
{
    [SerializeField]
    private float hp;

    float maxHp = 10;

    Canvas canvas;
    ZombieMovement zombieMovement;
    ZombieAnimationController animationController;
    private void Awake()
    {
        zombieMovement = GetComponent<ZombieMovement>();
        animationController = GetComponent<ZombieAnimationController>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }
    protected override void Start()
    {
        base.Start();

        hp = maxHp;
    }
    private void OnEnable()
    {
        hp = maxHp;
        ChangeState(BaseState.state.move);
        gameObject.SetActive(true);
    }
    protected override void StateMachine()
    {
        switch (currentState)
        {
            case state.move:
                zombieMovement.Movement();
                animationController.PlayMove();
                break;
            case state.jump:
                zombieMovement.Jump();
                break;
            case state.attack:

                break;
            case state.dead:
                animationController.PlayDead();
                Invoke("Dead", 1f);
                break;

        }
    }
    public void TakeDamage(float damage, Vector3 hitPos)
    {
        hp -= damage;
        GameObject damageText = GameManager.Instance.poolManager.SpawnFromPool("DamageText");
        Vector3 screenPos = Camera.main.WorldToScreenPoint(hitPos);
        damageText.transform.position = hitPos;
        damageText.transform.SetParent(canvas.transform);
        damageText.GetComponent<Text>().text = damage.ToString();

        if (hp <= 0)
        {
            hp = 0;
            ChangeState(state.dead);
        }
    }
    void Dead()
    {
        GameManager.Instance.poolManager.ReturnToPool(this.gameObject);
        GameManager.Instance.zombieManager.RemoveZombie(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ZombieMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    Zombie zombie;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float attackRange;
  
    private float jumpPower;
    private float jumpCooldown; // 점프 쿨타임 1초
    private float lastJumpTime = -1f; // 마지막 점프 시간
    private float raycastDistance ; // Raycast 거리 설정

    private GameObject lastHitZombie; // 마지막으로 감지된 오브젝트 저장
    [SerializeField]
    bool isJump ;
    bool isDead;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        zombie = GetComponent<Zombie>();
    }
    private void Start()
    {
        raycastDistance = 0.3f;
        jumpPower = 5f;
        jumpCooldown = 1f;
    }
    private void Update()
    {
        CheckFrontZombie();
    }
    void CheckFrontZombie()
    {
        Vector2 rayOrigin = new Vector2(transform.position.x - 0.3f, transform.position.y + 0.2f);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.left, raycastDistance);
        Debug.DrawRay(rayOrigin, Vector2.left * raycastDistance, Color.red);

        if (hit.collider != null)
        {
            Zombie frontzombie = hit.collider.GetComponent<Zombie>();
            if(frontzombie != null )
            {
                if (Time.time >= lastJumpTime + jumpCooldown) // 점프 쿨타임 체크
                {
                    if (hit.collider.gameObject == lastHitZombie)
                    {
                        return;
                    }
                    lastHitZombie = frontzombie.gameObject;
                    CompareZombieList(frontzombie);
                }
            }
        }
    }

    void CompareZombieList(Zombie frontZombie)
    {
        int myIndex = GameManager.Instance.zombieManager.zombieList.IndexOf(gameObject); 
        int frontIndex = GameManager.Instance.zombieManager.zombieList.IndexOf(frontZombie.gameObject);
        
        if(myIndex >= frontIndex)
        {
            zombie.ChangeState(BaseState.state.jump);
        }
    }

    public void Movement()
    {
        rigid.velocity = new Vector2(-speed, rigid.velocity.y);
    }
    public void Jump() //앞에놈과 비교해서 본인이 리스트 뒤면 점프 점프실행
    {
        rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
        lastJumpTime = Time.time; // 마지막 점프 시간 업데이트

        zombie.ChangeState(BaseState.state.move);
    }
    public void Attack()
    {

    }

}

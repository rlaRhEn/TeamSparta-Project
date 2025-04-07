using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovementManager : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float deceleration;

    private float originSpeed; // ó�� �ӵ�
    private bool isStop;

    public float MoveSpeed => moveSpeed;

    private void Start()
    {
        originSpeed = moveSpeed;
    }
    private void Update()
    {
        DecelerationTruck();
    }
    void DecelerationTruck() 
    {
        if(isStop && moveSpeed > 0)
        {
            moveSpeed -= deceleration * Time.deltaTime;
            moveSpeed = Mathf.Max(moveSpeed, 0);
        }
    }
    public void StopTruck() => isStop = true; //Ư�� ��� Ȥ�� ���� ����� �ε����� �������

    public void ResetSpeed()
    {
        moveSpeed = originSpeed;
        isStop = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 moveDirection = Vector2.left;
    [SerializeField]
    private float scrollRange;
    [SerializeField]
    private TruckMovementManager truckManager;
    void Update()
    {
        BackGroundMoving();
    }
    void BackGroundMoving() 
    {
        transform.position += moveDirection * truckManager.MoveSpeed * Time.deltaTime;

        if(transform.position.x <= -scrollRange)
        {
            transform.position = target.position + Vector3.right * scrollRange;
        }
    }
}

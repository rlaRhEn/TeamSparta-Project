using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject wheelF, wheelB;
    [SerializeField]
    private TruckMovementManager truckManager;

    private int collisionCount;
    private bool isReset; //코루틴 중복실행 방지

    // Update is called once per frame
    void Update()
    {
        WheelMoving();
    }

    void WheelMoving() //적한테 막히면 멈춰야함
    {
        float rotateSpeed = -truckManager.MoveSpeed * 100f * Time.deltaTime;
        wheelF.transform.Rotate(new Vector3(0, 0, rotateSpeed));
        wheelB.transform.Rotate(new Vector3(0, 0, rotateSpeed));
    }

    IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        truckManager.ResetSpeed();
        isReset = false;
    }

    bool TargetLayer(int layer)
    {
        return layer == 10 || layer == 11 || layer == 12;
    }
    /// <summary>
    /// 좀비 많을 시 이동 멈추기 ※필요시 사용
    /// </summary>
    /// <param name="collision"></param>
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (TargetLayer(collision.gameObject.layer))
    //    {
    //        collisionCount++;
    //        if (collisionCount >= 3)
    //        {
    //            truckManager.StopTruck();
    //        }

    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (TargetLayer(collision.gameObject.layer))
    //    {
    //        collisionCount--;
    //        if (collisionCount < 3 && !isReset)
    //        {
    //            isReset = true;
    //            StartCoroutine(ResetSpeedAfterDelay(1f));
    //        }
    //    }
    //}
}

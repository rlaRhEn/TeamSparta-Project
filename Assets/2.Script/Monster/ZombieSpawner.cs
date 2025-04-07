using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]private Transform[] lane;

    [SerializeField]
    private int zombieCount;

    private void Start()
    {
        StartCoroutine(SpawnMonster());
    }


    IEnumerator SpawnMonster()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1,3));
            int randomIndex = Random.Range(0, zombieCount);  //zombie�������� �þ�� ī��Ʈ�߰�
            int randomLane = Random.Range(0, lane.Length);

            string poolKey = "Zombie_" + randomIndex;

            GameObject zombie = GameManager.Instance.poolManager.SpawnFromPool(poolKey);
            zombie.transform.position = new Vector3(lane[randomLane].position.x, lane[randomLane].position.y, lane[randomLane].position.z + randomLane); //���̾� ����
            zombie.gameObject.layer = randomLane + 10;
            GameManager.Instance.zombieManager.AddZombie(zombie);
        }
    }
}

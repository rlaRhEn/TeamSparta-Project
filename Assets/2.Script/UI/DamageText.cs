using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    private float alphaSpeed;
    [SerializeField]
    private Text text;
    [SerializeField]
    private Color alpha;

    void Start()
    {
        alphaSpeed = 2f;

        alpha = text.color;

      
    }
    private void OnEnable()
    {
        gameObject.SetActive(true);
        alpha.a = 255;
        Invoke("ActiveFalse", 1f);
    }

    void Update()
    {
        transform.position += new Vector3(0, 1f, 0);

        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        text.color = alpha;
    }

    void ActiveFalse()
    {
        GameManager.Instance.poolManager.ReturnToPool(this.gameObject);
    }
}

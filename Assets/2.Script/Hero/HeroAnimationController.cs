using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimationController : MonoBehaviour
{
    Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }
    public void ShootAni()
    {
        ani.SetBool("Shoot", true);
    }
    public void IdleAni()
    {
        ani.SetBool("Shoot", false);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimationController : MonoBehaviour
{
    Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    public void PlayMove()
    {
        ani.SetBool("IsIdle", true);
        ani.SetBool("IsDead", false);
    }
    
    public void PlayDead()
    {
        ani.SetBool("IsIdle", false);
        ani.SetBool("IsDead", true);
    }
    public void PlayAttack()
    {

    }

}

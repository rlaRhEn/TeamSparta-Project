using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HeroController),typeof(HeroAnimationController))]

public class Hero : BaseState
{

    HeroController heroController;
   

    private void Awake()
    {
        heroController = GetComponent<HeroController>();
       
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void StateMachine()
    {
        switch (currentState)
        {
            case state.move:
                heroController.SerachTarget();
               
                break;
            case state.attack:
                heroController.AttackTarget();
            
                break;
        }
    }
}

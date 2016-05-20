using UnityEngine;
using System.Collections;
using GameFrame;

public class EnermyAnimation : GameBehaviour
{
    Animator m_animator = null;

    protected override void Init()
    {
        m_animator = GetComponent<Animator>();
      //  AttackAnimation();
    }

    public void StandAnimation()
    {
       
    }

    public void MoveAnimation()
    {
       
    }

    public void AttackAnimation()
    {    
        m_animator.CrossFade("Attack", 0);                            
    }

    public void BeAttackedAnimation()
    {
       
    }

    public void DieAnimation()
    {
       
    }
}

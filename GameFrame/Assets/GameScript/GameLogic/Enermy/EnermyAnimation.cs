using UnityEngine;
using System.Collections;
using GameFrame;

public class EnermyAnimation : GameBehaviour
{
    Animator m_animator = null;

    float t = 0;
    protected override void Init()
    {
        m_animator = GetComponent<Animator>();
        Tools.AddAnimatorEvent(m_animator, "FlowerAttack", "EndAttackAnimation");
    }
    /// <summary>
    /// 默认动画，其它动画执行完后，自动执行此动画
    /// </summary>
    public void StandAnimation()
    {
        m_animator.SetBool("stand", true);
    }

    void TestAnimatorEvent()
    {
        Debug.Log("TestAnimatorEvent:" + gameObject.name);
    }

    public void MoveAnimation()
    {
        m_animator.SetBool("move", true);
        m_animator.SetBool("attack", false);
        m_animator.SetBool("stand", false);
    }
    public void EndMoveAnimation()
    {
        m_animator.SetBool("move", false);
        m_animator.SetBool("stand", true);
    }

    public void AttackAnimation()
    {
       m_animator.SetBool("attack", true);
    }

    public void EndAttackAnimation()
    {
      //  Debug.Log(gameObject.name + ":end enermy attack");
        m_animator.SetBool("attack", false);
    }
    public void BeAttackedAnimation()
    {
       
    }

    public void DieAnimation()
    {
       
    }

    public void Update()
    {
        //t += Time.deltaTime;
        //if (t > 3)
        //{
        //    AttackAnimation();
        //    t = 0;
        //}
        //else
        //{
        //    StandAnimation();
        //}
    }
}

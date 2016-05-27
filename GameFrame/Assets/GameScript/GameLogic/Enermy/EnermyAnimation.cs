using UnityEngine;
using System.Collections;
using GameFrame;

public class EnermyAnimation : GameBehaviour
{
    Animator m_animator = null;
    AnimatorStateSetting m_stateSetting = new AnimatorStateSetting();
    float t = 0;
    protected override void Init()
    {
        m_animator = GetComponent<Animator>();

        m_stateSetting.SetAnimator(m_animator);

       // Tools.AddAnimatorEvent(m_animator, "FlowerAttack", "EndAttackAnimation");

        m_stateSetting.AddBoolState("stand");
        m_stateSetting.AddBoolState("move");
        m_stateSetting.AddBoolState("attack");
        m_stateSetting.AddBoolState("beAttacked");
        m_stateSetting.AddBoolState("die");
    }
    /// <summary>
    /// 默认动画，其它动画执行完后，自动执行此动画
    /// </summary>
    public void StandAnimation()
    {
        m_stateSetting.SetBool("stand");
    }

    void TestAnimatorEvent()
    {
        Debug.Log("TestAnimatorEvent:" + gameObject.name);
    }

    public void MoveAnimation()
    {
        m_stateSetting.SetBool("move");
    }
    public void EndMoveAnimation()
    {
        StandAnimation();
    }

    public void AttackAnimation()
    {
        m_stateSetting.SetBool("attack");
    }

    public void EndAttackAnimation()
    {
      //  Debug.Log(gameObject.name + ":end enermy attack");
       // m_animator.SetBool("attack", false);
        m_stateSetting.SetBool("");
    }
    public void BeAttackedAnimation()
    {
        m_stateSetting.SetBool("beAttacked");
    }

    public void DieAnimation()
    {
        m_stateSetting.SetBool("die");
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

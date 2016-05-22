using UnityEngine;
using System.Collections;
using GameFrame;

public class HeroAnimation : GameBehaviour
{
    Animator m_animator = null;
    
    protected override void Init()
    {
        m_animator = GetComponent<Animator>();
       // m_animator.
    }

    public void StandAnimation()
    {
        if (m_animator != null)
        {
            m_animator.SetBool("standToRun", false);
        }
    }

    public void MoveAnimation()
    {
        if (m_animator != null)
        {
            m_animator.SetBool("standToRun", true);
        }
    }

    public void AttackAnimation(HeroAttackType attackType)
    {
        //点击普通攻击按钮时，无法判断攻击类型，触发普通攻击动画
        //HeroAttackType.Attack1和HeroAttackType.Attack2类型在特效函数中分发消息参数 
        if (attackType == HeroAttackType.None)
        {
            PlayAttackAnimation();
        }
        else if (attackType == HeroAttackType.Skill1)
        {
            PlaySkill1Animation();
        }
        else if (attackType == HeroAttackType.Skill2)
        {
            PlaySkill2Animation();
        }
        else if (attackType == HeroAttackType.Skill3)
        {
            PlaySkill3Animation();
        }            
    }

    /// <summary>
    /// 普通攻击动画
    /// </summary>
    void PlayAttackAnimation()
    {
        if (m_animator != null)
        {
            m_animator.SetTrigger("attack");
            iTween.MoveBy(this.gameObject, Vector3.forward * 2, 0.4f);
        }
    }

    void PlaySkill1Animation()
    {

    }

    void PlaySkill2Animation()
    {

    }

    void PlaySkill3Animation()
    {

    }
}

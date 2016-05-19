using UnityEngine;
using System.Collections;
using GameFrame;

public class HeroAnimation : GameBehaviour
{
    Animator m_animator = null;
    
    protected override void Init()
    {
        m_animator = GetComponent<Animator>();
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
        Debug.Log("HeroMovingAnimation: Move");
        if (m_animator != null)
        {
            m_animator.SetBool("standToRun", true);
        }
    }

    public void AttackAnimation(HeroAttackType attackType)
    {
        if (attackType == HeroAttackType.Attack1 || attackType == HeroAttackType.Attack2)
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
            iTween.MoveBy(this.gameObject, Vector3.forward * 3, 0.4f);
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

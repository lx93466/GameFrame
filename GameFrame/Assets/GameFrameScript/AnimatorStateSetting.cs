using UnityEngine;
using System.Collections.Generic;

namespace GameFrame
{
    class AnimatorStateSetting
    {
        HashSet<string> m_state = new HashSet<string>();

        Animator m_animator = null;

        public void AddBoolState(string stateBool)
        {
            m_state.Add(stateBool);
        }

        public void SetAnimator(Animator animator)
        {
            m_animator = animator;
        }

        public void SetBool(string stateBool = "", bool b = true)
        {
            if (m_animator != null)
            {
                foreach (var item in m_state)
                {
                    if (item == stateBool)
                    {
                        m_animator.SetBool(item, b);
                    }
                    else
                    {
                        m_animator.SetBool(item, !b);
                    }
                }
            }
        }
    }
}

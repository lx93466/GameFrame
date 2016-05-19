using UnityEngine;
using System.Collections;
using GameFrame;

public class Effect : GameBehaviour
{
    private NcCurveAnimation[] m_curveAnimArray;
   
    Renderer[] m_rendererArray;


    protected override void Init()
    {
        base.Init();
       
        m_curveAnimArray = this.GetComponentsInChildren<NcCurveAnimation>();
     
        m_rendererArray = GetComponentsInChildren<Renderer>();

        gameObject.SetActive(false);
    }

    public void ShowEffect()
    {
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }
        if (m_curveAnimArray != null)
        {
            foreach (NcCurveAnimation anim in m_curveAnimArray)
            {
                anim.ResetAnimation();
            }
        }

        if (m_rendererArray != null)
        {
            foreach (Renderer renderer in m_rendererArray)
            {
                renderer.enabled = true;
            }
        }       
    }
}

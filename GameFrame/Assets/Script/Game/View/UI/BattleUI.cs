using UnityEngine;
using GameFrame;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BattleUI : UIBase
{
    float m_coldTime1 = 2;
    float m_coldTime2 = 2;
    float m_coldTime3 = 2;

    float m_curColdTime1 = 0;
    float m_curColdTime2 = 0;
    float m_curColdTime3 = 0;

    int m_timerId1 = 0;
    int m_timerId2 = 0;
    int m_timerId3 = 0;

    Transform m_filledSkill1;
    Transform m_filledSkill2;
    Transform m_filledSkill3;

    TimerManager m_timerManager = TimerManager.GetInstance();

    protected override void BeforeOpen()
    {
        m_path = "UIPrefab";

        m_file = "BattleUI";

        m_containBackgroud = false;

        m_closeAllPreUI = true;
    }

    protected override void AftertOpen()
    {
        RegisterUIEvent("Skill0", OnSkill0);
        RegisterUIEvent("Skill1", OnSkill1);
        RegisterUIEvent("Skill2", OnSkill2);
        RegisterUIEvent("Skill3", OnSkill3);

        RegisterUIEvent("Skill0", ClickDown, null, UIEventType.onClickDown);
        RegisterUIEvent("Skill1", ClickDown, null, UIEventType.onClickDown);
        RegisterUIEvent("Skill2", ClickDown, null, UIEventType.onClickDown);
        RegisterUIEvent("Skill3", ClickDown, null, UIEventType.onClickDown);

        RegisterUIEvent("Skill0", ClickUp, null, UIEventType.onClickUp);
        RegisterUIEvent("Skill1", ClickUp, null, UIEventType.onClickUp);
        RegisterUIEvent("Skill2", ClickUp, null, UIEventType.onClickUp);
        RegisterUIEvent("Skill3", ClickUp, null, UIEventType.onClickUp);


        m_filledSkill1 = m_root.Find("Skill1/FilledImage");
        m_filledSkill2 = m_root.Find("Skill2/FilledImage");
        m_filledSkill3 = m_root.Find("Skill3/FilledImage");
    }

    public static BattleUI GetInstance()
    {
        return Singleton<BattleUI>.GetInstance();
    }

    private void OnSkill0(PointerEventData data)
    {
    //    MsgManager.GetInstance().DispatchMsg(PlayerMsg.attack1Msg);
        Debug.Log("OnSkill0");
    }

    private void OnSkill1(PointerEventData data)
    {
        if (m_filledSkill1 != null)
        {
            float filedCount = m_filledSkill1.GetComponent<Image>().fillAmount;
            if (filedCount > 0.001)
            {
                Debug.Log("The skill is colding.");
            }
            else if(filedCount < 0.001)
            {
                m_curColdTime1 = 0;
                m_filledSkill1.GetComponent<Image>().fillAmount = 1;
                m_timerId1 = m_timerManager.GetTimerID();
                m_timerManager.Schedule(ColdSkill1, m_timerId1, 0.05f);
            }           
        }
    } 
    
    private void OnSkill2(PointerEventData data)
    {
        if (m_filledSkill2 != null)
        {
            float filedCount = m_filledSkill2.GetComponent<Image>().fillAmount;
            if (filedCount > 0.001)
            {
                Debug.Log("The skill is colding.");
            }
            else if (filedCount < 0.001)
            {
                m_curColdTime2 = 0;
                m_filledSkill2.GetComponent<Image>().fillAmount = 1;
                m_timerId2 = m_timerManager.GetTimerID();
                m_timerManager.Schedule(ColdSkill2, m_timerId2, 0.05f);
            }
        }
    }
    
    private void OnSkill3(PointerEventData data)
    {
        if (m_filledSkill3 != null)
        {
            float filedCount = m_filledSkill3.GetComponent<Image>().fillAmount;
            if (filedCount > 0.001)
            {
                Debug.Log("The skill is colding.");
            }
            else if (filedCount < 0.001)
            {
                m_curColdTime3 = 0;
                m_filledSkill3.GetComponent<Image>().fillAmount = 1;
                m_timerId3 = m_timerManager.GetTimerID();
                m_timerManager.Schedule(ColdSkill3, m_timerId3, 0.05f);
            }
        }
    }

    private void ColdSkill1()
    {
        if (m_coldTime1 > m_curColdTime1)
        {
            float filledAmount = (m_coldTime1 - m_curColdTime1) / m_coldTime1;
            if (filledAmount < 0.001)
            {
                m_filledSkill1.GetComponent<Image>().fillAmount = 0;
                m_timerManager.Unschedule(m_timerId1);
            }
            else
            {
                m_filledSkill1.GetComponent<Image>().fillAmount = filledAmount;
                m_curColdTime1 += 0.05f / m_coldTime1; 
            }          
        }
        else
        {
            m_filledSkill1.GetComponent<Image>().fillAmount = 0;
            m_timerManager.Unschedule(m_timerId1);
        }
    }

    private void ColdSkill2()
    {
        if (m_coldTime2 > m_curColdTime2)
        {
            float filledAmount = (m_coldTime2 - m_curColdTime2) / m_coldTime2;
            if (filledAmount < 0.001)
            {
                m_filledSkill2.GetComponent<Image>().fillAmount = 0;
                m_timerManager.Unschedule(m_timerId2);
            }
            else
            {
                m_filledSkill2.GetComponent<Image>().fillAmount = filledAmount;
                m_curColdTime2 += 0.05f / m_coldTime2;
            }
        }
        else
        {
            m_filledSkill2.GetComponent<Image>().fillAmount = 0;
            m_timerManager.Unschedule(m_timerId2);
        }
    }

    private void ColdSkill3()
    {
        if (m_coldTime3 > m_curColdTime3)
        {
            float filledAmount = (m_coldTime3 - m_curColdTime3) / m_coldTime3;
            if (filledAmount < 0.001)
            {
                m_filledSkill3.GetComponent<Image>().fillAmount = 0;
                m_timerManager.Unschedule(m_timerId3);
            }
            else
            {
                m_filledSkill3.GetComponent<Image>().fillAmount = filledAmount;
                m_curColdTime3 += 0.05f / m_coldTime3;
            }
        }
        else
        {
            m_filledSkill3.GetComponent<Image>().fillAmount = 0;
            m_timerManager.Unschedule(m_timerId3);
        }
    }

    private void ClickDown(PointerEventData data)
    {
        data.pointerPress.transform.localScale = new Vector3(1, 1, 1) * 1.1f;
        Debug.Log(data.pointerPress.transform.localScale);
    }

    private void ClickUp(PointerEventData data)
    {
        data.pointerPress.transform.localScale = new Vector3(1, 1, 1);
        Debug.Log(data.pointerPress.transform.localScale);
    }
}

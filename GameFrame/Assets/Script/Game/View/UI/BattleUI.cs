using UnityEngine;
using GameFrame;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BattleUI : UIBase
{
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
    }

    public static BattleUI GetInstance()
    {
        return Singleton<BattleUI>.GetInstance();
    }

    private void OnSkill0(PointerEventData data)
    {
        Debug.Log("OnSkill0");
    }

    private void OnSkill1(PointerEventData data)
    {
       Debug.Log("OnSkill1");
    } 
    
    private void OnSkill2(PointerEventData data)
    {
        Debug.Log("OnSkill2");
    }
    
    private void OnSkill3(PointerEventData data)
    {
        Debug.Log("OnSkill3");
    }
}

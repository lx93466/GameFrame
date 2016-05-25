using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameFrame;

public class HpBar : GameBehaviour {
    Transform m_uiRoot = null;

    RectTransform CreateHp(Vector3 position, float totalHp, float curHp, string roleName)
    {
        Transform hpBars = m_uiRoot.Find("RoleBars");
        RectTransform hpBarRectTransform = null;
        if (hpBars != null)
        {
            GameObject prefabObject = ResourceManager.GetInstance().LoadAsset("UIPrefab/HpBar");
            hpBarRectTransform = GameObject.Instantiate(prefabObject).GetComponent<RectTransform>();
            hpBarRectTransform.Find("Name").GetComponent<Text>().text = roleName;
            hpBarRectTransform.gameObject.name = roleName;
            hpBarRectTransform.Find("Progress").GetComponent<Image>().fillAmount = curHp / totalHp;

            hpBarRectTransform.position = Camera.main.WorldToScreenPoint(position);

            hpBarRectTransform.parent = hpBars;
        }
        return hpBarRectTransform;
    }

    public void UpdateHp(Vector3 position, float totalHp, float curHp, string roleName)
    {
        if (m_uiRoot == null)
        {
            m_uiRoot = BattleUI.GetInstance().m_root;
        }
        if (m_uiRoot != null)
        {
            Transform hpBarTransform = m_uiRoot.Find("RoleBars/" + roleName);
            if (hpBarTransform == null)
            {
                hpBarTransform = CreateHp(position, totalHp, curHp, roleName);
            }
            hpBarTransform.Find("Progress").GetComponent<Image>().fillAmount = curHp / totalHp;
            hpBarTransform.position = Camera.main.WorldToScreenPoint(position);
            hpBarTransform.localScale = Vector3.one;
        }
    }
    public void Disappear(string roleName)
    {
        Transform hpBarTransform = m_uiRoot.Find("RoleBars/" + roleName);
        if (hpBarTransform != null)
        {
            GameObject.Destroy(hpBarTransform.gameObject);
        }
    }
}

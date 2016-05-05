using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScalerSetup : EditorMonoBehaviour
{
    public override void Update()
    {
       // Debug.Log ("每一帧回调一次");
    }

    public override void OnPlaymodeStateChanged(PlayModeState playModeState)
    {
       // Debug.Log ("游戏运行模式发生改变， 点击 运行游戏 或者暂停游戏或者 帧运行游戏 按钮时触发: " + playModeState);
    }

    public override void OnGlobalEventHandler(Event e)
    {
        //Debug.Log("OnGlobalEventHandler:全局事件回调: " + e);
    }

    public override void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        //Debug.Log(string.Format("HierarchyWindowItemOnGUI:{0}xxx : {1}yyy - {2}zzz", EditorUtility.InstanceIDToObject(instanceID), instanceID, selectionRect));
        GameObject go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (go != null)
        {
            CanvasScaler scaler = go.GetComponent<CanvasScaler>();
            if (scaler != null)
            {
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = new Vector2(1280, 720);
            }
        }
    }

    public override void OnHierarchyWindowChanged()
    {
        //Debug.Log("OnHierarchyWindowChanged:层次视图发生变化");
    }

    public override void OnModifierKeysChanged()
    {
        //Debug.Log("OnModifierKeysChanged:当触发键盘事件");
    }

    public override void OnProjectWindowChanged()
    {
        //Debug.Log("OnProjectWindowChanged:当资源视图发生变化");
    }

    public override void ProjectWindowItemOnGUI(string guid, Rect selectionRect)
    {
        //根据GUID得到资源的准确路径
        //Debug.Log(string.Format("ProjectWindowItemOnGUI:{0} : {1} - {2}", AssetDatabase.GUIDToAssetPath(guid), guid, selectionRect));
    }
}
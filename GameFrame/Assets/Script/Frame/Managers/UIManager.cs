using UnityEngine;
using System.Collections;
namespace GameFrame
{
    public class UIManager : Singleton<UIManager>
    {
        public void LockScreen()
        {
            Tools.LockScreen(); 
        }
        public void UnlockScreen()
        {
            Tools.UnlockScreen();
        }
    }
}

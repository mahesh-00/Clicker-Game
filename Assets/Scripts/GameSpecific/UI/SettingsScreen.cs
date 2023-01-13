using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Clicker
{
    public class SettingsScreen : CanvasView
    {

        #region Button-click Methods
        public void UIEVENT_ResumeGame()
        {
            UIManager.Instance.OnGameResumed();
        }

        public void UIEVENT_MenuClicked()
        {
            UIManager.Instance.OnMenuClicked?.Invoke();
        }

        public void UIEVENT_ExitGame()
        {
            Application.Quit();
        }
        #endregion

    }
}

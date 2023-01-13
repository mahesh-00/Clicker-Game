
namespace Clicker
{
    public class GameScreen : CanvasView
    {

        #region Button-click Methods
        public void UIEVENT_SettingsClicked()
        {
            UIManager.Instance.OpenSettingsMenu();
        }
        #endregion

    }
}

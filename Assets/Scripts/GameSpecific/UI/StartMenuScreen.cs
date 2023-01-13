
namespace Clicker
{
    public class StartMenuScreen : CanvasView
    {
        #region Button-click Methods
        public void UIEVENT_StartGame()
        {
            GameManager.Instance.IsGameStarted = true;
        }
        #endregion
    }
}

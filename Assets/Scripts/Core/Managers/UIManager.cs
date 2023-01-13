using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static Clicker.GameManager;

namespace Clicker
{
    public class UIManager : MonoBehaviour
    {
        #region  Static fields
        private static UIManager _instance;
        #endregion

        #region Properties
        public static UIManager Instance => _instance;
        #endregion

        #region Editor-Assigned variables
        [SerializeField] private CanvasView _startMenuScreen, _gameScreen, _settingsScreen;
        #endregion

        #region Event variables
        public Action OnScreenClicked;
        public Action OnMenuClicked;
        #endregion


        #region Monobehaviour
        // Start is called before the first frame update
        void Awake()
        {
            if(_instance==null)
                _instance = this;
            else
                Destroy(this);
            GameManager.Instance.OnGameStateChanged += HandleGameStateChangeUI;
            //OnMenuClicked+= OpenStartMenu;
        }

        void OnDisable() 
        {
            GameManager.Instance.OnGameStateChanged -= HandleGameStateChangeUI;
            //OnMenuClicked -= OpenStartMenu;
        }
        #endregion

        #region Methods
        public void HandleGameStateChangeUI(GameState newState)
        {
            switch (newState)
            {
                case GameState.StartMenuState:
                    HandleStartMenuState();
                    break;
                case GameState.GamePlayState:
                    HandleGameplayState();
                    break;
                case GameState.GameCompleteState:
                    //HandleLevelCompleteState();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

        }

        private void ShowRespectiveUIForState(CanvasView currentUIState, CanvasView newUIState)
        {
            currentUIState?.ShowView(false);
            newUIState?.ShowView(true);
        }

        private void HandleGameplayState() => ShowRespectiveUIForState(_startMenuScreen, _gameScreen);

        private void HandleStartMenuState() => ShowRespectiveUIForState(_gameScreen, _startMenuScreen);

        public void OnGameResumed() => ShowRespectiveUIForState(_settingsScreen, _gameScreen);

        public void OpenStartMenu() 
        {
            ShowRespectiveUIForState(_settingsScreen, _startMenuScreen);
            _gameScreen.ShowView(false);
        }

        public void OpenSettingsMenu() => ShowRespectiveUIForState(null, _settingsScreen);
        #endregion

    }
}

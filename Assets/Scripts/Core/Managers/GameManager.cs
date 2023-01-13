using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class GameManager : MonoBehaviour
    {
        #region Static fields
        private static GameManager _instance;

        #endregion

        #region Properties
        public static GameManager Instance => _instance;
        public bool IsGameStarted
        {
            get { return _isGameStarted; }
            set
            {
                _isGameStarted = value;
                if (value)
                {
                    ChangeState(GameState.GamePlayState);
                }
            }

        }
        #endregion

        #region Other variables
        public enum GameState
        {
            StartMenuState,
            GamePlayState,
            GameCompleteState
        }

        private GameState _currentGameState;
        private bool _isGameStarted = false;
        public Action<GameState> OnGameStateChanged;
        #endregion

        #region Monobehaviour
        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this);
            Application.targetFrameRate = 300;

        }
        // Start is called before the first frame update
        void Start()
        {
            ChangeState(GameState.StartMenuState);
            Screen.SetResolution(1080, 1920, true);
        }
        #endregion

        #region Methods
        public void ChangeState(GameState newState)
        {
            _currentGameState = newState;
            switch (newState)
            {
                case GameState.StartMenuState:
                    HandleStartMenuState();
                    break;
                case GameState.GamePlayState:
                    HandleGameplayState();
                    break;
                case GameState.GameCompleteState:
                    HandleLevelCompleteState();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            OnGameStateChanged?.Invoke(newState);
        }

        private void HandleLevelCompleteState()
        {

        }

        private void HandleStartMenuState()
        {

        }

        private void HandleGameplayState()
        {

        }
        #endregion

    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace Clicker
{
    public class ScoreHandler : MonoBehaviour
    {
        #region Editor-Assigned variables
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _highScoreText;
        #endregion

        #region Other variables
        private int _score = 0;
        #endregion

        #region Monobehaviour
        void OnEnable()
        {
            UIManager.Instance.OnScreenClicked += UpdateScore;
           UIManager.Instance.OnMenuClicked += ResetScore;
            _highScoreText.text = "HIGHSCORE "+ PlayerPrefs.GetInt("HIGHSCORE", 0).ToString();
        }

        void OnDisable()
        {
            UIManager.Instance.OnScreenClicked -= UpdateScore;
            UIManager.Instance.OnMenuClicked -= ResetScore;
        }
        #endregion

        #region Methods
        private void UpdateScore()
        {
            _score += 1;
            _scoreText.text = _score.ToString();
            if (PlayerPrefs.GetInt("HIGHSCORE") < _score)
            {
                StringBuilder highScoreString = new StringBuilder();
                highScoreString.Append("HIGHSCORE " + _score);
                _highScoreText.text = highScoreString.ToString();
                PlayerPrefs.SetInt("HIGHSCORE", _score);
            }
        }

        private void ResetScore()
        {
            _score = 0;
            _scoreText.text = _score.ToString();
            UIManager.Instance.OpenStartMenu();
        }
        #endregion
    }
}

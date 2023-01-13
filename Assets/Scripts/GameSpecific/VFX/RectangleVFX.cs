using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
    public class RectangleVFX : MonoBehaviour
    {
        #region Editor-Assigned variables
        [SerializeField] private float _animationDuration;
        #endregion

        #region Other variables
        private Sequence _sequence;
        private Image _clickImage;
        #endregion



        #region  Monobehaviour
        void OnEnable()
        {
            _clickImage = GetComponent<Image>();
            _sequence = DOTween.Sequence();
            _sequence.Append(gameObject.transform.DOScale(Vector3.one, _animationDuration));
            _sequence.Join(_clickImage.DOFade(0, _animationDuration)).SetDelay(0).onComplete += () =>
            {
                _clickImage.DOFade(1, 0.1f);
                gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            };
        }
        #endregion
    }
}
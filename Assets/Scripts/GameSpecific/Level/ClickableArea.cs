using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

namespace Clicker
{
    public class ClickableArea : MonoBehaviour, IPointerDownHandler
    {
        #region Methods
        public void OnPointerDown(PointerEventData eventData)
        {
            GameObject _clickEffectGO = ObjectPooler.Instance.SpawnObjectFromPool("RectangleBox");
            _clickEffectGO.transform.position = eventData.pointerCurrentRaycast.screenPosition;
            _clickEffectGO.transform.parent = this.transform;
            UIManager.Instance.OnScreenClicked?.Invoke();
        }
        #endregion
    }
}

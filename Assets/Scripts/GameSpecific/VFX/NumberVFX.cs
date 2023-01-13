using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace Clicker
{
public class NumberVFX : MonoBehaviour
{
    private TextMeshProUGUI _clickedText;
    [SerializeField] private float _animationDuration;

    private Sequence sequence;
    // Start is called before the first frame update
    void OnEnable()
    {
        _clickedText = GetComponent<TextMeshProUGUI>();
        sequence = DOTween.Sequence();
        sequence.Append(_clickedText.DOFade(0, _animationDuration)).onComplete += () => _clickedText.DOFade(1,0.2f);
        // sequence.Join(_clickedText.transform.DOMove(gameObject.transform.position + new Vector3(0, 0), _animationDuration)).SetDelay(0).onComplete += () =>
        // {
        //     _clickedText.DOFade(1,0.2f);
        // };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}

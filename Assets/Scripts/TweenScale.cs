using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace DottweenExample
{
    internal sealed class TweenScale : MonoBehaviour
    {
        [SerializeField] private ScaleParams _tweenParamsShow;
        [SerializeField] private ScaleParams _tweenParamsHide;
        [Space(10.0f)]
        [SerializeField] private float _interval = 0.5f;
        private RectTransform _rectTransform;
        private Tweener _tweener;
        
        private IEnumerator Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            while (true)
            {
                yield return new WaitForSeconds(_interval);
                Move(_tweenParamsShow);
                yield return new WaitForSeconds(_interval * 2);
                Move(_tweenParamsHide);
            }
        }

        private void OnDisable()
        {
            _tweener?.Kill();
        }

        private void Move(ScaleParams scaleParams)
        {
            _tweener?.Kill();
            _tweener = _rectTransform
                .DOScale(scaleParams.Target, scaleParams.Duration)
                .SetDelay(scaleParams.Delay)
                .SetEase(scaleParams.Ease);
        }
    }
}

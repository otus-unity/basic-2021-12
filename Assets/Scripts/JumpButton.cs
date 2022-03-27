using DG.Tweening;
using UnityEngine;

namespace DottweenExample
{
    internal sealed class JumpButton : MonoBehaviour
    {
        // [SerializeField] private GameObject _bullet;
        [SerializeField] private float _jumpPower = 10.0f;
        [SerializeField] private float _duration = 1.0f;
        [SerializeField] private float _interval = 5.0f;
        private RectTransform _rectTransform;

        private Sequence _sequence;
        
        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            var endPos = _rectTransform.anchoredPosition;
            _sequence = DOTween.Sequence();
            _sequence.Append(_rectTransform.DOJumpAnchorPos(endPos, _jumpPower, 1, _duration));
            _sequence.AppendInterval(_interval);
            _sequence.SetLoops(-1);
        }

        private void OnEnable()
        {
            _sequence.Play();
        }

        private void OnDisable()
        {
            _sequence.Pause();
        }

        private void OnDestroy()
        {
            _sequence = null;
        }

        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.Space))
        //     {
        //         GameObject instantiate = Instantiate(_bullet);
        //         var component = instantiate.GetOrAddComponent<Rigidbody>();
        //         component.AddForce(Vector3.up * 999.0f);
        //     }
        // }
    }
}

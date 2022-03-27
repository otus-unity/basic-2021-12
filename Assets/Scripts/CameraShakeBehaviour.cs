using DG.Tweening;
using UnityEngine;

namespace DottweenExample
{
    public sealed class CameraShakeBehaviour : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private float _strength;
        [SerializeField] private int _vibrato;
        [Range(0.0f, 90.0f)]
        [SerializeField] private float _randomness;
        private Transform _cameraTransform;

        private void OnValidate()
        {
            _cameraTransform = Camera.main.transform;
        }

        [ContextMenu("CreateShake")]
        private void CreateShake()
        {
            Tweener tweener = DOTween.Shake(() => _cameraTransform.position, 
                pos => _cameraTransform.position = pos,
                _duration, _strength, _vibrato, _randomness);
        }
    }
}

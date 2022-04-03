using UnityEngine;

namespace Saver
{
    internal sealed class SaverController : MonoBehaviour
    {
        [SerializeField] private KeyCode _saveCode = KeyCode.Space;
        [SerializeField] private KeyCode _loadCode = KeyCode.Return;
        private PlayerController _player;
        private PlayerDataRepository _repository;

        private void Start()
        {
            _player = FindObjectOfType<PlayerController>();
            _repository = new PlayerDataRepository();
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(_saveCode))
            {
                _repository.Save(_player);
            }
            if (Input.GetKeyDown(_loadCode))
            {
                _repository.Load(_player);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Data/Wepon")]
    public sealed class WeaponData : ScriptableObject
    {
        #region New ScriptableObject

        [Serializable]
        private class WeaponsData
        {
            public Weapon Type;
            public GameObject Prefab;
        }

        [SerializeField] private List<WeaponsData> _weaponsData;

        #endregion
        
        [SerializeField] private Weapon weapon;

        public Weapon Weapon => weapon;

        public void CreateWeapon(Transform root)
        {
            
        }
    }
}

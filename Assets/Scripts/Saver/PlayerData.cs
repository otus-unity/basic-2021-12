using System;
using UnityEngine;

namespace Saver
{
    [Serializable]
    public sealed class PlayerData
    {
        public string Name;
        public Vector3Serializable Position;
        public bool IsEnabled;
        public override string ToString()
        {
            return
                $"<color=red>Name</color> {Name} <color=red>Position</color> {Position} <color=red>IsVisible</color> {IsEnabled}";
        }
    }
}

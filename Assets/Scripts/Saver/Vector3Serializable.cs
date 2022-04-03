using System;
using UnityEngine;

namespace Saver
{
    [Serializable]
    public struct Vector3Serializable
    {
        public float X;
        public float Y;
        public float Z;

        private Vector3Serializable(float valueX, float valueY, float valueZ)
        {
            X = valueX;
            Y = valueY;
            Z = valueZ;
        }
        
        public static implicit operator Vector3(Vector3Serializable value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }
        
        public static explicit operator Vector3Serializable(Vector3 value)
        {
            return new Vector3Serializable(value.x, value.y, value.z);
        }

        public static Vector3Serializable operator +(Vector3Serializable a, Vector3Serializable b)
        {
            return new Vector3Serializable
            {
                X = a.X + b.X,
                Y = a.X + b.X,
                Z = a.X + b.X,
            };
        }
        
        public override string ToString() => $" (X = {X} Y = {Y} Z = {Z})";
    }
}

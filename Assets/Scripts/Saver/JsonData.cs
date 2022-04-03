using System.IO;
using UnityEngine;

namespace Saver
{
    internal sealed class JsonData<T> : IData<T>
    {
        public void Save(T data, string path)
        {
            string dataString = JsonUtility.ToJson(data);
            // File.WriteAllText(path, dataString);
            File.WriteAllText(path, Crypto.CryptoXOR(dataString));
        }
        
        public T Load(string path)
        {
            string readAllText = File.ReadAllText(path);
            // return JsonUtility.FromJson<T>(readAllText);
            return JsonUtility.FromJson<T>(Crypto.CryptoXOR(readAllText));
        }
    }
}

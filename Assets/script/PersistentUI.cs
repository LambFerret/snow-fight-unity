using System;
using UnityEngine;

namespace script
{
    public class PersistentUI : MonoBehaviour
    {
        private static PersistentUI _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
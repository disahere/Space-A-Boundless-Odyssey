using UnityEngine;

namespace CodeBase.Gameplay
{
    public class DontDestroyOnLoadScript : MonoBehaviour
    {
        private static DontDestroyOnLoadScript _instance;

        void Awake()
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
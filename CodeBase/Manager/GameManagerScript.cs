using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Manager
{
    public class GameManagerScript : MonoBehaviour
    {
        private static GameManagerScript _instance;

        public static GameManagerScript Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject gameManagerObject = new GameObject("GameManager");
                    _instance = gameManagerObject.AddComponent<GameManagerScript>();
                    DontDestroyOnLoad(gameManagerObject);
                }

                return _instance;
            }
        }

        public FPSCounter fpsCounterPrefab;
        public FPSCounter FPSCounterInstance { get; private set; }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);

            if (fpsCounterPrefab != null)
            {
                FPSCounterInstance = Instantiate(fpsCounterPrefab, transform);
                
                FPSCounterInstance.gameObject.SetActive(true);

                Canvas fpsCanvas = FPSCounterInstance.GetComponentInChildren<Canvas>();

                if (fpsCanvas != null)
                {
                    DontDestroyOnLoad(fpsCanvas.gameObject);
                }
                else
                {
                    Debug.LogError("Canvas component not found in FPSCounter prefab.");
                }
                
                fpsCounterPrefab.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("fpsCounterPrefab is not assigned in GameManagerScript.");
            }
        }
    }
}
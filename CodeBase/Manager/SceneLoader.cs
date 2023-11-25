using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Manager
{
    public class SceneLoader : MonoBehaviour
    {
        private static SceneLoader _instance;

        [SerializeField] private string sceneToLoad;
        [SerializeField] private float defaultLoadDelay;
        [SerializeField] private bool autoLoadScene;

        public static event Action SceneLoaded;

        public static SceneLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject("SceneLoader").AddComponent<SceneLoader>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
                return _instance;
            }
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneLoaded?.Invoke();
            if (autoLoadScene)
            {
                LoadSceneWithDelay();
            }
        }

        public void LoadSceneWithDelay()
        {
            StartCoroutine(LoadSceneCoroutine(sceneToLoad, defaultLoadDelay));
        }

        private IEnumerator LoadSceneCoroutine(string sceneName, float loadDelay)
        {
            if (loadDelay < 0)
            {
                loadDelay = defaultLoadDelay;
            }

            yield return new WaitForSeconds(loadDelay);

            SceneManager.LoadScene(sceneName);
        }
    }
}
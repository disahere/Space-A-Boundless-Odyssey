using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Manager
{
    public class ButtonManager : MonoBehaviour
    {
        private bool _isPaused;
        public TextMeshProUGUI pauseMessage;
        
        private void Start()
        {
            UpdateButtonState();
            pauseMessage.gameObject.SetActive(false);
        }
        
        private void UpdateButtonState()
        {
            pauseMessage.gameObject.SetActive(_isPaused);
        }
        
        public void TogglePause()
        {
            _isPaused = !_isPaused;
            
            UpdateButtonState();

            if (_isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        private static void PauseGame()
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }

        private static void ResumeGame()
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }
        
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

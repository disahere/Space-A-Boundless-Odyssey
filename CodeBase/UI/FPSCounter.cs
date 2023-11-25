using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class FPSCounter : MonoBehaviour
    {
        public TextMeshProUGUI fpsText;

        private void Update()
        {
            DisplayFPS();
        }

        private void DisplayFPS()
        {
            if (fpsText != null)
            {
                float deltaTime = Time.unscaledDeltaTime;
                fpsText.text = "FPS: " + (int)(1.0f / deltaTime);
            }
        }
    }
}
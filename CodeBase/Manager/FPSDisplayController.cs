using CodeBase.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Manager
{
    public class FPSDisplayController : MonoBehaviour
    {
        public Toggle fpsToggle;

        private GameObject _fpsDisplay;

        private void Start()
        {
            if (GameManagerScript.Instance != null)
            {
                FPSCounter fpsCounter = GameManagerScript.Instance.FPSCounterInstance;

                if (fpsCounter != null)
                {
                    _fpsDisplay = fpsCounter.gameObject;
                    fpsToggle.isOn = _fpsDisplay.activeSelf;
                    fpsToggle.onValueChanged.AddListener(OnToggleValueChanged);
                }
                else
                {
                    Debug.LogError("FPSCounter component not found in GameManagerScript.");
                }
            }
            else
            {
                Debug.LogError("GameManagerScript.Instance is null.");
            }
        }

        private void OnToggleValueChanged(bool newValue)
        {
            if (_fpsDisplay != null)
            {
                _fpsDisplay.SetActive(newValue);
            }
        }
    }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Manager
{
    public class GraphicsSettingsManager : MonoBehaviour
    {
        public Dropdown qualityDropdown;

        private static GraphicsSettingsManager _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);

                qualityDropdown.ClearOptions();
                qualityDropdown.AddOptions(new List<string>(QualitySettings.names));

                int savedQualityLevel = PlayerPrefs.GetInt("QualityLevel", QualitySettings.GetQualityLevel());
                qualityDropdown.value = savedQualityLevel;

                SetQualityLevel(savedQualityLevel);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetQualityLevel(int qualityLevel)
        {
            QualitySettings.SetQualityLevel(qualityLevel);

            PlayerPrefs.SetInt("QualityLevel", qualityLevel);
            PlayerPrefs.Save();
        }
        
        public void ApplySettingsImmediately()
        {
            SetQualityLevel(qualityDropdown.value);
        }
    }
}
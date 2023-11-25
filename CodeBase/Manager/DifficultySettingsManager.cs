using CodeBase.Movement;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Manager
{
    public class DifficultySettingsManager : MonoBehaviour
    {
        public delegate void DifficultyChanged(DifficultyLevel difficulty);
        public static event DifficultyChanged OnDifficultyChanged;

        public Dropdown difficultyDropdown;

        private static DifficultySettingsManager _instance;

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
            
            LoadDifficultyLevel();
        }

        public void SetDifficultyLevel()
        {
            DifficultyLevel selectedDifficulty = (DifficultyLevel)difficultyDropdown.value;
            
            SaveDifficultyLevel(selectedDifficulty);
            
            ApplyDifficultyLevel(selectedDifficulty);

            OnDifficultyChanged?.Invoke(selectedDifficulty);

            Debug.Log("Difficulty set to: " + selectedDifficulty);
        }

        private void ApplyDifficultyLevel(DifficultyLevel difficulty)
        {
            Debug.Log($"Setting difficulty to: {difficulty}");

            MovingPlatform[] platforms = FindObjectsOfType<MovingPlatform>();

            foreach (var platform in platforms)
            {
                switch (difficulty)
                {
                    case DifficultyLevel.Easy:
                        platform.moveSpeed = 3f;
                        break;
                    case DifficultyLevel.Medium:
                        platform.moveSpeed = 5f;
                        break;
                    case DifficultyLevel.Hard:
                        platform.moveSpeed = 7f;
                        break;
                    case DifficultyLevel.Impossible:
                        platform.moveSpeed = 10f;
                        break;
                    default:
                        platform.moveSpeed = 5f;
                        break;
                }

                Debug.Log($"Platform {platform.name} speed set to: {platform.moveSpeed}");
            }
        }

        private void SaveDifficultyLevel(DifficultyLevel difficulty)
        {
            PlayerPrefs.SetInt("DifficultyLevel", (int)difficulty);
            PlayerPrefs.Save();
        }

        private void LoadDifficultyLevel()
        {
            if (PlayerPrefs.HasKey("DifficultyLevel"))
            {
                int savedDifficulty = PlayerPrefs.GetInt("DifficultyLevel");
                difficultyDropdown.value = savedDifficulty;
                DifficultyLevel selectedDifficulty = (DifficultyLevel)savedDifficulty;
                ApplyDifficultyLevel(selectedDifficulty);
            }
        }
    }
}
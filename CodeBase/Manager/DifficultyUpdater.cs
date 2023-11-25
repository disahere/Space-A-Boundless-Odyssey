using CodeBase.Movement;
using UnityEngine;

namespace CodeBase.Manager
{
    public class DifficultyUpdater : MonoBehaviour
    {
        private MovingPlatform[] _platforms;

        private void Start()
        {
            _platforms = FindObjectsOfType<MovingPlatform>();
        }

        private void OnEnable()
        {
            DifficultySettingsManager.OnDifficultyChanged += UpdatePlatforms;
        }

        private void OnDisable()
        {
            DifficultySettingsManager.OnDifficultyChanged -= UpdatePlatforms;
        }

        private void UpdatePlatforms(DifficultyLevel difficulty)
        {
            float newSpeed = GetSpeedForDifficulty(difficulty);

            foreach (var platform in _platforms)
            {
                platform.UpdateSpeed(newSpeed);
            }
        }

        private float GetSpeedForDifficulty(DifficultyLevel difficulty)
        {
            switch (difficulty)
            {
                case DifficultyLevel.Easy:
                    return 3f;
                case DifficultyLevel.Medium:
                    return 5f;
                case DifficultyLevel.Hard:
                    return 7f;
                case DifficultyLevel.Impossible:
                    return 10f;
                default:
                    return 5f;
            }
        }
    }
}
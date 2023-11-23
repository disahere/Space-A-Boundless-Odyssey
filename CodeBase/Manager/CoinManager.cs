using TMPro;
using UnityEngine;

namespace CodeBase.Manager
{
    public class CoinManager : MonoBehaviour
    {
        public static CoinManager Instance => _instance;
        public TextMeshProUGUI coinCountText;
        
        private static CoinManager _instance;
        private static int _totalCoinCount;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            _totalCoinCount = 0;
            UpdateCoinCountText();
        }

        public void CollectCoin()
        {
            _totalCoinCount++;
            UpdateCoinCountText();
        }

        private void UpdateCoinCountText()
        {
            if (coinCountText != null)
            {
                coinCountText.text = $"{_totalCoinCount}";
            }
        }
    }
}
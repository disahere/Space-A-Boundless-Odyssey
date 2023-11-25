using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Gameplay
{
    public class GeoChecker : MonoBehaviour
    {
        void Start()
        {
            
            string countryCode = NativeControl.Instance().GetCountryCode();
            
            Debug.Log($"Country code: {countryCode}");
            
            if (countryCode.Equals("UA"))
            {
                LoadMainScene();
            }
            else
            {
                OpenWikipediaSite();
            }
        }
        
        private void LoadMainScene()
        {
            SceneManager.LoadScene("Menu");
        }
        
        private void OpenWikipediaSite()
        {
            Application.OpenURL("https://uk.wikipedia.org/");
        }
    }
}

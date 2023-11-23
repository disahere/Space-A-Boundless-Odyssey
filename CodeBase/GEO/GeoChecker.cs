using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.GEO
{
    public class GeoChecker : MonoBehaviour
    {
        void Start()
        {
            string countryCode = GetCountryCode();
            if (countryCode.Equals("UA"))
            {
                LoadMainScene();
            }
            else
            {
                OpenWikipediaSite();
            }
        }
        
        private string GetCountryCode()
        {
            return "UA";
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

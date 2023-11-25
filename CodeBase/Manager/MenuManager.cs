using UnityEngine;

namespace CodeBase.Manager
{
    public class MenuManager : MonoBehaviour
    {
        public GameObject menuCanvas;
        public Animator cameraAnimator;

        private void Start()
        {
            menuCanvas.SetActive(false);
        }

        public void ShowMenu()
        {
            menuCanvas.SetActive(true);
            cameraAnimator.SetTrigger("ShowMenu");
        }

        public void HideMenu()
        {
            menuCanvas.SetActive(false);
            cameraAnimator.SetTrigger("HideMenu");
        }
    }
}

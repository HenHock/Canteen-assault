using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PanelController : MonoBehaviour
    {
    
        public GameObject uiInLevel;

        [SerializeField] private GameObject prevPanel;

        public void Close()
        {
            if (DataManager.uIController != null)
                DataManager.uIController.sceneIgnoring.SetActive(false);
            if (DataManager.activePanel != null) {
                DataManager.activePanel.SetActive(false);
                DataManager.activePanel = null;
            }

            if (prevPanel != null)
                prevPanel.GetComponent<PanelController>().Open();
        }

        public void Open()
        {
            if (DataManager.activePanel != null)
                DataManager.activePanel.GetComponent<PanelController>().Close();

            DataManager.activePanel = gameObject;

            if (DataManager.uIController != null)
                DataManager.uIController.sceneIgnoring.SetActive(true);
        
            gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            if (SceneManager.GetActiveScene().name.Equals("Main menu"))
                UIController.onBlurAction(true);
            else
            {
                UIManager.OnBlurAction(true);
                uiInLevel?.SetActive(false);
            }
        }

        private void OnDisable()
        {
            if (SceneManager.GetActiveScene().name.Equals("Main menu"))
                UIController.onBlurAction(false);
            else
            {
                UIManager.OnBlurAction(false);
                uiInLevel?.SetActive(true);
            }
        }
    }
}

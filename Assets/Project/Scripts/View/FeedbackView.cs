using TMPro;
using UnityEngine;

namespace Project.Scripts.View
{
    public class FeedbackView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _feedbackInputField;
        [SerializeField] private GameObject _loadingPanel;
        [SerializeField] private GameObject _successPanel;
        [SerializeField] private GameObject _errorPanel;
        
        public string FeedbackText => _feedbackInputField.text;

        public void ShowLoading()
        {
            SetVisibleAllPanels(false);
            _loadingPanel.SetActive(true);
        }
        
        public void ShowSuccess()
        {
            SetVisibleAllPanels(false);
            _successPanel.SetActive(true);
        }
        
        public void ShowError()
        {
            SetVisibleAllPanels(false);
            _errorPanel.SetActive(true);
        }
        
        public void ResetView()
        {
            SetVisibleAllPanels(false);
            _feedbackInputField.text = string.Empty;
        }

        private void SetVisibleAllPanels(bool isVisible)
        {
            _loadingPanel.SetActive(isVisible);
            _successPanel.SetActive(isVisible);
            _errorPanel.SetActive(isVisible);
        }
    }
}

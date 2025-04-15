using System;
using Project.Scripts.Model;
using Project.Scripts.Service;
using Project.Scripts.View;
using UnityEngine;

namespace Project.Scripts.Controller
{
    public class FeedbackController : MonoBehaviour
    {
        private FeedbackView _view;
        private IFeedbackService _feedbackService;

        public void Awake()
        {
            _view = FindObjectOfType<FeedbackView>();
            _feedbackService = new GoogleFormFeedbackService();
            _view.ResetView();
        }

        public async void OnClick_Feedback()
        {
            try
            {
                if (string.IsNullOrEmpty(_view.FeedbackText))
                    return;
            
                FeedbackData feedbackData = new FeedbackData(_view.FeedbackText);
            
                _view.ShowLoading();

                bool isSuccess = await _feedbackService.SubmitFeedback(feedbackData);

                if (isSuccess)
                {
                    _view.ResetView();
                    _view.ShowSuccess();
                }
                else
                {
                    _view.ShowError();
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error. Async crash!!!");
                _view.ShowError();
            }
        }

        public void OnClick_Back()
        {
            _view.ResetView();
        }
    }
}
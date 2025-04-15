using Cysharp.Threading.Tasks;
using Project.Scripts.Model;
using UnityEngine;
using UnityEngine.Networking;

namespace Project.Scripts.Service
{
    public class GoogleFormFeedbackService : IFeedbackService
    {
        private const string FormUrl = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSehZvUwuIwbBne24YLoxULlk4L6ctbd9LNt6VS9M5oxcGsmjA/formResponse";
        
        public async UniTask<bool> SubmitFeedback(FeedbackData feedbackData)
        {
            WWWForm form = new WWWForm();
            form.AddField("entry.485273778", feedbackData.Message);

            using UnityWebRequest www = UnityWebRequest.Post(FormUrl, form);
            await www.SendWebRequest().ToUniTask();
            return www.result == UnityWebRequest.Result.Success;
        }
    }
}
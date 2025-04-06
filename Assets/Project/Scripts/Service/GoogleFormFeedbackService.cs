using Cysharp.Threading.Tasks;
using Project.Scripts.Model;
using UnityEngine;
using UnityEngine.Networking;

namespace Project.Scripts.Service
{
    public class GoogleFormFeedbackService : IFeedbackService
    {
        private const string FormUrl = "https://docs.google.com/forms/d/e/1FAIpQLSfDg8gdpuFYvmWg4OJ_jPFaxCU_BV8c-g5uFjd9vcln8j2aHQ/formResponse";
        
        public async UniTask<bool> SubmitFeedback(FeedbackData feedbackData)
        {
            WWWForm form = new WWWForm();
            form.AddField("entry1", feedbackData.Message);

            using (UnityWebRequest www = UnityWebRequest.Post(FormUrl, form))
            {
                await www.SendWebRequest().ToUniTask();
                return www.result == UnityWebRequest.Result.Success;
            }
        }
    }
}
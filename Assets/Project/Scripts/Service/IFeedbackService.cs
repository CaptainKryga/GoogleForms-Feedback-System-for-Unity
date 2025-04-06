using Cysharp.Threading.Tasks;
using Project.Scripts.Model;

namespace Project.Scripts.Service
{
    public interface IFeedbackService
    {
        UniTask<bool> SubmitFeedback(FeedbackData feedbackData);
    }
}
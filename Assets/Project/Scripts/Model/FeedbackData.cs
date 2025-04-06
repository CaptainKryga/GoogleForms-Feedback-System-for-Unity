using System;

namespace Project.Scripts.Model
{
    [Serializable]
    public class FeedbackData
    {
        public string Message;

        public FeedbackData(string message)
        {
            Message = message;
        }
    }
}
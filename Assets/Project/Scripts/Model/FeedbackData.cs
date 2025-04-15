using System;

namespace Project.Scripts.Model
{
    [Serializable]
    public class FeedbackData
    {
        public string Message { get; private set; }

        public FeedbackData(string message)
        {
            Message = message;
        }
    }
}
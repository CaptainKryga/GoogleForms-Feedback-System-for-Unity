# 📝 Google Forms Feedback System for Unity 🎮

![Unity](https://img.shields.io/badge/Unity-2021.3%2B-blue.svg)
![License](https://img.shields.io/badge/License-MIT-green.svg)
![Platform](https://img.shields.io/badge/Platform-All%20Platforms-lightgrey.svg)

A simple yet powerful solution for collecting user feedback in Unity games via Google Forms 📊

## ✨ Features
- 🚀 Easy integration into any Unity project
- 📤 Submit text data and numerical ratings
- 🛠️ Fully customizable form fields
- ⚡ Asynchronous data submission
- 📚 Ready-to-use examples
- 🔒 Works with Unitask, but only for example


## 🏁 Quick Start

### 1️⃣ Google Forms Setup
1. Create a new form at [Google Forms](https://docs.google.com/forms/)
2. Add your desired fields (questions)
3. Get the form ID from URL: `https://docs.google.com/forms/u/0/d/e/FORM_ID/formResponse`or simply replace the link after the form response
5. Obtain `entry.ID` for each field (see "How to Get entry.ID" below)


### 2️⃣ Unity Implementation
Add the Service folder (Assets/Project/Scripts/Service) to your project.
Add the Model folder (Assets/Project/Scripts/Model) to your project.

```csharp
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
```


### 3️⃣ Usage Example
```csharp
FeedbackData feedbackData = new FeedbackData("Description from google forms");
bool isSuccess = await _feedbackService.SubmitFeedback(feedbackData);
```


### 🔍 How to Get entry.ID
1. Open your Google Form
2. Open developer tools (F12 or Ctrl+U or ...)
3. Submit the completed form to be able to get links
4. Search for entry. in the HTML
5. The numbers after entry. are your field IDs (e.g., entry.123456789)


### 🛠️ Customization Tips
```csharp
// Add device information
form.AddField("entry.555555555", SystemInfo.deviceModel);

// Add game version
form.AddField("entry.666666666", Application.version);

// Add timestamp
form.AddField("entry.777777777", System.DateTime.Now.ToString());
```


### 📋 Recommended Form Structure
- (entry.111111) Rating (1-5 scale) ⭐⭐⭐⭐⭐
- (entry.222222) Feedback comments ✏️
- (entry.333333) Email (optional) 📧
- (entry.444444) Feedback type (Bug/Feature Request/Other) 🐞💡


### 📜 License
MIT License - Feel free to use and modify! See LICENSE for details.

## 💖 Support Project
Love this tool? Support its development:
- [My boosty.to](https://boosty.to/captainkryga)

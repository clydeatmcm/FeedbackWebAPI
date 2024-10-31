using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendDataToServer : MonoBehaviour
{
    public string url = "";

    public IEnumerator SendPostRequest(int feedbackScore)
    {
        // Create the JSON object to send
        FeedbackData feedbackData = new FeedbackData(0, feedbackScore);
        string jsonData = JsonUtility.ToJson(feedbackData);

        Debug.Log("JSON Data: " + jsonData); // Log the JSON data

        // Create a new UnityWebRequest
        using (UnityWebRequest request = new UnityWebRequest(this.url, "POST"))
        {
            // Set the content type to JSON
            request.SetRequestHeader("Content-Type", "application/json");

            // Upload the JSON data
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            // Send the request and wait for a response
            yield return request.SendWebRequest();

            // Check for errors
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Error: {request.error}");
            }
            else
            {
                Debug.Log("Data sent successfully: " + request.downloadHandler.text);
            }
        }
    }


    [System.Serializable]
    public class FeedbackData
    {
        public int feedback_id;
        public int feedback_score;
        public FeedbackData(int id, int score)
        {
            feedback_id = id;
            feedback_score = score;
        }
    }
}

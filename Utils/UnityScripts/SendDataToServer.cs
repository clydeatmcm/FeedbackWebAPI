using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SendDataToServer : MonoBehaviour
{
    private const string url = "http://your-server-url/api/endpoint"; // Replace with your actual URL

    // Function to send an integer to the server
    public void SendIntegerToServer(int value)
    {
        StartCoroutine(SendPostRequest(value));
    }

    private IEnumerator SendPostRequest(int value)
    {
        // Create the JSON object to send
        string jsonData = JsonUtility.ToJson(new { integerValue = value });

        // Create a new UnityWebRequest
        using (UnityWebRequest request = UnityWebRequest.Post(url, jsonData))
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
}

/**
To create a button in Unity that calls the SendIntegerToServer function when clicked, you can use the following code example.

... some codes here

    public SendDataToServer sendDataToServer;
    public int feedbackValue = -1;

    void Start()
    {
        // Find the button and add a listener to it
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // Check if feedbackValue is set and valid
        if (feedbackValue >= 0)
        {
            // Call the method in SendDataToServer to send the integer
            sendDataToServer.SendIntegerToServer(feedbackValue);
        }
        else
        {
            Debug.LogError("Invalid feedback value.");
        }
    }

... some codes here
**/

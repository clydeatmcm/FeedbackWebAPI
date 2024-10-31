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

    private void OnButtonClick()
    {
        // Get the integer from the InputField
        if (int.TryParse(inputField.text, out int value))
        {
            // Call the method in DatabaseManager to send the integer
            SendDataToServer.SendIntegerToServer(value);
        }
        else
        {
            Debug.LogError("Invalid integer input.");
        }
    }

... some codes here
**/

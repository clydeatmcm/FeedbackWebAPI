/**
ButtonSendFeedback.cs serves as the trigger class to call and implement SendDataToServer.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ButtonSendFeedback : MonoBehaviour
{
    public SendDataToServer postRequest;
    public int feedbackScore = 2; // use your existing logic to update the score value

    // Start is called before the first frame update
    void Start()
    {
        postRequest = gameObject.AddComponent<SendDataToServer>();
        Debug.Log("Hello");
    }

    public void OnClick()
    {
        postRequest.url = "https://localhost:7115/api/Feedback";
        StartCoroutine(postRequest.SendPostRequest(feedbackScore));
    }

}

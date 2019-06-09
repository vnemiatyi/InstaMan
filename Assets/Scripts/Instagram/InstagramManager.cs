using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class InstagramManager : MonoBehaviour
{

    //Config
    [SerializeField]
    private string apiToken;

    [SerializeField]
    private string postId;


    [SerializeField]
    public float likesCounter, currentLikesCounter, maxLikes, manaPoints, newLikesCounter, likeValue;

    private string URL = "https://api.instagram.com/v1/users/self/media/recent/?access_token=";

    private  int cnt = 0;
    [SerializeField]
    private int step = 500;

    [SerializeField]
    private Slider manabar;

    private void Awake()
    {
        StartCoroutine(GetRequest(URL + apiToken));
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
;        if (newLikesCounter == 1) {
            if (Input.GetKeyUp(KeyCode.F))
            {
                newLikesCounter -= manaPoints;
                manabar.value = newLikesCounter;
            }
        } else if (newLikesCounter != 1) {
            ++cnt;

            if (cnt >= step)
            {
                Debug.Log("Calling API...");
                StartCoroutine(GetLikesOnUpdate(URL + apiToken));
                cnt = 0;
            }
        }
    }



    // Calls Instagram API and gets data of recent posts
    private IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                //Debug.Log(webRequest.downloadHandler.text);
                var ResponseObj = RootObject.CreateFromJSON(webRequest.downloadHandler.text);
                var responseData = ResponseObj.data;
                FindLikesById(responseData);
            }
        }
    }


    // Iterate through List to get likes
    private void FindLikesById(List<Datum> posts)
    {
        foreach (Datum post in posts)
        {
            if (post.id == postId)
            {
                int likes = post.likes.count;
                likesCounter = Mathf.Round(likes);
                maxLikes = likesCounter;
                newLikesCounter = likesCounter / maxLikes;
                manabar.value = newLikesCounter;
            }
        }
    }


    //===========================================================================================

  
   
    // Calls Instagram API and gets data of recent posts
    private IEnumerator GetLikesOnUpdate(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                Debug.Log("Success!");
                var ResponseObj = RootObject.CreateFromJSON(webRequest.downloadHandler.text);
                var responseData = ResponseObj.data;
                FilterCurrentLikes(responseData);
            }
        }
    }


    // Iterate through List to get likes
    private void FilterCurrentLikes(List<Datum> posts)
    {
        foreach (Datum post in posts)
        {
            if (post.id == postId)
            {
                int likes = post.likes.count;
                currentLikesCounter = Mathf.Round(likes);
                newLikesCounter = (currentLikesCounter - likesCounter) * likeValue;
                manabar.value = newLikesCounter;
                //likesCounter = currentLikesCounter;
            }
        }
    }

    private void DecreaseLikes() {      
        newLikesCounter -= manaPoints;
        Debug.Log(newLikesCounter);
        manabar.value = newLikesCounter;
    }
}






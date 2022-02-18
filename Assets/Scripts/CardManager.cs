using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PokemonTcgSdk;
using PokemonTcgSdk.Models;
using System.Linq;
using System.IO;
using UnityEngine.Networking;

public class CardManager : MonoBehaviour
{

    // For future use: extentable code
    #region Private Variables
    string Id;
    string Name;
    string ImageUrlHiRes;
    string SubType;
    string SuperType;
    string Number;
    string Artist;
    string Rarity;
    string Series;
    string Set;
    string SetCode;
    #endregion
    public string ImageUrl;
    public RawImage Image;
    public int deckNumber;

    // Download the Image from the web and set it on the GameObject's raw Image
    public IEnumerator LoadImageFromURL(string ImageURL)
    {
        this.ImageUrl = ImageURL;
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(ImageURL);
        yield return www.SendWebRequest();
        if(www.error != null)
        {
            Debug.LogError("Error: " + www.error);
        }
        else
        {
            Texture2D loadTexture = DownloadHandlerTexture.GetContent(www);
            Image.texture = loadTexture;
        }

    }

    // Just to call the coroutine
    public void setData(string ImageUrl)
    {
        StartCoroutine(LoadImageFromURL(ImageUrl));
    }


}

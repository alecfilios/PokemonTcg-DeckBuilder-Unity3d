using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutExitHandler : MonoBehaviour
{
    [SerializeField]
    GameObject aboutCanvas;
    [SerializeField]
    GameObject backgroudnMusic;
    [SerializeField]
    AudioClip TitleScreenClip;


    // Exit the about Screen
    public void onClick()
    {
        aboutCanvas.SetActive(false);
        backgroudnMusic.GetComponent<AudioSource>().clip = TitleScreenClip;
        backgroudnMusic.GetComponent<AudioSource>().Play();


    }
}

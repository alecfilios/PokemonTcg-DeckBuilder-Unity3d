using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutButtonHandler : MonoBehaviour
{
    [SerializeField]
    GameObject aboutCanvas;
    [SerializeField]
    GameObject backgroudnMusic;
    [SerializeField]
    AudioClip LaventerTownClip;

    // Enter the about screen
    public void onClick()
    {
        aboutCanvas.SetActive(true);
        backgroudnMusic.GetComponent<AudioSource>().clip = LaventerTownClip;
        backgroudnMusic.GetComponent<AudioSource>().Play();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField]
    GameObject homeScreen;
    [SerializeField]
    GameObject backgroudnMusic;
    [SerializeField]
    AudioClip TitleScreenClip;

    public void onClick()
    {
        homeScreen.SetActive(true);
        backgroudnMusic.GetComponent<AudioSource>().clip = TitleScreenClip;
        backgroudnMusic.GetComponent<AudioSource>().Play();

    }
}

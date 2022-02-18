using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBuilderButtonHandler : MonoBehaviour
{
    [SerializeField]
    GameObject homeCanvas;
    [SerializeField]
    GameObject backgroudnMusic;
    [SerializeField]
    AudioClip PokemonCentreClip;

    // Got to DeckBuilder from home
    public void onClick()
    {
        homeCanvas.SetActive(false);
        backgroudnMusic.GetComponent<AudioSource>().clip = PokemonCentreClip;
        backgroudnMusic.GetComponent<AudioSource>().Play();
    }
}

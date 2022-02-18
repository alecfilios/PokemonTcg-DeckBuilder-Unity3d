using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadClickHandler : MonoBehaviour
{
    [SerializeField] DeckCase deckCase;
    public void onClick()
    {
        try
        {
            CardData data = SaveSystem.LoadData();
            deckCase.loadDataFromLocalDisk(data);
        }
        catch
        {
            Debug.LogError("Load decks from local storage error");
        }

    }
}

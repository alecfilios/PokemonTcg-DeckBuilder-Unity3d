using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SaveClickHandler : MonoBehaviour
{
    [SerializeField] DeckCase deckCase;
    public void onClick()
    {
        try { 
        SaveSystem.SaveData(deckCase.getAllDecks());
        }
        catch
        {
            Debug.LogError("Save decks in local storage error");
        }
    }
}

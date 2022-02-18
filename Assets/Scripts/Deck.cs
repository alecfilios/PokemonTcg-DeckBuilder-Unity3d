using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour 
{
    private GameObject DeckGridPanel;
    public List<GameObject> deckCardList = new List<GameObject>();

    private void Awake()
    {
        // Some initilizations
        DeckGridPanel = GameObject.Find("Deck Grid Panel");
        if (DeckGridPanel == null)
        {
            Debug.Log("Could not locate Deck grid panel ");
        }
    }

    public void Save()
    {


        // if there are any cards on the Deck List
        if (deckCardList.Count > 0)
        {
            // destroy them and clear the deck
            for (int i = 0; i < deckCardList.Count; i++)
            {
                Destroy(deckCardList[i]);
            }
        }
        // clear the previous deck list
        deckCardList.Clear();
        // if there are any cards on the deck grid
        if (DeckGridPanel.transform.childCount > 0)
        {
            // store them in the list
            for (int i = 0; i < DeckGridPanel.transform.childCount; i++)
            {
                GameObject cardCopy = Instantiate(DeckGridPanel.transform.GetChild(i).gameObject, transform);
                cardCopy.name = "Card Copy (" + i + ")";
                deckCardList.Add(cardCopy);
            }
        }

    }

    public void Load()
    {
        // if there are any cards on the deck grid
        if (DeckGridPanel.transform.childCount > 0)
        {
            // destroy them and clear the screen
            for (int i = 0; i < DeckGridPanel.transform.childCount; i++)
            {
                Destroy(DeckGridPanel.transform.GetChild(i).gameObject);
            }
        }
        // now fill the screen with the cards in the deck selected
        if (deckCardList.Count > 0)
        {
            for (int i = 0; i < deckCardList.Count; i++)
            {
                GameObject newCard =  Instantiate(deckCardList[i], DeckGridPanel.transform);
                newCard.GetComponent<CardManager>().setData(deckCardList[i].GetComponent<CardManager>().ImageUrl);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardData
{
    // the only two elements needed is the deck the cards used to be and their image. Not that extendable 
    public List<int> listOfDeckNums = new List<int>();
    public List<string> listOfImageUrls = new List<string>();

    public CardData(List<GameObject> allDecks)
    {
        for(int i=0; i<allDecks.Count; i++)
        {
            foreach(GameObject card in allDecks[i].GetComponent<Deck>().deckCardList)
            {
                listOfDeckNums.Add(i);

                listOfImageUrls.Add(card.GetComponent<CardManager>().ImageUrl);
            }
        }
    }
}



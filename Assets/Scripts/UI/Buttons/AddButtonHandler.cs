using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButtonHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject DeckGridPanel;
    
    // Add a card in the deck.
    public void addCardInDeck()
    {
        GameObject selectedCard = transform.parent.GetComponent<Showcase>().GetCard();
        Instantiate(selectedCard, DeckGridPanel.transform);
        if(DeckGridPanel.transform.childCount >= 60)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}

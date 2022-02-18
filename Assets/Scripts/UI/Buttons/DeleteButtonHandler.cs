using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButtonHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject DeckGridPanel;
    public Texture2D defaultImage;


    // This method deletes a card from the deck grid and from the deck list as well
    public void deleteCardFromDeck()
    {
        GameObject selectedCard = transform.parent.GetComponent<Showcase>().GetCard();
        int index = selectedCard.transform.GetSiblingIndex();
        Destroy(selectedCard);

        if (DeckGridPanel.transform.childCount == 1)
        {
            transform.parent.GetComponentInChildren<RawImage>().texture = defaultImage;
            transform.GetComponent<Button>().interactable = false;
        }
        else
        {  
            GameObject nextBrother;
            if (index + 1 == DeckGridPanel.transform.childCount)
            {
                nextBrother = DeckGridPanel.transform.GetChild(index - 1).gameObject;
            }
            else
            {
                nextBrother = DeckGridPanel.transform.GetChild(index + 1).gameObject;
            }
            //Set new Image of the brother
            transform.parent.GetComponent<Showcase>().SetCard(nextBrother);
            Texture selectedTexture = nextBrother.GetComponent<RawImage>().texture;
            transform.parent.GetComponentInChildren<RawImage>().texture = selectedTexture;
            
        }
        
        
   
        
    }
}

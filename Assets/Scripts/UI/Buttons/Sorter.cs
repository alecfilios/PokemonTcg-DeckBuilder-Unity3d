using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sorter : MonoBehaviour
{
    [SerializeField]
    private GameObject browser;
    [SerializeField]
    private GameObject ShowcasePanel;
    public GameObject defaultCard;
    public Texture2D defaultImage;
    [SerializeField]
    private Button addButton;

    public void sortCards(string attribute)
    {
        
        addButton.interactable = false;
        ShowcasePanel.GetComponent<Showcase>().SetCard(defaultCard);
        ShowcasePanel.GetComponentInChildren<RawImage>().texture = defaultImage;
        Browser browScript = browser.GetComponent<Browser>();
        browScript.sortByAttribute(attribute);
        browScript.ClearBrowserScreen();
        browScript.LoadCardsOnScreen(browScript.somePokemonCards);
        
    }
}

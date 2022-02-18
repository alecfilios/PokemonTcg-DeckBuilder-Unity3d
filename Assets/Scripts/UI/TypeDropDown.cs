using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeDropDown : MonoBehaviour
{
    [SerializeField]
    private GameObject browser;
    [SerializeField]
    private GameObject ShowcasePanel;
    public GameObject defaultCard;
    public Texture2D defaultImage;
    [SerializeField]
    private Button addButton;

    // hiding some stuff from the UI and starting the filtering by Pokemon Type
    public void HandleInputData(int val)
    {

        addButton.interactable = false;
        ShowcasePanel.GetComponent<Showcase>().SetCard(defaultCard);
        ShowcasePanel.GetComponentInChildren<RawImage>().texture = defaultImage;

        
        Browser browScript = browser.GetComponent<Browser>();
        browScript.filterCardsByType(val);
        browScript.ClearBrowserScreen();
        browScript.LoadCardsOnScreen(browScript.somePokemonCards);
        Debug.Log(browScript.somePokemonCards.Count);
        
    }
}

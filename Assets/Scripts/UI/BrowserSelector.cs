using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BrowserSelector : MonoBehaviour, IPointerDownHandler
{
  
    private GameObject DeckGridPanel;
    private GameObject ShowcasePanel;
    private void Awake()
    {
        ShowcasePanel = GameObject.Find("Showcase Panel");
        DeckGridPanel = GameObject.Find("Deck Grid Panel");

        if (ShowcasePanel == null)
        {
            Debug.Log("Could not locate Showcase panel ");
        }
        else if( DeckGridPanel == null)
        {
            Debug.Log("Could not locate Deck grid panel ");
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        ShowcasePanel.GetComponent<Showcase>().SetCard(gameObject);
        if (transform.parent.name == "Deck Grid Panel")
        {
            ShowcasePanel.transform.Find("Add Button").GetComponent<UnityEngine.UI.Button>().interactable = false;
            ShowcasePanel.transform.Find("Delete Button").GetComponent<UnityEngine.UI.Button>().interactable = true;
        }
        else if(transform.parent.name == "Card Search Browser" && DeckGridPanel.transform.childCount < 60)
        {
            ShowcasePanel.transform.Find("Add Button").GetComponent<UnityEngine.UI.Button>().interactable = true;
            ShowcasePanel.transform.Find("Delete Button").GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        else if(transform.parent.name == "Card Search Browser" && DeckGridPanel.transform.childCount >= 60)
        {
            ShowcasePanel.transform.Find("Add Button").GetComponent<UnityEngine.UI.Button>().interactable = false;
            ShowcasePanel.transform.Find("Delete Button").GetComponent<UnityEngine.UI.Button>().interactable = false;
        }


        Texture selectedTexture = this.GetComponent<RawImage>().texture;
        ShowcasePanel.GetComponentInChildren<RawImage>().texture = selectedTexture;
    }
}

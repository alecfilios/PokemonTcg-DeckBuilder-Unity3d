using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    [SerializeField]
    private GameObject DeckCase;
    [SerializeField]
    private GameObject ShowcasePanel;
    public GameObject defaultCard;
    public Texture2D defaultImage;
    [SerializeField]
    private Button addButton;
    public int previousVal = 0;
    private void Start()
    {
        DeckCase.GetComponent<DeckCase>().LoadADeck(0);
    }

    public void HandleInputData(int val)
    {
        addButton.interactable = false;
        ShowcasePanel.GetComponent<Showcase>().SetCard(defaultCard);
        ShowcasePanel.GetComponentInChildren<RawImage>().texture = defaultImage;

        DeckCase.GetComponent<DeckCase>().SaveADeck(previousVal);
        DeckCase.GetComponent<DeckCase>().LoadADeck(val);
        previousVal = val;

    }

    public void saveCurrentDeck()
    {
        DeckCase.GetComponent<DeckCase>().SaveADeck(previousVal);
    }

    public void loadCurrentDeck()
    {
        DeckCase.GetComponent<DeckCase>().LoadADeck(previousVal);
    }
}

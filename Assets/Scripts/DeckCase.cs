using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DeckCase : MonoBehaviour
{
    [SerializeField] GameObject cardBody; 
    [SerializeField] GameObject ShowcasePanel; 
    [SerializeField] GameObject DeckGridPanel;
    List<GameObject> allDecks = new List<GameObject>();
    public Texture2D defaultImage;
    [SerializeField]
    private Button addButton;
    [SerializeField]
    private Button deleteButton;
    [SerializeField]
    private GameObject dropdown;

    // Start initilizes the list of GameObjects that are also the chikdren of this class
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            allDecks.Add(gameObject.transform.GetChild(i).gameObject);
        }

    }
    // Save the deck with index: val
    public void SaveADeck(int val)
    {
        allDecks[val].GetComponent<Deck>().Save();
    }
    // Load the deck with index: val
    public void LoadADeck(int val)
    {
        allDecks[val].GetComponent<Deck>().Load();
    }
    // Return all the existing decks, but first make sure that teh one selected is properly saved.
    public List<GameObject> getAllDecks()
    {
        dropdown.GetComponent<DropDown>().saveCurrentDeck();
        return allDecks;
    }
    // Use the rertrieved data from the local disk in order to update teh decks.
    public void loadDataFromLocalDisk(CardData data)
    {
        // Get the data properties
        List<int> listOfDeckNums = data.listOfDeckNums;
        List<string> listOfImageUrls = data.listOfImageUrls;

        // Disable the necessary UI elements ----------------
        ShowcasePanel.GetComponent<Showcase>().SetCard(cardBody);
        ShowcasePanel.GetComponentInChildren<RawImage>().texture = defaultImage;
        addButton.interactable = false;
        addButton.interactable = false;
        // -------------------------------------------------
        // Clear everything: lists/grid/children(destory)
        ClearDeckGrid();
        ClearDeckLists();
        DestroyDeckChildren();
        createDownloadedDecks(listOfDeckNums, listOfImageUrls);
        // Load the current deck that was previously selected.
        dropdown.GetComponent<DropDown>().loadCurrentDeck();

    }

    /** -----------------------------------------------------------------
     *                     METHODS & TOOLS
     * ------------------------------------------------------------------
    */
    void ClearDeckGrid()
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
    }

    void ClearDeckLists()
    {
        foreach (GameObject deck in allDecks)
        {
            deck.GetComponent<Deck>().deckCardList.Clear();

        }
    }

    void DestroyDeckChildren()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform deckTransform = transform.GetChild(i);
            for (int j = 0; j < deckTransform.childCount; j++)
            {
                Destroy(deckTransform.GetChild(j).gameObject);
            }
        }

    }

    void createDownloadedDecks(List<int> listOfDeckNums , List<string> listOfImageUrls)
    {
        for (int i = 0; i < listOfDeckNums.Count; i++)
        {
            GameObject currentCard = Instantiate(cardBody, this.transform.GetChild(listOfDeckNums[i]));
            currentCard.GetComponent<CardManager>().ImageUrl = listOfImageUrls[i];
            currentCard.GetComponent<CardManager>().deckNumber = listOfDeckNums[i];
            currentCard.GetComponent<CardManager>().setData(listOfImageUrls[i]);
            allDecks[listOfDeckNums[i]].GetComponent<Deck>().deckCardList.Add(currentCard);
        }
    }
}

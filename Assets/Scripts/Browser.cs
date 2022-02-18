using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PokemonTcgSdk;
using System.Threading.Tasks;
using System.Linq;
using System;

public class Browser : MonoBehaviour
{
    [SerializeField]
    private GameObject cardBody;
    private List<PokemonTcgSdk.Models.PokemonCard> allPokemonCards;
    public List<PokemonTcgSdk.Models.PokemonCard> somePokemonCards = new List<PokemonTcgSdk.Models.PokemonCard>();
    private List<string> types;
    [SerializeField]
    private GameObject loadingCanvas;

    /**
     * -----------------------------------------------------------------------------
     *                          BROSER FUNCTION was kinda of a struggle          
     * -----------------------------------------------------------------------------
    */

    void Start()
    {
        // start 3 seconds later in order for the Loadingscreen to have some time.
        StartCoroutine(LateStart(3));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        getCardsFromDB();
    }


    /** At this point it is worth noting that the lirbrary/sdk provided by the PokemonTcg is kinda buggy, atleast this version (1.1.1).
     * Because of the noisy sampl of the DB, many of the lists of cards that contain only Pokemon for example are filled witht other types of cards as well. 
     * Due to that fact the initilization of the class was not always working. But it did sometimes. Thus the following trick came to fruition.
     * On the one hand Im glad I thought of it but on the other hand is a rookie trick that I am ashamed of. 
    */

    // this class loops until finally the cards are loaded properly. It takes 70 loops on average. 
    public void getCardsFromDB()
    {
        bool isLoaded = false;
        while (!isLoaded)
        {
            try
            {
                isLoaded = true;
                allPokemonCards = Card.Get<Pokemon>().Cards;

                //Debug.Log("All Pokemon cards are: " + pokemonCards.Count);

                /*
                var trainerCards = Card.Get<Trainer>().Cards;
                Debug.Log("All Trainer cards are: " + trainerCards.Count);

                var energyCards = Card.Get<Energy>().Cards;
                Debug.Log("All Trainer cards are: " + energyCards.Count);
                */
                types = PokemonTcgSdk.Types.All();
            }
            catch
            {
                Debug.Log("Failed Attempt to Load the Data, trying again...");
                isLoaded = false;
                
            }

        }
        // After the initilization, I clear the data in order to not have similar problems in the future.
        clearNoPokemonCards(allPokemonCards);
        foreach (var card in allPokemonCards.ToList())
        {
            somePokemonCards.Add(card);
        }
        // Time to load.
        LoadCardsOnScreen(allPokemonCards);
        loadingCanvas.SetActive(false);


    }
    // this filters do actually work but they are not sorting the data , I could spent some more time to make it work ideally but I eeded to proceed.
    public void filterCardsByType(int val)
    {
        somePokemonCards.Clear();
        if (val == 0)
        {
            foreach (var card in allPokemonCards.ToList())
            {
                somePokemonCards.Add(card);
            }
        }
        else
        {
            foreach (var card in allPokemonCards.ToList())
            {
                if (card.Types.ToList().Contains(types[val - 1]))
                {
                    somePokemonCards.Add(card);
                }
            }
        }
       
    }

    public void ClearBrowserScreen()
    {
        // if there are any cards on the browser grid
        if (transform.childCount > 0)
        {
            // destroy them and clear the screen
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    public void LoadCardsOnScreen(List<PokemonTcgSdk.Models.PokemonCard> cards)
    {

        foreach (var card in cards)
        {
            GameObject newcard = Instantiate(cardBody, transform);
            newcard.GetComponent<CardManager>().setData(card.ImageUrl);
        }
    }

    // Only for some testing
    void printCardStats(List<PokemonTcgSdk.Models.PokemonCard> cards)
    {
        int numOfRemovedcards = 0;
        foreach (var card in cards.ToList())
        {
            Debug.Log("Name: " + card.Name + "  HP: " + card.Hp + "   Rarity: " + card.Rarity + "Types: ");
            if( card.Types == null || card.Hp == "None")
            {
                Debug.Log("Card with name: " + card.Name + " was succesfully removed");
                cards.Remove(card);
                numOfRemovedcards++;
            }
            else
            {
                printList(card.Types.ToList());
            }
            
        }
        Debug.Log("Number of Removed cards: " + numOfRemovedcards);
    }

    // For the sake of the types.
    void printList(List<string> list)
    {
        int counter = 1;
        foreach(string item in list)
        {
            
            Debug.Log(" Item " + counter + " :"+ item.ToString());
            counter++;
        }

    }

    void clearNoPokemonCards(List<PokemonTcgSdk.Models.PokemonCard> cards)
    {
        int numOfRemovedcards = 0;
        foreach (var card in cards.ToList())
        {
            if(card.Types == null || card.Hp == "None" )
            {
                cards.Remove(card);
                numOfRemovedcards++;
            }
        }
    }
    // This is TerrainHeightmapSyncControl sorting method that is not actually sorting with the order i'd like to
    public void sortByAttribute(string attribute)
    {
        switch (attribute)
        {
            case "Hp":
                somePokemonCards = somePokemonCards.OrderBy(card => card.Hp).ToList();
                break;
            case "Rarity":
                somePokemonCards = somePokemonCards.OrderBy(card => card.Rarity).ToList();
                break;
            default:
                print("Incorrect attribute to order by");
                break;
        }
    }
}

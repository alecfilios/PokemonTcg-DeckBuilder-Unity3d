using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showcase : MonoBehaviour
{
    private GameObject selectedCard;
    public Texture2D defaultImage;

    // getters setters
    public void SetCard(GameObject selectedCard)
    {
        this.selectedCard = selectedCard;
    }
    public GameObject GetCard()
    {
        return selectedCard;
    }
    
}

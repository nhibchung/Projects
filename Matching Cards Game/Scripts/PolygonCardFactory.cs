using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates a shuffled set of cards with polygon images on them
/// </summary>
public class PolygonCardFactory : ICardFactory
{
    [SerializeField] private PlayerCard playerCardPrefab;
    [SerializeField] private Sprite[] sprites;
    private int numberOfCards = 8;

    public override PlayerCard[] CreateCardSet()
    {
        int[] cardIDs = new int[numberOfCards];
        PlayerCard[] cardSet = new PlayerCard[numberOfCards];

        // Filling array with card ID pairs (0,0,1,1,2,2,3,3,...)
        for (int i = 0; i < numberOfCards; i++)
        {
            cardIDs[i] = i / 2;
        }

        // Shuffle cardID array
        Shuffle(cardIDs);

        // Creating cards
        for (int i = 0; i < numberOfCards; i++)
        {
            // Instantiate the newCard at the origin with no rotation and add to cardSet
            cardSet[i] = Instantiate(playerCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            // Set id to shuffled id
            int newCardId = cardIDs[i];

            // Assign new card in card set the shuffled id and corresponding image
            cardSet[i].SetCardImageAndId(newCardId, sprites[newCardId]);
        }

        return cardSet;
    }

    /// <summary>
    /// Fisher Yates Shuffle
    /// </summary>
    void Shuffle(int[] cardIDs)
    {
        int randomNum;
        int tempID;
        for (int i = 0; i < cardIDs.Length; i++)
        {
            randomNum = Random.Range(i, cardIDs.Length);    //Inclusive
            tempID = cardIDs[i];
            cardIDs[i] = cardIDs[randomNum];
            cardIDs[randomNum] = tempID;
        }
    }
}

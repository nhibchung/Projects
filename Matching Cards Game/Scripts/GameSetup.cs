using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets up cards in the play area
/// </summary>
public class GameSetup : MonoBehaviour
{
    [SerializeField] private ICardFactory cardFactory;
    [SerializeField] private GameObject playerArea;
    private PlayerCard[] cardSet;

    /// <summary>
    /// Sets up cards
    /// </summary>
    public void SetUpCards()
    {
        // Destroy existing cards before setting up new cards
        ClearCards();

        // Creating cards
        cardSet = cardFactory.CreateCardSet();

        // Placing cards in play area
        foreach(PlayerCard card in cardSet) 
        {
            card.transform.SetParent(playerArea.transform);
        }
    }

    /// <summary>
    /// Destroy all cards
    /// </summary>
    private void ClearCards()
    {
        foreach (Transform child in playerArea.transform)
        {
            Destroy(child.gameObject);
        }
        cardSet = null;
    }
}

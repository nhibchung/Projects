using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameLogicController singleton class that handles card matching logic
/// </summary>
public class GameLogicController : MonoBehaviour
{
    public static GameLogicController Instance { get; private set; }

    // Private default constuctor to prevent other classes from creating multiple  singletons
    private GameLogicController() { }

    [SerializeField] private float timeBeforeFlipBack = 0.5f;
    private PlayerCard firstCardOfPair;
    private PlayerCard secondCardOfPair;

    private void Awake()
    {
        // Create a GameLogicController singleton instance if there is none
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else 
        {
            // Destroy if there is already a GameLogicController singleton instance
            Destroy(this);
        }
        
    }

    /// <summary>
    /// Handle cards selection
    /// </summary>
    /// <param name="card"></param>
    public void HandleCardSelected(PlayerCard card)
    {
        // 1st case: no cards clicked yet, set and reveal 1st card
        if (firstCardOfPair == null)
        {
            firstCardOfPair = card;
            firstCardOfPair.RevealCard();
        }
        // 2nd case: 1 card has been clicked, set and reveal 2nd card
        else if (secondCardOfPair == null)
        {
            secondCardOfPair = card;
            secondCardOfPair.RevealCard();

            // Check if cards match
            if (firstCardOfPair.Id != secondCardOfPair.Id)
            {
                // No match, flip cards back
                StartCoroutine(WaitBeforeFlippingBack());
            }
            else
            {
                // Match found, clear selected cards
                firstCardOfPair = null;
                secondCardOfPair = null;
            }
        }

    }

    /// <summary>
    /// Wait some before flipping cards backs
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitBeforeFlippingBack()
    {
        yield return new WaitForSeconds(timeBeforeFlipBack);

        // Hide cards
        firstCardOfPair.HideCard();
        secondCardOfPair.HideCard();

        // Clear selected cards
        firstCardOfPair = null;
        secondCardOfPair = null;
    }
}

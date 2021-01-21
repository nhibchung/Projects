using UnityEngine;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour
{
    [SerializeField] private GameObject backOfCard;

    /// <summary>
    /// Handle card click
    /// </summary>
    public void OnCardClick()
    {
        // If card is not revealed (backOfCard still active)
        if (backOfCard.activeSelf)
        {
            GameLogicController.Instance.GetComponent<GameLogicController>().HandleCardSelected(this);
        }
    }

    /// <summary>
    /// Id property for card (such as 0,0,1,1,2,2,3,3 for the polygon card set)
    /// </summary>
    private int id;
    public int Id
    {
        get {
            return id;
        }
    }

    /// <summary>
    /// Assign random card ID and image
    /// </summary>
    public void SetCardImageAndId(int newCardId, Sprite cardImage)
    {
        id = newCardId;
        GetComponent<Image>().sprite = cardImage;
    }

    /// <summary>
    /// Reveal card
    /// </summary>
    public void RevealCard()
    {
        backOfCard.SetActive(false);
    }

    /// <summary>
    /// Unreveal card
    /// </summary>
    public void HideCard()
    {
        backOfCard.SetActive(true);
    }
}

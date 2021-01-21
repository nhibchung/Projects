using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This card set factory makes it easier to switch out sets of cards (such as polygon set, element set, etc.) without changing the code that uses the cards.
/// </summary>
public abstract class ICardFactory : MonoBehaviour
{
    public abstract PlayerCard[] CreateCardSet();
}

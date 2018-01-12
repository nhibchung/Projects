using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
    //Create a reference to the CoinPoofPrefab
    public GameObject CoinPoofPrefab;
    public Transform CoinPosition;
    public SignPost mySignPost;
    public AudioSource coinAudioSource;

    public void OnCoinClicked() {
        // Instantiate the CoinPoof Prefab where this coin is located
        // Make sure the poof animates vertically
        // Destroy this coin. Check the Unity documentation on how to use Destroy
        Instantiate(CoinPoofPrefab, CoinPosition.position, CoinPosition.rotation);
        mySignPost.IncrementCoinCount(); //update count for signpost
        //Play sound on Click
        coinAudioSource.Play();
        Destroy(this.gameObject,coinAudioSource.clip.length);

    }

}

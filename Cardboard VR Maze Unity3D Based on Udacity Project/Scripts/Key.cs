using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    public GameObject KeyPoofPrefab;
    public Door door;
    public Transform KeyPosition;
    public AudioSource keyAudioSource;

	void Update()
	{
	}

	public void OnKeyClicked()
	{
        // Instantiate the KeyPoof Prefab where this key is located
        // Make sure the poof animates vertically
        // Call the Unlock() method on the Door
        // Set the Key Collected Variable to true
        // Destroy the key. Check the Unity documentation on how to use Destroy

        Instantiate(KeyPoofPrefab, KeyPosition.position, KeyPosition.rotation);
        keyAudioSource.Play();
        door.Unlock();
        //Destroy gameobject after clip length
        Destroy(gameObject, keyAudioSource.clip.length);
    }

}

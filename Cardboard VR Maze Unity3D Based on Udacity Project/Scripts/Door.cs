using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    private bool locked = true;
    private bool opening = false;
    public AudioSource doorSoundSource;
    public AudioClip[] doorSoundFiles;
    public Animator doorOpened;

    void Update() {
        // If the door is opening and it is not fully raised
        // Animate the door raising up
        if(opening == true)
        {
            doorOpened.SetBool("open", true);
        }
    }

    public void OnDoorClicked() {
        // If the door is clicked and unlocked
        if(locked == false )
        {
            if(opening == false) { 
                // Set the "opening" boolean to true
                opening = true;

                // Play a sound to indicate the door is opening
                doorSoundSource.clip = doorSoundFiles[0];  //index 0 is for open sound
                doorSoundSource.Play();
            }

        }
        else {
            // Play a sound to indicate the door is locked
            doorSoundSource.clip = doorSoundFiles[1];  //index 1 is for locked sound
            doorSoundSource.Play();
        }
    }

    public void Unlock()
    {
        locked = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    private bool opening = false;
    public Animator openChest;
    public AudioSource chestAudioSource;


    // Update is called once per frame
    void Update()
    {
        if (opening == true)
        {
            openChest.SetBool("openchest", true);
        }
    }

    public void OnChestClicked()
    {
        if (opening == false)
        {
            opening = true;
            chestAudioSource.Play();
        }
    }
}
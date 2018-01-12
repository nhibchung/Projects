using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignPost : MonoBehaviour
{
    
    private int coinCount = 0;
    public Text signpostText;

    public void IncrementCoinCount()
    {
        coinCount++;
    }

    public void Update()
    {
        signpostText.text = "You Win!\n" +
                            "Coin collected: " + coinCount + "/10\n\n" +
                            "Click for\n" +
                            "Main Menu";
    }

    public void ResetScene() 
	{
        // Reset the scene when the user clicks the sign post
        SceneManager.LoadScene("Menu");
    }


}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BullsAndCows : MonoBehaviour
{

    public TextMeshProUGUI secretwordText;
    public TextMeshProUGUI secretwordLength;
    public TextMeshProUGUI msgText;
    public TMP_InputField inputField;

    int lives = 3;
    string secretword = "Hello";
    // Start is called before the first frame update
    void Start()
    {
        secretwordText.text = "Try and guess ";
        secretwordLength.text = "Secret word length " + secretword.Length + ".";
        msgText.text= "Player has " + lives + " lives.";

        Debug.Log("Player has " + lives + " lives.");
        Debug.Log("Secret word is " + secretword + ".");
        Debug.Log("Secret word length " + secretword.Length + ".");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // hello
    // length = 5
    // hello[0] = h
    // hello[1] = e
    // hello[2] = l

    public void OnButtonClick()
    {
        if (lives > 0)
        {
            if (secretword.Length == inputField.text.Length)
            {
                int bullsCount = 0;
                // secretword[?] == guess[?], gdzie ? == ?
                for (int i = 0; i < secretword.Length; i++)
                {
                    if (secretword[i] == inputField.text[i])
                    {
                        bullsCount++;
                    }
                }

                int cowsCount = 0;
                
                for (int i = 0; i < secretword.Length; i++)
                {
                    if (secretword[i] != inputField.text[i] && inputField.text.Contains(secretword[i]))
                    {
                        cowsCount++;
                    }
                }

                lives--;
                secretwordText.text = "Bulls: " + bullsCount + " cows: " + cowsCount;
                msgText.text = "Player has " + lives + " lives.";

            }
            else
            {
                lives--;
                secretwordText.text = "Wrong Length";
                msgText.text = "Player has " + lives + " lives.";
            }
            inputField.text = "";
        }
        else
        {
            
            secretwordText.text = "You lost";
            msgText.text = "Player has " + lives + " lives.";
        }
    }
}

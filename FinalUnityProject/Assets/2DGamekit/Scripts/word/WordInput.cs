using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public WordController wordController;

    // Update is called once per frame
    void Update()
    {
       foreach(char letter in Input.inputString)
       {
            wordController.TypeLetter(letter);
       }
    }
}

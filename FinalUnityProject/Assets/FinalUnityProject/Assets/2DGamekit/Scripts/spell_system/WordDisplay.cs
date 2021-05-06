using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public Text text;
    public float fallSpeed = 60.0f;
    public bool getSpell = true;

    public void SetWord(string word)
    {
        text.text = word;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(0.0f, -fallSpeed * Time.deltaTime, 0.0f);
        float position_y = transform.position.y;
        if (position_y <= 110)
        {
            Destroy(gameObject);
            getSpell = false;
            Debug.Log("game over");
        }
    }
}

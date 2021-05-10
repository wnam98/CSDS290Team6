using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public Text text;
    public string originalText;
    public float fallSpeed = 60.0f;
    public bool getSpell = true;
    [SerializeField] private int colliderPosition = 130;

    public void SetWord(string word)
    {
        text.text = word;
        originalText = word;
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
        if (position_y <= colliderPosition)
        {
            foreach (Word word in GameObject.Find("WordManager").GetComponent<WordController>().words)
            {
                if (word.word == originalText)
                {
                    WordController wordCntl = GameObject.Find("WordManager").GetComponent<WordController>();
                    wordCntl.words.Remove(word);
                    wordCntl.set_hasActiveWord(false);
                    //wordCntl.set_activeWord(None);
                    Debug.Log(word.word + " removed");
                    break;
                }
            }
            Destroy(gameObject);
            getSpell = false;
            //Debug.Log("game over");
        }
    }
}

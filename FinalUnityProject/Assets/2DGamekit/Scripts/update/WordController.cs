using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordController : MonoBehaviour
{
    public List<Word> words;

    private bool hasActiveWord;
    private Word activeWord;

    public WordCreator wordCreator;

    private int count = 21;
    private int typed_successful = 0;
    public float wordDelay = 1.0f;
    private float nextWordTime = 0f;



    void Start()
    {
        //AddWord();
    }

    public void AddWord()
    {

        Word word = new Word(SpellGenerator.GetRandomSpell(), wordCreator.CreateWord());
        //Debug.Log(word.word);

        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }
        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            typed_successful++;
            Debug.Log("successful: " + typed_successful);
            words.Remove(activeWord);
        }
    }

    void Update()
    {
        //if there are no words in the scene
        if (words.Count == 0 && count > 19)
        {
            StartCoroutine(Wait());
            typed_successful = 0;
        }

        //words in the same group show
        if (Time.time >= nextWordTime && count <= 19)
        {
            AddWord();
            nextWordTime = Time.time + wordDelay;
            wordDelay *= .99f;
            count++;
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        count = 1;
        //typed_successful = 0;
    }

    public int get_successful()
    {
        return typed_successful;
    }
}


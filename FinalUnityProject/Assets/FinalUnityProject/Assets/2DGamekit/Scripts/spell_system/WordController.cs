using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordController : MonoBehaviour
{
    public List<Word> words;

    private bool hasActiveWord;
    private Word activeWord;

    public WordCreator wordCreator;

    private int count = 0;
    private int typed_successful = 0;
    public float wordDelay = 1.0f;
    private float nextWordTime = 0f;

    private bool spell_system_active;
    [SerializeField] private double x_high = 27;
    [SerializeField] private double x_low = 26;
    [SerializeField] private double y_high = 5;
    [SerializeField] private double y_low = 3;

    private Vector3 position;

    

    void Start()
    {
        //AddWord();
        spell_system_active = false;
    }

    public void AddWord()
    {
        if (spell_system_active)
        {
            Word word = new Word(SpellGenerator.GetRandomSpell(), wordCreator.CreateWord());
            //Debug.Log(word.word);

            words.Add(word);
        }
        
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
            //Debug.Log("successful: " + typed_successful);
            words.Remove(activeWord);
        }
    }

    void Update()
    {
        //if there are no words in the scene
       
        //words in the same group show
        if (spell_system_active)
        {
            if (words.Count == 0 && count > 4)
            {
                StartCoroutine(Wait());
                typed_successful = 0;
            }

            if (Time.time >= nextWordTime && count <= 4)
            {
                AddWord();
                nextWordTime = Time.time + wordDelay;
                wordDelay *= .99f;
                count++;
            }
        }
        
        position = GameObject.Find("Ellen").transform.position;
        
        if (position.x >= x_low && position.x <= x_high && position.y >= y_low && position.y <= y_high)
        {
            spell_system_active = true;
            //Debug.Log("Activatied");
        }

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        count = 0;
        if (position.x >= x_low && position.x <= x_high && position.y >= y_low && position.y <= y_high)
        {
            spell_system_active = true;
        }
        else
        {
            spell_system_active = false;
            
        }
    }

    public int get_successful()
    {
        return typed_successful;
    }

    public bool get_spell_system_active()
    {
        return spell_system_active;
    }

    public void remove_from_word_list(Word word)
    {
       words.Remove(word);
    }

    public double get_x_high()
    {
        return x_high;
    }

    public double get_x_low()
    {
        return x_low;
    }

    public double get_y_high()
    {
        return y_high;
    }

    public double get_y_low()
    {
        return y_low;
    }

    public Word get_active_word()
    {
        return activeWord;
    }

    public void set_hasActiveWord(bool hasAW)
    {
        hasActiveWord = hasAW;
    }

    public void set_activeWord(Word AW)
    {
        activeWord = AW;
    }

}


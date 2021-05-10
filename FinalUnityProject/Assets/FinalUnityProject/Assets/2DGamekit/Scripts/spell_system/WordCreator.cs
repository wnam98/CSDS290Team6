using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordCreator : MonoBehaviour
{
    public GameObject wordPrefab;

    public Transform wordCanvas;

    public WordDisplay CreateWord()
    {
        Vector3 randomPosition = new Vector3(Random.Range(100.0f, 1200.0f), 1200f);
        GameObject wordObj = Instantiate(wordPrefab,randomPosition, Quaternion.identity, wordCanvas);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
        return wordDisplay;
    }

    
}

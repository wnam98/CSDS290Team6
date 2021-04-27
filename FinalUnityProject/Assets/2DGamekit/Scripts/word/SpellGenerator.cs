using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellGenerator : MonoBehaviour
{
    private static int count = 0;
    private static int randRow = Random.Range(0, 3);

    private static string[,] spellList = new string[3,10]{
        { "fire", "blaze", "bonfire", "heat", "inferno" , "booming", "flame", "spark", "burn", "explosion"},
        { "water", "aqua", "aqueduct", "drop", "rain" , "frost", "ice", "storm", "hurricane", "flow"},
        { "tree", "flower", "wood", "vine", "leaf", "cirrus", "seed", "root", "fruit", "thorn"}
    };

    public static string GetRandomSpell()
    {
        // Every 20 words are a group
        if (count > 19)
        {
            randRow = Random.Range(0, 3);
            count = 0;
        }
        // Debug.Log("count: " + count);
        int randCol = Random.Range(0,10);
        string randomWord = spellList[randRow, randCol];
        count++;

        return randomWord;
    }

    public static int get_group()
    {
        return randRow;
    }

   
}

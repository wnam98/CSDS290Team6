using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellGenerator : MonoBehaviour
{
    private static int count = 0;
    private static int randRow = Random.Range(0, 3);

    private bool spell_system_active;

    private static string[,] spellList = new string[3,10]{
        { "fire", "blaze", "bonfire", "heat", "inferno" , "booming", "flame", "spark", "burn", "explosion"},
        { "water", "aqua", "aqueduct", "drop", "rain" , "frost", "ice", "storm", "hurricane", "flow"},
        { "tree", "flower", "wood", "vine", "leaf", "cirrus", "seed", "root", "fruit", "thorn"}
    };
    
    public static string GetRandomSpell()
    {
        // Every 5 words are a group
        if (count > 4 || count == 0)
        {
            randRow = Random.Range(0, 3);
            count = 0;
        }
        
        int randCol = Random.Range(0,10);
        string randomWord = spellList[randRow, randCol];
        Debug.Log(spellList[randRow, randCol]+": " + count);
        count++;


        return randomWord;
    }

    public static int get_group()
    {
        return randRow;
    }

   
}

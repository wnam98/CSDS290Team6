using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellMessage : MonoBehaviour
{
    private int fire_num = 0;
    private int water_num = 0;
    private int plant_num = 0;

    private int group;
    private bool success_added;

    private Text spellAbility;

    // Start is called before the first frame update
    void Start()
    {
        spellAbility = gameObject.GetComponent<Text>();
        success_added = false;
    }

    // Update is called once per frame
    void Update()
    {
        int success_typed = GameObject.Find("WordsController").GetComponent<WordController>().get_successful();
        if (success_typed == 0)
        {
            group = SpellGenerator.get_group();
            success_added = false;
        }
        if (success_typed >= 20 && !success_added)
        {
            if (group == 0)
            {
                fire_num++;
                success_added = true;
            }
            else if (group == 1)
            {
                water_num++;
                success_added = true;
            }
            else
            {
                plant_num++;
                success_added = true;
            }
        }
       
         
        spellAbility.text = "Fire: " + fire_num + "\nwater: " + water_num + "\nplant: " + plant_num + "\nTyped: " + success_typed;
    }
}

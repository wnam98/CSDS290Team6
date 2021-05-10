using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellMessage : MonoBehaviour
{
    private int fire_num = 1;
    private int water_num = 1;
    private int plant_num = 1;

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
        int success_typed = GameObject.Find("WordManager").GetComponent<WordController>().get_successful();
        //Debug.Log("successful: " + success_typed);
        if (success_typed == 0)
        {
            group = SpellGenerator.get_group();
            success_added = false;
        }
        if (success_typed >= 4 && !success_added)
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
       
         
        spellAbility.text = "Death Crystal: " + fire_num + "\nMeele Attack: " + water_num + "\nInvulnerablility: " + plant_num + "\nTyped: " + success_typed;
    }

    public int get_fire_num()
    {
        return fire_num;
    }

    public int get_water_num()
    {
        return water_num;
    }

    public int get_plant_num()
    {
        return plant_num;
    }

    public void update_spell_num(int fire, int water, int plant)
    {
        fire_num = fire;
        water_num = water;
        plant_num = plant;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D; 

public class WitchCraft : MonoBehaviour
{
    int fire_num;
    int water_num;
    int plant_num;
    int meleenum;

    [SerializeField] private GameObject magicPrefeb;

    // Start is called before the first frame update
    void Start()
    {
         meleenum = 2;
    }

    // Update is called once per frame
    void Update()
    {
        fire_num = GameObject.Find("spellAbility").GetComponent<SpellMessage>().get_fire_num();
        water_num = GameObject.Find("spellAbility").GetComponent<SpellMessage>().get_water_num();
        plant_num = GameObject.Find("spellAbility").GetComponent<SpellMessage>().get_plant_num();

        int spell = 0;
        
        if (water_num == 0) {
            GameObject ellen = GameObject.Find("Ellen");
            PlayerInput playerinput = ellen.GetComponent<PlayerInput>();
            playerinput.DisableMeleeAttacking();
  
        }

        if (water_num != 0) {
            GameObject ellen = GameObject.Find("Ellen");
            PlayerInput playerinput = ellen.GetComponent<PlayerInput>();
            playerinput.EnableMeleeAttacking();
            //GameObject.Find("spellAbility").GetComponent<SpellMessage>().update_spell_num(fire_num, water_num, plant_num);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && water_num != 0)
        {
            water_num = water_num - 1;
            GameObject.Find("spellAbility").GetComponent<SpellMessage>().update_spell_num(fire_num, water_num, plant_num);
        }

        
        
        if (Input.GetKeyDown(KeyCode.Alpha1) && fire_num != 0)
        {


            fire_num -= 1;
            Vector3 position = GameObject.Find("Ellen").transform.position;
            Instantiate(magicPrefeb, position, Quaternion.identity);
            GameObject.Find("spellAbility").GetComponent<SpellMessage>().update_spell_num(fire_num, water_num, plant_num);

            /**
            int rand_num = Random.Range(0, 3);
            if (rand_num == 0)
            {
                spell = fire_num;
            }
            else if (rand_num == 1)
            {
                spell = water_num;
            }
            else
            {
                spell = plant_num;
            }
            while (spell == 0)
            {
                rand_num = Random.Range(0, 3);
                if (rand_num == 0)
                {
                    spell = fire_num;
                }
                else if (rand_num == 1)
                {
                    spell = water_num;
                }
                else
                {
                    spell = plant_num;
                }
            }



            if (rand_num == 0)
            {
                fire_num -= 1;
                Vector3 position = GameObject.Find("Ellen").transform.position;
                Instantiate(magicPrefeb, position, Quaternion.identity);
                GameObject.Find("spellAbility").GetComponent<SpellMessage>().update_spell_num(fire_num, water_num, plant_num);
            }
            /**
            else if (rand_num == 1)
            {
                water_num -= 1;
                Vector3 position = GameObject.Find("Ellen").transform.position;
                Instantiate(magicPrefeb, position, Quaternion.identity);
                GameObject.Find("spellAbility").GetComponent<SpellMessage>().update_spell_num(fire_num, water_num, plant_num);
            }
            else
            {
                plant_num -= 1;
                Vector3 position = GameObject.Find("Ellen").transform.position;
                Instantiate(magicPrefeb, position, Quaternion.identity);
                GameObject.Find("spellAbility").GetComponent<SpellMessage>().update_spell_num(fire_num, water_num, plant_num);
            }**/

        }
           
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellActiveMessage : MonoBehaviour
{
    [SerializeField] private Text spellActive;

    private bool spell_system_active;
    private bool message_not_showed = true;

    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        spell_system_active = GameObject.Find("WordManager").GetComponent<WordController>().get_spell_system_active();
        spellActive.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        spell_system_active = GameObject.Find("WordManager").GetComponent<WordController>().get_spell_system_active();
        if (spell_system_active && message_not_showed)
        {
            spellActive.text = "Spell system is activated!";
            StartCoroutine(show_active_message());
        }
        
        if (!spell_system_active)
        {
            message_not_showed = true;
        }
    }

    private IEnumerator show_active_message()
    {
        yield return new WaitForSeconds(3.0f);
        spellActive.text = "";
        message_not_showed = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Enemy name: " + col.name);
        
        if (col.name == "Chomper" || col.name == "Spitter")
        {
            Destroy(col.gameObject);
        }
    }

    void Update()
    {
        StartCoroutine(destory_obj());
    }

    private IEnumerator destory_obj()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}

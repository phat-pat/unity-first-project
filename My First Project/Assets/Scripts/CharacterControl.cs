using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    public GameObject thePlayer;
    Animator animator;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            thePlayer.GetComponent<Animator>().Play("Charge_Attack_alt");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            thePlayer.GetComponent<Animator>().Play("Blast_Attack_alt");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            thePlayer.GetComponent<Animator>().Play("Death_alt");
        }

    }
}

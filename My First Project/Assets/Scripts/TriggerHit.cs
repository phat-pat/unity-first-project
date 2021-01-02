using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHit : MonoBehaviour
{
    public Animator OtherPlayerAnim;
    public GameObject GameOver;

    public void Hit() {
        if (OtherPlayerAnim.GetBool("Dead")) OtherPlayerAnim.Play("Hit");
    }

    public void ShowGameOver() {
        GameOver.SetActive(true);
    }
}

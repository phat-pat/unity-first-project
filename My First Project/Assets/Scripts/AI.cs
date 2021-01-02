using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random=UnityEngine.Random;
public class CharacterControl : MonoBehaviour
{

    public GameObject p1, p2, mana1, mana2, GameOver, charge1, charge2;
    public float countdown;
    private string p1choice, p2choice;
    private int p1power, p2power;
    private bool gameOver;
    private float startTime;
    private Animator p1anim, p2anim;

    void Start() {
        startTime = Time.time;
        p1anim = p1.GetComponent<Animator>();
        p2anim = p2.GetComponent<Animator>();
        GameOver.SetActive(false);
        charge1.GetComponent<ParticleSystem>().Stop();
        charge2.GetComponent<ParticleSystem>().Stop();
        p1power = 1;
        p2power = 0;
        p1choice = "Blast";
        p2choice = "Blast";
    }

    void Update() {
        if (!gameOver) {
            if (Time.time - startTime < countdown) {
                if (Input.GetKeyDown(KeyCode.Z)) p1choice = "Blast";
                if (Input.GetKeyDown(KeyCode.X)) p1choice = "Charge";
                if (Input.GetKeyDown(KeyCode.C)) p1choice = "Shield";
                // Ai Section begin
                if (p2power < 1) {
                    if(Random.Range(0,1) == 0){
                        p2choice = "Charge";
                    }
                    else{
                        p2choice = "Shield";
                    }
                }
                if (p2power >= 1){
                    if(Random.Range(0,3) == 0){
                        p2choice = "Shield";
                    }
                    else{
                        p2choice = "Blast";
                    }
                }
                //if (Input.GetKeyDown(KeyCode.LeftArrow)) p2choice = "Blast";
                //if (Input.GetKeyDown(KeyCode.DownArrow)) p2choice = "Charge";
                //if (Input.GetKeyDown(KeyCode.RightArrow)) p2choice = "Shield";
            } else {
                p1anim.SetTrigger(p1choice);
                p2anim.SetTrigger(p2choice);
                
                switch (p1choice) {
                    case "Charge":
                        charge1.GetComponent<ParticleSystem>().Play();
                        p1power++;
                        if (p2choice == "Blast") { 
                            p1anim.SetBool("Dead", true);
                        }
                        break;
                    case "Blast":
                        if (p2choice == "Charge") {
                            p2anim.SetBool("Dead", true);
                        }
                        if (p2choice == "Charge") {
                            if (p1power > p2power) {
                                p2anim.SetBool("Dead", true);
                            } 
                            if (p1power < p2power) {
                                p1anim.SetBool("Dead", true);
                            }
                        }
                        p1power = 0;
                        break;
                    default:
                        break;
                }
                if (p2choice == "Charge") {
                    p2power++;
                    charge2.GetComponent<ParticleSystem>().Play();
                }
                if (p2choice == "Blast") p2power = 0;
                if (p1anim.GetBool("Dead") || p2anim.GetBool("Dead")) gameOver = true;
                if (!gameOver) startTime = Time.time;
                else GameOver.SetActive(true);
                mana1.GetComponent<Text>().text = p1power.ToString(); mana2.GetComponent<Text>().text = p2power.ToString();
            }
        }
    }
}

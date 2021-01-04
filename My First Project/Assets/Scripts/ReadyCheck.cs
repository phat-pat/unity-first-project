using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyCheck : MonoBehaviour
{
    public GameObject press_x, press_down;

    void Start() {
        if (GameSelect.GlobalGame == 1) press_down.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) press_x.SetActive(false);
        if (Input.GetKeyDown(KeyCode.DownArrow)) press_down.SetActive(false);

        if (!press_x.activeSelf && !press_down.activeSelf) gameObject.SetActive(false);
    }
}

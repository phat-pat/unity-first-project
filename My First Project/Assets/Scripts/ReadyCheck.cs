using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ReadyCheck : MonoBehaviour
{
    public GameObject press_x, press_down;
    public GameObject Players;

    private CharacterControl control;
    private DateTime ready_time;
    private bool ready_sent, ready_received = false;

    void Start() {
        if (GameSelect.GlobalGame == 1) press_down.SetActive(false);
        if (GameSelect.GlobalGame == 2) press_down.GetComponent<Text>().text = "Waiting...";
        control = Players.GetComponent<CharacterControl>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) {
          press_x.SetActive(false);
          if (GameSelect.GlobalGame == 2 && !ready_sent) {
            StartCoroutine(ReadySend());
            ready_sent = true;
          }
        }
        
        if (GameSelect.GlobalGame == 2 && ready_sent && !ready_received) {
          StartCoroutine(PollForP2());
          ready_received = true;
        } else if (GameSelect.GlobalGame != 2 && Input.GetKeyDown(KeyCode.DownArrow)) {
          press_down.SetActive(false);
        }

        if (!press_x.activeSelf && !press_down.activeSelf) {
          if (GameSelect.GlobalGame == 2 && DateTime.UtcNow >= ready_time) {
            Debug.Log(ready_time);
            gameObject.SetActive(false);
          } else if (GameSelect.GlobalGame != 2) { 
            gameObject.SetActive(false);
          }
        }
    }

    IEnumerator ReadySend() {
      UnityWebRequest www = UnityWebRequest.Get("https://patrickday.dev/standoff/ready");
      yield return www.SendWebRequest();

      if (www.result != UnityWebRequest.Result.Success) { Debug.Log(www.error); }
      else {
        Debug.Log("Successfully sent ready.");
        string player = www.downloadHandler.text;
        control.player = player == "1" ? 1 : 2;
        Debug.Log(control.player);
      }
    }
    IEnumerator PollForP2() {
      while (press_down.activeSelf) {
        yield return new WaitForSeconds(1);

        WWWForm form = new WWWForm();
        form.AddField("player", control.player);
        UnityWebRequest www = UnityWebRequest.Post("https://patrickday.dev/standoff/ready", form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) {
          Debug.Log("Successfully received ready."); 
          press_down.SetActive(false);
          Debug.Log(www.downloadHandler.text);
          long ms = Int64.Parse(www.downloadHandler.text);
          ready_time = DateTimeOffset.FromUnixTimeMilliseconds(ms).DateTime;
          Debug.Log(ready_time);
          Debug.Log(DateTime.UtcNow);
        }
      }
    }
}

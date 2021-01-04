using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelect : MonoBehaviour
{

    public static int GlobalGame;
    // Update is called once per frame
    public void SetGameModeLocal()
    {
        GlobalGame = 0;
        SceneManager.LoadScene("Hill");
    }
    public void SetGameModeAi()
    {
        GlobalGame = 1;
        SceneManager.LoadScene("Hill");
    }
     public void SetGameModeOnline()
    {
        GlobalGame = 2;
        SceneManager.LoadScene("Hill MP");
    }
}

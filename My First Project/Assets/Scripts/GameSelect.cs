using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelect : MonoBehaviour
{
    public CharacterControl game;
    // Update is called once per frame
    public void SetGameMode()
    {
        game.gameMode = 0;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayAgain() {
        SceneManager.LoadScene("Hill");
    }
}

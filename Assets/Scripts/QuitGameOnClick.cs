﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameOnClick : MonoBehaviour {

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

}

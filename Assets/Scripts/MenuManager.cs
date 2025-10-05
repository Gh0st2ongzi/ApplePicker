using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button button;

    private void Awake()
    {
        if (button)
        {
            button.onClick.AddListener(() => SceneManager.LoadScene("_Scene_0"));
        }
    }
}


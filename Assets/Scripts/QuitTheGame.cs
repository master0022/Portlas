using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitTheGame : MonoBehaviour
{
    private bool isMenuOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    private void OnGUI()
    {
        if (isMenuOpen)
        {
            if (GUI.Button(new Rect(10, 10, 100, 30), "Quit"))
            {
                QuitGame();
            }
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }

    private void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
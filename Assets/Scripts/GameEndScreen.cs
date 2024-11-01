using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndScreen : MonoBehaviour
{
    public Button StartGameButton;
    public Button QuitButton;

    public void StartGamePressed()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitPressed()
    {
        Application.Quit();
    }
}

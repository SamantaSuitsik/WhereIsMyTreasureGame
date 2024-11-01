using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button StartGameButton;
    public Button InstructionsButton;
    public Button QuitButton;
    public GameObject InstructionsPanel;

    public void StartGamePressed()
    {
        SceneManager.LoadScene(1);
    }
    
    public void InstrPressed()
    {
        InstructionsPanel.SetActive(true);
    }

    public void QuitPressed()
    {
        Application.Quit();
    }
}

























using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    
    private void Awake()
    {
        Events.OnChangeLives += OnChangeLives;
    }

    private void OnChangeLives(int newLives)
    {
        print("new lives " + newLives);
        livesText.text = "Lives: " + newLives;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

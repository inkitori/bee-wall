using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] TMP_Text survivalText;
    [SerializeField] Transform heartsHolder;

    private float timeSurvived = 0;
    private float beesKilled = 0;
    private int health = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        PersistentData.timeSurvived = 0;
    }

    private void Update()
    {
        timeSurvived += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeSurvived / 60);
        int seconds = Mathf.FloorToInt(timeSurvived % 60);

        survivalText.text = String.Format("{0:00}:{1:00}", minutes, seconds);

        PersistentData.timeSurvived = timeSurvived;
    }

    public void IncrementBeesKilled()
    {
        beesKilled++;
    }

    public void DecrementHealth()
    {
        health--;

        if (health < 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
        else
        {
            heartsHolder.GetChild(health).gameObject.SetActive(false);
        }
    }

}

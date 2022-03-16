using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;

public class UiManager : MonoBehaviour
{
    List<GameObject> levels = new List<GameObject>();
    [SerializeField] PlayerSettings settings;

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject finishPanel;
    [SerializeField] GameObject chestPanel;

    TextMeshPro leveltext;
    TextMeshPro inGameScore;
    TextMeshPro finishGameScore;
    

    void Awake()
    {
        GameObject[] tempLevels = GameObject.FindGameObjectsWithTag("Level");

        foreach (var item in tempLevels)
        {
            levels.Add(item);
        }

        levels = levels.OrderBy(go => go.name).ToList();

        StartLevel();

    }

    void Update()
    {

    }

    private void LoadScene()
    {
        if (settings.level > 0)
        {
            levels[settings.level].SetActive(true);
            levels[settings.level - 1].SetActive(false);
        }
    }

    private void StartLevel()
    {
        levels[settings.level].SetActive(true);

        foreach (var item in levels)
        {
            if (settings.level != levels.IndexOf(item))
            {
                item.SetActive(false);
            }
        }
    }

    public void NextLevel()
    {
        settings.level++;
        LoadScene();
    }

    public void LevelStart()
    {
        startPanel.SetActive(true);
        finishPanel.SetActive(false);
        chestPanel.SetActive(false);
    }

    public void LevelFinished()
    {
        startPanel.SetActive(false);
        finishPanel.SetActive(true);
        chestPanel.SetActive(false);
    }

    public void OpenChest()
    {
        startPanel.SetActive(false);
        finishPanel.SetActive(true);
        chestPanel.SetActive(false);
    }
}

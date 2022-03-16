using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] List<GameObject> levels = new List<GameObject>();
    [SerializeField] PlayerSettings settings;

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject inGamePanel;
    [SerializeField] GameObject finishPanel;
    [SerializeField] GameObject chestPanel;

    TextMeshProUGUI leveltext;
    TextMeshProUGUI finishLeveltext;
    TextMeshProUGUI inGameScore;
    TextMeshProUGUI finishGameScore;
    TextMeshProUGUI finishGameRewardScore;


    void Awake()
    {
        leveltext = inGamePanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        inGameScore = inGamePanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        finishGameScore = finishPanel.transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        finishGameRewardScore = finishPanel.transform.GetChild(0).transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        finishLeveltext = finishPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        levels = levels.OrderBy(go => go.name).ToList();

        StartLevel();

    }
    private void Start()
    {
        settings.score = 0;
        leveltext.text = "Level " + (settings.levelcount + 1).ToString();
        LoadScene();
    }
    void Update()
    {
        inGameScore.text = settings.score.ToString();
        if (settings.isPlaying)
        {
            startPanel.SetActive(false);
        }
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
        settings.allScore += settings.score;
        settings.score = 0;
        settings.level++;
        if (settings.level > levels.Count)
        {
            settings.level = 0;
        }
        SceneManager.LoadScene("SampleScene");
    }

    public void LevelStart()
    {
        startPanel.SetActive(true);
        finishPanel.SetActive(false);
        chestPanel.SetActive(false);
    }

    public void LevelFinished()
    {
        finishGameScore.text = settings.score.ToString();
        finishLeveltext.text = "Level " + settings.level.ToString();
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

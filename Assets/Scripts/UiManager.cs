using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;
using DG.Tweening;
using UnityEditor;

public class UiManager : MonoBehaviour
{
    [SerializeField] List<GameObject> levels = new List<GameObject>();
    [SerializeField] PlayerSettings settings;
    [SerializeField] ToplanmaYeri toplanma;
    [SerializeField] OyunSonu OyunSonu;
     int temp = 0;
    int tempReward = 0;
    int reward;

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject inGamePanel;
    [SerializeField] GameObject finishPanel;
    [SerializeField] GameObject chestPanel;
    [SerializeField] GameObject button;

    TextMeshProUGUI leveltext;
    TextMeshProUGUI finishLeveltext;
    TextMeshProUGUI inGameScore;
    TextMeshProUGUI finishGameScore;
    TextMeshProUGUI finishGameRewardScore;

    void Awake()
    {
        leveltext = inGamePanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        inGameScore = inGamePanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        finishGameScore = finishPanel.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
        finishGameRewardScore = finishPanel.transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>();
        finishLeveltext = finishPanel.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        levels = levels.OrderBy(go => go.name).ToList();

        StartLevel();
    }

    private void Start()
    {
        settings.score = 0;
        leveltext.text = levels[settings.level].name;
        LoadScene();
    }
    void Update()
    {
        inGameScore.text = settings.score.ToString();
    }

    public void StartPanelEnable(bool value)
    {
        startPanel.SetActive(value);
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
        settings.TotalScore += settings.score;
        settings.score = 0;
        settings.level++;
        if (settings.level >= levels.Count)
        {
            settings.level = 0;
        }
        //string matName = settings.index.ToString() + "." + (settings.howManyObjectsOpend-1).ToString() + ".mat";
        //AssetDatabase.CreateAsset(toplanma.duplicate, "Assets/InGameMaterial/" + matName);
        if (settings.howManyObjectsOpend == 3)
        {
            settings.index++;
            settings.howManyObjectsOpend = 0;
        }
        if (settings.index > 1)
        {
            settings.index = 0;
        }
        SceneManager.LoadScene("SampleScene");
    }

    public void LevelStart()
    {
        startPanel.SetActive(true);
        finishPanel.SetActive(false);
        chestPanel.SetActive(false);
        button.SetActive(false);
    }

    public void LevelFinished()
    {
        finishLeveltext.text =levels[settings.level].name;
        startPanel.SetActive(false);
        finishPanel.SetActive(true);
        StartCoroutine(LevelFinishDelay());
        chestPanel.SetActive(false);
        button.SetActive(true);
    }

    public void OpenChest()
    {
        startPanel.SetActive(false);
        finishPanel.SetActive(true);
        chestPanel.SetActive(false);
        button.SetActive(false);
    }


    IEnumerator LevelFinishDelay()
    {
        reward = Mathf.RoundToInt(settings.score / 20); ;
        yield return new WaitForSeconds(0.2f);
        finishPanel.transform.GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(0, 0.2f);
        while (temp < settings.score)
        {
            temp += (int)((settings.score / 5f) + temp + 10);
            if (temp > settings.score)
            {
                temp = settings.score;
            }
            finishGameScore.text = temp.ToString();
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0.5f);
        finishGameRewardScore.gameObject.SetActive(true);
        while (tempReward < reward)
        {
            tempReward++;
            finishGameRewardScore.text = tempReward.ToString();
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.7f);
        button.SetActive(true);
        button.GetComponent<RectTransform>().DOScale(new Vector3(2,6,2), 1f).SetEase(Ease.OutBack);

    }
}

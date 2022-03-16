using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] public PlayerSettings settings;
    [SerializeField] Text collectScoreText;
    [SerializeField] Text scoreText;
    [SerializeField] Text animText;
    [SerializeField] Text finishScore;
    [SerializeField] GameObject secondCam;
    [SerializeField] WoodStack woodStack;

    public static bool levelFinish;
    public int score;
    public UiManager UImanager;

    private int collectscore;
    private int AnimPuan;

    [SerializeField] Animation anim;

    private void Awake()
    {
        settings.isPlaying = false;
    }
    void Start()
    {
        UImanager = FindObjectOfType<UiManager>();
        EventManager.Event_OnCharacterAnimControl(false);
        levelFinish = false;
        //finishScore.gameObject.GetComponent<Animation>();
    }

    public void LevelFinish()
    {

        UImanager.LevelFinished();   //level complete paneli açýlmasý
    }

    public void FinishFirstTouch()
    {
        levelFinish = true;
        secondCam.SetActive(true);
    }
    public int InstantieWood()
    {
        List<WoodScript> listWood = woodStack.woods;

        float InstantieModelindex = (float)(collectscore / listWood.Count);
        int tutucu = (int)InstantieModelindex;
        if (InstantieModelindex > (tutucu + 0.3f))
        {
            return tutucu + 1;
        }
        else
        {
            return tutucu;
        }
    }

    public void waitAnimPuan() // Increase Skordaki animText animasyon eventi
    {
        AnimPuan = 0;
        animText.gameObject.SetActive(false);
    }
    public void IncreaseScore(int puan)
    {
        CancelInvoke();

        AnimPuan += puan;
        collectscore += puan;
        settings.score += puan;
        animText.color = Color.yellow;
        animText.text = "+" + AnimPuan.ToString();
        collectScoreText.text = "$ " + collectscore.ToString();
        animText.gameObject.SetActive(false);
        animText.gameObject.SetActive(true);
        Invoke("waitAnimPuan", 0.4f);

    }
    public void RestScore(int puan)
    {
        AnimPuan = 0;
        AnimPuan += puan;
        animText.color = Color.red;
        animText.text = "-" + (collectscore - puan);
        collectscore = puan;
        collectScoreText.text = "$ " + collectscore.ToString();
        animText.gameObject.SetActive(false);
        animText.gameObject.SetActive(true);
    }

    public void LastScore(int puan)
    {

        score += puan;
        //scoreText.text = score.ToString();
        anim.Stop();
        //anim.Play("Scale"); 
        //if (!settings.isPlaying)
        //{
        //    tempScore += puan;
        //    finishScore.text = tempScore.ToString();
        //}
    }

    private void OnEnable()
    {
        EventManager.OnIncreaseScore += IncreaseScore;
        EventManager.OnLastScore += LastScore;
        EventManager.OnLevelFinish += LevelFinish;
        EventManager.OnRestScore += RestScore;
        EventManager.FinishFirstTouch += FinishFirstTouch;
    }
    private void OnDisable()
    {
        EventManager.OnIncreaseScore -= IncreaseScore;
        EventManager.OnLevelFinish -= LevelFinish;
        EventManager.OnLastScore -= LastScore;
        EventManager.OnRestScore -= RestScore;
        EventManager.FinishFirstTouch -= FinishFirstTouch;

    }
}

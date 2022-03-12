using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerSettings settings;
    private Transform characterT;
    public static bool levelFinish;
    [SerializeField] Text collectScoreText;
    [SerializeField] Text scoreText;
    [SerializeField] Text animText;
    [SerializeField] GameObject secondCam;
    [SerializeField] WoodStack woodStack;
    public int score;

    private int collectscore;
    private int AnimPuan;

    private void Awake()
    {
        settings.isPlaying = false;
    }
    void Start()
    {
        characterT = FindObjectOfType<CharacterMove>().transform;
        levelFinish = false;
    }

    public void FinishGame()
    {
        if(!levelFinish)
        {
            levelFinish = true;
            characterT.position = new Vector3(0f, characterT.position.y, characterT.position.z);
            secondCam.SetActive(true);
        }
        
    }
    public int InstantieWood()
    {
        List<WoodScript> listWood = woodStack.woods;

        float InstantieModelindex = (float)(collectscore / listWood.Count);
        int tutucu = (int)InstantieModelindex;
        if (InstantieModelindex > (tutucu + 0.3f))
        {
            return tutucu+1;
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
        scoreText.text = score.ToString();
    }

    private void OnEnable()
    {
        EventManager.OnIncreaseScore += IncreaseScore;
        EventManager.OnLastScore += LastScore;
        EventManager.OnFinishGame += FinishGame;
        EventManager.OnRestScore += RestScore;
    }
    private void OnDisable()
    {
        EventManager.OnIncreaseScore -= IncreaseScore;
        EventManager.OnFinishGame -= FinishGame;
        EventManager.OnLastScore -= LastScore;
        EventManager.OnRestScore -= RestScore;
    }
}

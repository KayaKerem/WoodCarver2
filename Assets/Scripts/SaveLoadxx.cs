using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SaveLoadxx : MonoBehaviour
{
    [SerializeField] PlayerSettings settings;

    int level;
    int index;
    int howManyObjectsOpend;
    int TotalScore;

    //private void Awake()
    //{
    //    if (PlayerPrefs.HasKey("level"))
    //    {
    //        level = PlayerPrefs.GetInt("level");
    //        settings.level = level;
    //    }

    //    else
    //    {
    //        PlayerPrefs.SetInt("level", 0);
    //    }

    //    if (PlayerPrefs.HasKey("index"))
    //    {
    //        index = PlayerPrefs.GetInt("index");
    //        settings.index = index;
    //    }

    //    else
    //    {
    //        PlayerPrefs.SetInt("index", 0);
    //    }

    //    if (PlayerPrefs.HasKey("howManyObjectsOpend"))
    //    {
    //        howManyObjectsOpend = PlayerPrefs.GetInt("howManyObjectsOpend");
    //        settings.howManyObjectsOpend = howManyObjectsOpend;
    //    }

    //    else
    //    {
    //        PlayerPrefs.SetInt("howManyObjectsOpend", 0);
    //    }


    //    if (PlayerPrefs.HasKey("TotalScore"))
    //    {
    //        TotalScore = PlayerPrefs.GetInt("TotalScore");
    //        settings.TotalScore = TotalScore;

    //    }

    //    else
    //    {
    //        PlayerPrefs.SetInt("TotalScore", 0);
    //    }



    //}
}

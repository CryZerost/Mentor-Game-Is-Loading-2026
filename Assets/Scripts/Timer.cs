using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerMin = 5f;
    public float timerSec = 0f;

    public TMP_Text timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ClickAction()
    {
        StartCoroutine(DayTimer());
    }

    void UpdateUI()
    {
        timerText.text = $"Sisa waktu:{Mathf.Round(timerMin).ToString()} Menit {Mathf.Round(timerSec).ToString()} Detik";
    }

    //public IEnumerator DayTimer()
    //{
    //    while (timerSec > 0)
    //    {
    //        timerSec -= Time.deltaTime;

    //        if (timerSec <= 0)
    //        {

    //            if (timerMin <= 0)
    //            {
    //                timerText.text = "You Win";
    //            }
    //            else if (timerMin > 0) 
    //            {
    //                timerMin -= 1;
    //                timerSec = 59;
    //            }
    //            UpdateUI();
    //            yield return null;
    //        }
    //        UpdateUI();
    //        yield return null;
    //    }
    //    yield return null;
    //}

    public IEnumerator DayTimer()
    {
        while (timerMin > 0 || timerSec > 0)
        {
            timerSec -= Time.deltaTime;

            if (timerSec < 0)
            {
                if (timerMin > 0)
                {
                    timerMin--;
                    timerSec += 60;
                }
                else
                {
                    timerSec = 0;
                }
            }

            UpdateUI();
            yield return null;
        }

       RestartCountdown();
    }

    private void NextLevel()
    {
        timerText.text = "You Win";
    }

    private void RestartCountdown()
    {
        timerMin = 5;
        timerSec = 60f;
       
    }
}

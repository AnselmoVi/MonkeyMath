using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerLvl2 : MonoBehaviour
{
    float t = 0.0f;
    Text timer;
    float deltatime;
    int second;
    float minutes;
    float colortime = 0;
    int resto;
    int addtime;
    bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Text>();
        timerAct();
    }

    // Update is called once per frame


    void Update()
    {

        deltatime += Time.deltaTime;
        timerAct();

    }



    private void timerAct()
    {

        //deltatime = deltatime - addtime;


        if (deltatime >= 60)
        {

            minutes += 1;
            deltatime = 0;
        }

        if (deltatime < addtime && addtime > 0) // 20-10 -> 10 10-10= 0s 7s-10s-> 60-3s 2m 03 -> 2m (03-10)-> 2m (-7s)-> 1m (53s)
        {



            if (minutes == 0)
            {
                deltatime = 0;
                minutes = 0;
                addtime = 0;
            }
            else
            {
                resto = (60 - addtime);
                deltatime = deltatime + resto;
                resto = 0;
                addtime = 0;
                minutes = minutes - 1;

            }
        }
        else
        {
            if (addtime > 0)
            {
                deltatime = deltatime - addtime;
                addtime = 0;
            }
        }


        if (minutes == 2 && stop == false)
        // if (second == 20) // per debug
        {
            endGame();
            stop = true;
        }

        if (minutes >= 2 && deltatime > 0)
            timer.text = "XD";

        else
        {
            if ((int)deltatime <= 9)
                timer.text = minutes + ":0" + (int)deltatime;
            else timer.text = minutes + ":" + (int)deltatime;
        }



        if ((int)deltatime == 53 && minutes == 1)
        {
            gameObject.GetComponent<Animation>().Play();


            if (SoundManager.GetSuona())
            {
                gameObject.GetComponent<AudioSource>().Play();
            }

        }



        addtime = 0;
    }


    private void endGame()
    {
        SavePoints.PointPlayerSet();
        //Resources.Load<GameObject>("Assets/Prefab/Banana.prefab")
        GameObject.Find("ManagerBanana").GetComponent<ManagerBananaLvl2>().setEndGame();
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        // SceneManager.LoadScene("Schermata_Iniziale", LoadSceneMode.Single);
    }


    public void TimeAdd(int add)
    {

        addtime = add;


    }


}

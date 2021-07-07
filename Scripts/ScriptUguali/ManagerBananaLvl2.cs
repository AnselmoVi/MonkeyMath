using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBananaLvl2: MonoBehaviour
{
    [SerializeField] private GameObject[] grappolo;
    [SerializeField] private GameObject banana;
    [SerializeField] private GameObject bananaSpawn;
    public bool EndGame;
    private int counter = 0;
    private bool bananaFound = false;
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;
    int first = 0;
    Rigidbody rb;

    private void Start()
    {
        grappolo = new GameObject[50]; //Riempio il vettore dell'oggetto Banana che verrà lanciata

        for (int i = 0; i < grappolo.Length; i++)
        {
            grappolo[i] = GameObject.Instantiate(banana);
            grappolo[i].gameObject.SetActive(false);
        }
    }

    void Awake()
    {
        EndGame = false;
    }


    void Update()
    {


        //if (Input.GetKeyDown("space")){ //Funzione per lanciare la banana con lo spazio, usata per il debug, bisogna decommentare una riga in BananaBella per funzionare
        //  lancia();
        //}



        ///Nel momento in cui inizio lo swipe 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            //Se si tocca lo schermo tiene conto del tempo che passa dall'inizio a quando si rilascia
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

            //Segna quando si è rilasciato il dito
            touchTimeFinish = Time.time;


            timeInterval = touchTimeFinish - touchTimeStart;

            //Posizione dove è stato rilasciato il dito
            endPos = Input.GetTouch(0).position;

            //direzione nello spazio del lancio
            direction = startPos - endPos;

            if (EndGame == false)
                lancia();
        }

    }

    void lancia()  //Funziona copiata dal progetto svolto dal professore, attiva il primo oggetto in scena disattivato e scorre
    {
        bananaFound = false;
        while (!bananaFound)
        {
            for (int i = counter; i < grappolo.Length; i++)
            {
                if (!grappolo[i].activeInHierarchy)
                {
                    counter = i;

                    grappolo[i].GetComponent<Bananalvl2>().Spawn(bananaSpawn.transform, direction, timeInterval); // va a prendere LO SCRIPT 


                    bananaFound = true;
                    break;
                }

            }
            if (counter == grappolo.Length - 1)
                counter = 0;
        }
    }
    public void setEndGame()
    {
        EndGame = true;
    }
}



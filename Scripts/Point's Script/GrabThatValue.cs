using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabThatValue : MonoBehaviour
{
    GameObject ob;
    public static GrabThatValue instance;
    public int punteggio = 0;
    public string punti;
    
   


    void Awake()
    {
        instance = this;

    }

    public void Start()
    {

        gameObject.GetComponent<TextMesh>().text = punteggio.ToString(); //Inserisco il punteggio attuale nel suo contenitore in scena



    }

    public void addPunteggio()  //Incrementa il punteggio, questa funziona è evocata quando si colpisce la scimmia esatta
    {

        punteggio = punteggio + 1;
        if (punteggio == 5)
        {
            if (!PlayerPrefs.HasKey("unlock")) PlayerPrefs.SetInt("unlock", 1);
            PlayerPrefs.SetInt("unlock", 1);
        }
        gameObject.GetComponent<TextMesh>().text = punteggio.ToString();
    }

    public int getPunteggio()
    {


        return punteggio;


    }




  

    }



   


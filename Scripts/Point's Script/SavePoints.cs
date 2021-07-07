using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;




public static class SavePoints
{
    // Start is called before the first frame update
    static private string name;
    static private string namePlayer;
    static private int pointsPlayer;
    static private int point;
    static private int index;
    static private string indexPoint;
    static private string indexPlayer;

    // Update is called once per frame
    private static void Start()
    {
        if (!PlayerPrefs.HasKey("index")) PlayerPrefs.SetInt("index", 0);
        // if (!PlayerPrefs.HasKey("index")) PlayerPrefs.SetInt("index", 0);
        //if (!PlayerPrefs.HasKey("index")) PlayerPrefs.SetInt("index", 0);

        index = PlayerPrefs.GetInt("index");
    }


    public static void NamePlayerSet(String nPlayer)
    {

        namePlayer = nPlayer;
        PlayerPrefs.SetString("tempPlayer", namePlayer);

        PlayerPrefs.Save();
    }

    public static void PointPlayerSet()
    {
        pointsPlayer = GrabThatValue.instance.getPunteggio();
        //qua entr
        Debug.Log("Stampo il valore appena preso");


        PutNewPlayer();


    }


    private static void PutNewPlayer()
    { //ogni volta che chiamo la funzione incremento l'index, che servirà come chiave. 

        // name = PlayerPrefs.GetString(index.ToString());
        //point = PlayerPrefs.GetInt(index.ToString());
        index = PlayerPrefs.GetInt("index");
        Debug.Log(index.ToString());

        for (int i = 0; i < index + 1; i++)
        {
            if (index < 10)  //se ancora non ho inserito 10 persone 
            {
                //entra

                InsertFirstTen();
                break;
            }

            else //se le ho inserite
            {
                point = PlayerPrefs.GetInt("P" + i.ToString());
                if (pointsPlayer > point)
                {
                    InsertPlayer(i);
                    break;
                }
            }


        }

    }

    private static void InsertPlayer(int i)
    {
        //Sostituisco il player con il punteggio migliore


        PlayerPrefs.SetInt("P" + i.ToString(), pointsPlayer);
        PlayerPrefs.Save();
        PlayerPrefs.SetString("G" + i.ToString(), PlayerPrefs.GetString("tempPlayer"));

        PlayerPrefs.Save();


    }


    public static void InsertFirstTen()
    {
        bool inserito = true;
        //se è il primo inserimento
        if (index == 0)
        {

            Insert();
        }
        else
        {

            for (int i = 0; i < index; i++)
            {
                //scorro tutte le posizioni inserito fino ad adesso, se non le trovo allora 

                if (pointsPlayer > PlayerPrefs.GetInt("P" + i.ToString()))
                {
                    InsertfirstTen(i);
                    inserito = false;
                    break;
                }
                //se non sono uscito inserisco il valore


            }

            if (inserito) Insert();
        }


    }

    private static void Insert()
    {

        indexPlayer = "G" + index.ToString();
        PlayerPrefs.SetString(indexPlayer, PlayerPrefs.GetString("tempPlayer"));// "G1" LUCA
        PlayerPrefs.Save();




        indexPoint = "P" + index.ToString(); //P1 "0"

        PlayerPrefs.SetInt(indexPoint, pointsPlayer); // P1,  20
        PlayerPrefs.Save();

        index = index + 1;

        PlayerPrefs.SetInt("index", index);//incremento l'index per il prossimo

        PlayerPrefs.Save();

    }


    public static string[] GetBestTen(int i)
    {
        var array = new string[2];

        int punti;
        Debug.Log(i.ToString());

        array[0] = PlayerPrefs.GetString("G" + i.ToString());
        Debug.Log(array[0]);

        punti = PlayerPrefs.GetInt("P" + i.ToString());
        Debug.Log(punti.ToString());
        array[1] = punti.ToString();
        Debug.Log(array[1]);

        return array;

    }

    private static void InsertfirstTen(int i)
    {
        string oldvaluePoints;
        string oldvaluePlayer;
        string newvaluePlayer;
        string newvaluePoints;
        int vecchipoints;


        for (int j = (index); j >= i; j--)
        {



          oldvaluePlayer = "G" + (j).ToString();
        // "G1" LUCA
          oldvaluePoints = "P" + (j).ToString(); //P1 "0"
            
        // P1,  20
            newvaluePlayer = "G" + (j+1).ToString();
            newvaluePoints = "P" + (j+1).ToString();
            PlayerPrefs.SetString(newvaluePlayer, PlayerPrefs.GetString(oldvaluePlayer));// "G1" LUCA
            PlayerPrefs.Save();
            PlayerPrefs.SetInt(newvaluePoints, PlayerPrefs.GetInt(oldvaluePoints)); // P1,  20
            PlayerPrefs.Save();

        }


        indexPlayer = "G" + i.ToString();
        PlayerPrefs.SetString(indexPlayer, PlayerPrefs.GetString("tempPlayer"));// "G1" LUCA
        PlayerPrefs.Save();




        indexPoint = "P" + i.ToString(); //P1 "0"

        PlayerPrefs.SetInt(indexPoint, pointsPlayer); // P1,  20
        PlayerPrefs.Save();

        index = index + 1;
        PlayerPrefs.SetInt("index", index);//incremento l'index per il prossimo


        PlayerPrefs.Save();

    }

}

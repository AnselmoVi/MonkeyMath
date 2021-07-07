using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro; // Make sure you include the TextMesh Pro Namespace


public class LVLEQUAZIONI : MonoBehaviour
{
    public static LVLEQUAZIONI instance;
    private Text eq;
    private string stringa;
    private int x, y = 0;
    public int soluzione = 0;
    private Font mfont;


    // Questo script è attaccato all'oggetto cartello
    void Awake()
    {
        instance = this;

    }

    public void generate()
    {    //Evocata in ManagerEquation genera randomicamente un'equazione 
        x = Random.Range(1, 9);
        y = Random.Range(1, 9);

        if(x>=y)
        soluzione = x - y;

        if(y>x)
            soluzione = y - x;



        var newTextComp = gameObject.GetComponent<TextMesh>();

        if (x >= y)
        
            newTextComp.text = x + "-" + y; //inserisco nel campo testo l'equazione generata


        if (y > x)
            newTextComp.text = y + "-" + x; //inserisco nel campo testo l'equazione generata



    }

    public int getSoluzione()
    {

        return soluzione;


    }





}

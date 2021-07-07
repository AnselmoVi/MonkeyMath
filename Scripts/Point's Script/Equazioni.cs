using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro; // Make sure you include the TextMesh Pro Namespace


public class Equazioni : MonoBehaviour
{
    public static Equazioni instance;
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

        public  void generate() {    //Evocata in ManagerEquation genera randomicamente un'equazione 
        x = Random.Range(1, 5);
        y = Random.Range(0, 4);

        
        soluzione = x + y;
        
       
 
        var newTextComp = gameObject.GetComponent<TextMesh>();

        newTextComp.text =  x + "+" + y  ; //inserisco nel campo testo l'equazione generata

        

    }

    public int getSoluzione()
    {

        return soluzione;

        
    }

    



}

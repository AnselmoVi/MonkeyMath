using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class option : MonoBehaviour
{
    public static option instance;
    [SerializeField] Slider z, xy, t;
  
    bool first = true;
    float zv, xyv, tv;
    int setting = 0;
    
   

    // Script per far modificare al giocatore la forza del lancio

    void Awake()
    {

        instance = this;


    }

    private void SaveSetting()
    {
     
        PlayerPrefs.SetInt("SaveSetting", 1); //Se modifico i valori metto questa variabile ad uno così  verrà letta ad inizio del lancio così se è stato modificato salvo i nuovi valori
     
    }

    

    public void getZ() {              //Queste funzioni vengono chiamate dai due Slider nel menu. Una volta modificato il valore della z e della xy, metto ad 1 la variabile
        zv = z.value;
        PlayerPrefs.SetFloat("zeta", zv);
        SaveSetting();
    }
    public void getXY()
    {
        xyv = xy.value;
        PlayerPrefs.SetFloat("xy", xyv);
        SaveSetting();
    }

 
   

    public float Returnz() {
        return PlayerPrefs.GetFloat("zeta");

    }

    public float Returnxy()
    {
        return   PlayerPrefs.GetFloat("xy");

    }



   

}

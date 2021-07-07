using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class SoundManager
{
    
    
    // Setta il valore che disattiva il suon. Viene da ogni oggetto in scena che un suono

    public static void SetSuona() {
        
      

        if (PlayerPrefs.GetInt("Mute") == 1)
        {
            
            PlayerPrefs.SetInt("Mute", 0);
        } else

        { PlayerPrefs.SetInt("Mute", 1);  }

        PlayerPrefs.Save();
    }


    public static bool GetSuona()
    {

        if (PlayerPrefs.GetInt("Mute") == 1)
        {

          
            return true;
        }
            
        else return false;

    }



}
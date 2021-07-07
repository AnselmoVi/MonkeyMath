using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundMute : MonoBehaviour
{
    [SerializeField] Sprite sound;
    [SerializeField] Sprite Mute;
    GameObject g;


    // Cambia l'icona della musica nella schermata opzioni

    public static void Awake()
    {
       
    }
    public void Start()
    {

       
        if (SoundManager.GetSuona())  //1 e' Attivo
            gameObject.GetComponent<Image>().sprite = sound;
        else gameObject.GetComponent<Image>().sprite = Mute;

    }
    public void SoundOnOFf()
    {
        SoundManager.SetSuona();

        
            g = GameObject.FindGameObjectWithTag("Music");
            g.GetComponent<DontDestroy>().CheckSound();


        
        if (SoundManager.GetSuona())  //1 e' Attivo
            gameObject.GetComponent<Image>().sprite = sound;
        else gameObject.GetComponent<Image>().sprite = Mute;

    }



   


    
}

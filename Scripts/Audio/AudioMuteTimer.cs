using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMuteTimer : MonoBehaviour
{
    //Distruggo la musica del menù dato che ne metto un'altra in lvl1
    GameObject A;
    void Awake()
    {
        A = GameObject.FindGameObjectWithTag("Music");
        Destroy(A);
        
    }
    
    void Start()
    {
        
        
            if (SoundManager.GetSuona())                     // Se l'utente ha impostato la musica nel menu iniziale allora deve partire la musica
            gameObject.GetComponent<AudioSource>().Play();
        
           
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    /// <summary>
    /// Faccio sì che l'oggetto che contiene il component della musica non venga distrutto durante il carimento delle altre scene
    /// </summary>
    
    void Start()
    {
        if (!PlayerPrefs.HasKey("Mute")) PlayerPrefs.SetInt("Mute",1); // Se è la prima volta che lancio il gioco la musica deve essere attiva

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music"); // Funzione implementata per evitare che ci siano due oggetti Music in scena u
        if (objs.Length > 1)                                            // quando torno nella stessa scena 
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        CheckSound();
    }


    public void CheckSound()                                     //
    {
        
        if (SoundManager.GetSuona())        
            gameObject.GetComponent<AudioSource>().Play();

     
     
        if (!SoundManager.GetSuona()) 
           gameObject.GetComponent<AudioSource>().Stop(); 


    }

   
}

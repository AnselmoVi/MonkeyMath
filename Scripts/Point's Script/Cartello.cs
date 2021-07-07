using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartello : MonoBehaviour
{

    Transform spawn;

    public void Spawn( Transform spawnCartello)
    {

        gameObject.SetActive(true);   //Attivo l'oggetto in scena
        

        transform.position = spawnCartello.position;

    }


    public void DeSpawn() {

        gameObject.SetActive(false);
    }


   

    
}
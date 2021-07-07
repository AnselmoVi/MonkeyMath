using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMonkey : MonoBehaviour
{
    [SerializeField] private float speed; //velocità con cui si muovono le scimmie
    [SerializeField] private Transform Confine, Spawn2; //confini
    int Direzione = 0;
    Vector3 nfix;
    Vector3 sfix;
    bool fix = false;
    bool righposition = true;
    float f;
    float z;
    public void Awake()   //salvo la posizione dei confini in scena
    {
        Spawn2 = GameObject.Find("Spawn2").transform;
        Confine = GameObject.Find("Confine").transform;   
    }


    public void Spawn(Transform spawnPosition)
    {

        gameObject.GetComponent<BoxCollider>().enabled = true; //Quando la scimmia è colpita cade dall'albero, quindi qui riattivo i suoi componenti statici altrimenti cadrebbe all'infinito
                                                                        // una volta riattivata in scena
        gameObject.GetComponent<Rigidbody>().isKinematic = true; // Per ottimizzare bisogna creare qui una funzione che attivao disattiva i componenti controllando una variabile
        gameObject.SetActive(true);
        

        transform.position = spawnPosition.position;
        // nfix = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().transform.position; //spawn1 per il numero
        nfix= transform.position = spawnPosition.position;
        z = nfix.z;
        z = z - 0.005f;
        nfix.z = z;

        sfix = Spawn2.transform.position; //spawn 2
        f = sfix.x;
        z = sfix.z;
        z = z - 0.15f;
        f = f+0.25f;
        sfix.x = f;
        sfix.z = z;

    }



    void Update()   //Muovo la scimmia verso sinistra, poi una volta oltrepassato il confine, si teletrasporta nel ramo di sotto andando verso sinistra e infine si disattiva in scena
    {
        

        if (Direzione == 0)
        {
            if (transform.position.x > Spawn2.position.x)
            {
                if (fix == false)
                {
                   gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().transform.position = nfix;
                    fix = true;
                }
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
               
                  
                    
            
            }
            else
            {
                transform.position = Spawn2.position;
                Direzione = 1;
            }
        }

        if (Direzione == 1)
        {
            if (transform.position.x < Confine.position.x)
            {
                if (fix == true) {
                    
                    gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().transform.position = sfix;
                    fix = false;                 
                }
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
               
            }
            else
            {

                gameObject.SetActive(false);
                Direzione = 0;
            }
        }
    }

    void OnBecameInvisible()
    {
       // gameObject.SetActive(false);
    }


    public string getNumber() //Restituisce il numero che porta la scimmietta
    {
        return gameObject.tag;

    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT : MonoBehaviour
{
    Vector3 v1;

    // Fa sì la scritta "+10 Second" una volta colpito il powerUp appaia nell'esatta posizione di collisione tra la banana e il pappagallo



    public void Awake()
    {
        v1 = gameObject.transform.position; 
    }


     
    public void  BonusAnimate(Vector3 v)
    {


        StartCoroutine(BonusAni(v));

    }

    public IEnumerator BonusAni(Vector3 v)  //Attiva e disattiva l'animazione dopo tot secondi
    {


        var inv = new WaitForSeconds(1.2f);
        

            gameObject.transform.position = v;
            gameObject.GetComponent<Animator>().SetBool("Colpito", true); // Fa partire l'animazione
            
            yield return inv;
            gameObject.transform.position = v1;
            gameObject.GetComponent<Animator>().SetBool("Colpito", false);
           


        
    }

}

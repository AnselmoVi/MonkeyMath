using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUplvl2 : MonoBehaviour
{
    int bonus;
    bool touch;



    // Spawna il pappagallo che da 10 secondi in più


    public void Spawn()
    {



        gameObject.SetActive(true);

        gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;


        bonus = 10;  // Nel caso di implentazione di un secondo pappagalo magari Rosso che dia +20 secondi, il valore bonus 
                     //sarà  dato tramite Tag.


        StartCoroutine(GetOut());  // Coroutine  per far sì che il powerUp si disattivi in scena se non viene preso
        StartCoroutine(Sound());   // Coroutine per far sì che randomicamente il powerUp emetta un suono



    }

    public void CollisioneAvvenuta(Collision collision)
    {
        Vector3 v = new Vector3();
        GameObject.Find("TimerText").GetComponent<TimerLvl2>().TimeAdd(bonus); // Aggiungi il tempo bonus
        GameObject.Find("ManagerPowerUp").GetComponent<ManagerPowerUplvl2>().SetTouch(); // Setta la condizione per far nascere un nuovo PowerUp
        gameObject.GetComponent<AudioSource>().Play();


        v = collision.transform.position;
        GameObject.Find("BonusText").GetComponent<BT>().BonusAnimate(v);  // Faccio comparire "+10Secondi" dove hanno colliso il pappagallo 
                                                                          // e la banana
        gameObject.SetActive(false);  //Disattivo il pappaggalo in scena.


    }

    private IEnumerator GetOut()
    {

        var wait = new WaitForSeconds(12f);
        var inv = new WaitForSeconds(3f);
        while (true)
        {

            yield return wait;
            GameObject.Find("ManagerPowerUp").GetComponent<ManagerPowerUplvl2>().SetTouch();// Setta la condizione per far nascere un nuovo PowerUp
            gameObject.GetComponent<Animator>().SetBool("Exit", true); //Setta la condizione per far partire l'animazione nell'Animator
            gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false; //Disattivo il Box Collider Altrimenti se viene preso in questa fase toglie troppi secondi
            yield return inv;
            gameObject.GetComponent<Animator>().SetBool("Exit", false); //Lo rimetto a false altrimenti rinasce e parte con l'animazione
            gameObject.SetActive(false);

        }
    }



    private IEnumerator Sound()
    {
        while (true)
        {
            var w = new WaitForSeconds(Random.Range(2, 4));
            yield return w;

            if (SoundManager.GetSuona())
            {
                gameObject.GetComponent<AudioSource>().Play();
            }

        }

    }




}





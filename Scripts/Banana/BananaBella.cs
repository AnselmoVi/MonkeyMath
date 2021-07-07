using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BananaBella : MonoBehaviour
{

    Animator animator;
    GameObject cartello;
    Rigidbody rb;
    [SerializeField]
    public float throwForceInXandY;
    public float throwForceInZ; // to control throw force in Z direction
    Vector2  endPos, direction;
    public float timeInterval;
    GameObject carte;
    int prova = 0;
   
    float delayTime = 0;
    Vector3 vectorofscale;
    
    

    public void ChangeValue() {       
       throwForceInXandY = option.instance.Returnxy();
       throwForceInZ = option.instance.Returnz();     
    
    }
    
    public void Spawn(Transform spawnPosition, Vector2 directionPosizione, float Time)
    {       
        
        direction = directionPosizione;
        timeInterval = Time;
        transform.position = spawnPosition.position;
        //Fine V. lancio

        

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        gameObject.SetActive(true);



        if (PlayerPrefs.GetInt("SaveSetting") == 1) {  //Se il player ha modificato la forza del lancio nel menu opzioni, allora caricale.
            ChangeValue();
            
        }

        
           
            rb.AddForce(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ / timeInterval); //Commenta se si vuole usare la spacebar per lanciare la banana
          //rb.AddForce(250, 250, 1000);  //Decommenta se si vuole utilizzare per il lancio la spacebar
    }



 
    

    void OnBecameInvisible()
    {
    
         //Setto a zero il movimento della banana, altrimenti quando verrà attivatà avrà i valori di quando è stata deattivata.
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
       gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        //rb.isKinematic = true; //Rendo la banana statica 

        //Se la banana ha colpito la scimmia che porta il numero che risolve l'equazione, allora entra nell'if
        if (other.gameObject.tag == GameObject.Find("ManagerEquation").GetComponent<ManagerEquation>().confronta().ToString())
         
        {
           
            GameObject.Find("ManagerEquation").GetComponent<ManagerEquation>().incrementa(); //Evoca la funzione per scorrere di uno l'array delle  soluzioni


            GrabThatValue.instance.addPunteggio(); // Evoca la funzione per aggiungere +1 al punteggio
              
              
           GameObject.Find("ManagerEquation").GetComponent<ManagerEquation>().lancia(); //Evoca la funzione per scorrere di uno l'array delle equazioni
            GameObject.Find("Cartello(Clone)").GetComponent<Cartello>().DeSpawn(); //Disattiva la vecchia eq in scena

           //La scimmietta colpita cade dal tronco
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;

            if (SoundManager.GetSuona())
            {
                gameObject.GetComponent<AudioSource>().Play();
            }

        }



    }


}
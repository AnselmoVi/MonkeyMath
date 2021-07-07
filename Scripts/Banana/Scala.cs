using UnityEngine;
using System.Collections;

public class Scala : MonoBehaviour
{
    public Camera cam;
    [SerializeField] public float objectScale = 1f;

    private Vector3 initialScale;
    private Vector3 forwardBanana;
    private Vector3 PositionBanana;
    private Vector3 NotZero;
    Plane plane;
                                    /// <summary>
                                     /// Questo script serve per diminuire le dimensioni della banana, in modo da dare il senso di profondità
                                     /// </summary>
    void Start()
    {
         //Salvo il valore iniziale delle dimensioni della banana prima del lancio
        initialScale = transform.localScale;
        NotZero = new Vector3(0.1f, 0.1f, 0.1f);
        forwardBanana = GameObject.Find("bananaSpawn").transform.forward;  //Inserisco le coordinate di bananaSpawn, un oggetto vuoto dove spawna la banana da lanciare
        PositionBanana = GameObject.Find("bananaSpawn").transform.position;
        plane = new Plane(forwardBanana, PositionBanana); //creo un piano che passa per bananaSpawn
    }

   
    void Update()             
    {
       // Plane plane = new Plane(forwardBanana, PositionBanana); //creo un piano che passa per bananaSpawn
        float dist = plane.GetDistanceToPoint(transform.position); //calcolo la distanza da bananaSpawn
        dist = dist + 0.00000001f; //Evito che la distanza sia zero
     
        transform.localScale = (initialScale * objectScale) / dist + NotZero; //Diminuisco frame per frame la dimensione
      
    }
    void OnBecameInvisible()
    {


        transform.localScale = initialScale; //prima di disattivare l'oggetto lo faccio tornare alle sue dimensioni originali altrimenti quando verrà riattivato nascerà piccolo


      
        gameObject.SetActive(false);
    }

}

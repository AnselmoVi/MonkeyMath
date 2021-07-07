using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ManagerEquation : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private GameObject cartello; //Contenitore dell'equazione
   
    private GameObject[] lvl1; //Array per l'equazione
     
   private GameObject somma,sottrazione;
   
    [SerializeField] private GameObject eqSpawn;
  
    private bool nexteq = false;
    private int counter = 0;
    private bool monkeyFound = false;
    private int x, y = 0;
    private string stringa;
    public int[] array;
    private int index = 0;
    private int index2 = 0;



    void Awake()
    {
        array = new int[50];//ARRAY DELLE SOLUZIONI DELLE EQUAZIONI
        lvl1 = new GameObject[number]; //Numero di equazioni da far apparire nel livello 
        

        //Ho 10 tipologie di scimmie, alterno randomicamente
        for (int i = 0; i < lvl1.Length; i++)
        {
            
            
            lvl1[i] = GameObject.Instantiate(cartello); // Creo il contenitore
          
            lvl1[i].GetComponent<Equazioni>().generate(); // inserisco l'eq generata randomicamente come oggetto figlio del cartello
            array[i]=lvl1[i].GetComponent<Equazioni>().getSoluzione(); // inserisco la soluzione dell'eq appena generata, in questo array 
            lvl1[i].SetActive(false); //disattivo il contenitore in scena
        }

    }

    private void Start()
    {
      
        lancia(); 

        
    }
   

    public int confronta()
    {

        return array[index]; // Viene Evocata per confrontare la soluzione con il numero che porta la scimmietta in "BananaBella"

    }

   public void incrementa()
    {
        index++; //Viene Evocata per incrementare il vettore delle soluzioni dopo che ho colpito la scimmietta che porta il numero uguale alla soluzione.

    }



      public void lancia() //Copia della funzione del progetto svolto a lezioni,Attiva il primo cartello che trovo disattivato in scena
    {
        monkeyFound = false;
        while (!monkeyFound)
        {
            for (int i = counter; i < lvl1.Length; i++)
            {
                if (!lvl1[i].activeInHierarchy)
                {
                    counter = i;
                    lvl1[i].GetComponent<Cartello>().Spawn(eqSpawn.transform);


                    monkeyFound = true;
                    break;
                }

            }
            if (counter == lvl1.Length - 1)
                counter = 0;

        }
    }



}


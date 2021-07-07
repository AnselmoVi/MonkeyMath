using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPowerUp : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUpTimer;
    [SerializeField] private GameObject YellowTimer,RedTimer;
    [SerializeField] private GameObject powerUpSpawner;
    
    //Gestisce  i powerUp. Vengono Attivati in scena tramite Coroutine


     private float timeToSpawn = 5, t = 0;
    bool touch = true;
    private int counter = 0;
    private bool powerUpFound = false;

    void Awake()
    {
        powerUpTimer = new GameObject[8];     

        for (int i = 0; i < powerUpTimer.Length; i++)
        {
            switch (Random.Range(1,2))
            {
                case 1:
                    powerUpTimer[i] = GameObject.Instantiate(YellowTimer); 
                    break;

                case 2:
                    powerUpTimer[i] = GameObject.Instantiate(RedTimer);
                    break;

                
            }
            powerUpTimer[i].SetActive(false);
        }
      
    }

    private void Start()
    {
    
        StartCoroutine(PowerUpSpawn());
    
    }


    IEnumerator PowerUpSpawn()  // Il power Up spawna ogni 25s circa
    {

        var wait = new WaitForSeconds(25f);  
        while (true)
        {

            yield return wait;
            Crea();

        }
    }



    void Crea()
    {
        if (touch) // Controllo se effettivamente posso far spawnare un nuovo PowerUp. Se ne vi è uno già in scena non viene attivato
        {
            touch = false;
           
            powerUpFound = false;
            while (!powerUpFound)
            {
                for (int i = counter; i < powerUpTimer.Length; i++)
                {
                    if (!powerUpTimer[i].activeInHierarchy)
                    {
                        counter = i;
                        powerUpTimer[i].GetComponent<PowerUp>().Spawn();


                        powerUpFound = true;
                        break;
                    }

                }
                if (counter == powerUpTimer.Length - 1)
                    counter = 0;

            }
        }
    }

    public void SetTouch()
    {
        touch = true;

    }
}


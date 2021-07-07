using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMonkey : MonoBehaviour
{
    [SerializeField] private GameObject[] branco;
    [SerializeField] private GameObject Monkey1, Monkey2, Monkey3, Monkey4, Monkey5, Monkey6, Monkey7, Monkey8, Monkey9, Monkey10;
    [SerializeField] private GameObject monkeySpawn;
    //Timer di spawn delle scimmiette
    [SerializeField] private float timeToSpawn = 5, t = 0;
    private int counter = 0;
    private bool monkeyFound = false;

    void Awake()
    {
       branco = new GameObject[50];      //Riempio l'array con i vari modelli di scimmia,  e le inserisco randomicamente
     
        for (int i = 0; i < branco.Length; i++)
        {
            switch (Random.Range(1, 10))
            {
                case 1:
                    branco[i] = GameObject.Instantiate(Monkey1);
                    break;

                case 2:
                    branco[i] = GameObject.Instantiate(Monkey2);
                    break;

                case 3:
                    branco[i] = GameObject.Instantiate(Monkey3);
                    break;
                case 4:
                    branco[i] = GameObject.Instantiate(Monkey4);
                    break;
                case 5:
                    branco[i] = GameObject.Instantiate(Monkey5);
                    break;
                case 6:
                    branco[i] = GameObject.Instantiate(Monkey6);
                    break;
                case 7:
                    branco[i] = GameObject.Instantiate(Monkey7);
                    break;
                case 8:
                    branco[i] = GameObject.Instantiate(Monkey8);
                    break;
                case 9:
                    branco[i] = GameObject.Instantiate(Monkey9);
                    break;
                case 10:
                    branco[i] = GameObject.Instantiate(Monkey10);
                    break;
            }
            branco[i].SetActive(false);
        }
    }
   

    void Update()
    {

        t += Time.deltaTime;
        if (t > timeToSpawn)
        {
            lancia();
            t = 0;
        }
    }

    void lancia()
    {
        monkeyFound = false;
        while (!monkeyFound)
        {
            for (int i = counter; i < branco.Length; i++)
            {
                if (!branco[i].activeInHierarchy)
                {
                    counter = i;
                    branco[i].GetComponent<MMonkey>().Spawn(monkeySpawn.transform);


                    monkeyFound = true;
                    break;
                }

            }
            if (counter == branco.Length - 1)
                counter = 0;

        }
    }
}


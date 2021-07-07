using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassificaManager : MonoBehaviour
{

    int index;
    string[] valori;
    GameObject temp;
    Text t;
    [SerializeField] Text Ar;
    
    // Start is called before the first frame update
    void Awake()
    {
        index = PlayerPrefs.GetInt("index");
       
        valori = new string[2];
       
        


    }

    // Update is called once per frame
   private void Start()
    {
        
        for (int i = 0; i < (10-index ); i++)
        {
            string nome = i.ToString();

            GameObject.Find(nome).GetComponent<Text>().text = "Non classificato";

      

        }
        

        Insert();

    }

  

    public void Insert()
    {

        index = PlayerPrefs.GetInt("index");
        
        for (int i = 0; i < index; i++)
        {
            
            valori = SavePoints.GetBestTen(i);
            
            GameObject.Find(i.ToString()).GetComponent<Text>().text =(i+1) + ")\t " + valori[0] + "  " + valori[1];

        }

    }
}

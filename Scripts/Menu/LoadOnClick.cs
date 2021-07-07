using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    bool go = false;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
    }
    public void Schermata_Iniziale()
    {



        SceneManager.LoadScene("Schermata_Iniziale", LoadSceneMode.Single);
    }

    public void Schermata_Opzioni()
    {



        SceneManager.LoadScene("Schermata_Opzioni", LoadSceneMode.Single);
    }


    public void Works()
    {
        if (go == true)
        {
            Time.timeScale = 1;
            go = false;
            SceneManager.LoadScene("Lvl1Timer", LoadSceneMode.Single);
        }
    }

    public void Esci()
    {
         Application.Quit();

    }


   public void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);


    }

    public void InserisciNome()
    {

        SceneManager.LoadScene("Dati_Player", LoadSceneMode.Single);


    }


    public void setbool()
    {

        go = true;
    }

    public void Rigioca()
    {
        
            Time.timeScale = 1;
            
            SceneManager.LoadScene("Lvl1Timer", LoadSceneMode.Single);
        
    }

    public void Classifica()
    {

        SceneManager.LoadScene("PROVACLASSIFICA", LoadSceneMode.Single);


    }
    public void ResettaInfo()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }


    public void Crediti()
    {
        SceneManager.LoadScene("Crediti", LoadSceneMode.Single);
    }

    public void Lvl2()
    {
        SceneManager.LoadScene("LvL2", LoadSceneMode.Single);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnlockLvl : MonoBehaviour
{
    [SerializeField] Sprite On;
    [SerializeField] Sprite Off;
    // Start is called before the first frame update


    private void Awake()
    {
        if (PlayerPrefs.GetInt("unlock") == 0)
        {
            gameObject.GetComponent<Image>().sprite = Off;
            GetComponent<Button>().enabled = false;

        }
        else
        {
            gameObject.GetComponent<Image>().sprite = On;
            GetComponent<Button>().enabled = true;
        }

    }
    public void Clicca()
    {
        if (PlayerPrefs.GetInt("unlock") == 0)
        {
            gameObject.GetComponent<Image>().sprite = Off;
            GetComponent<Button>().enabled = false;

        }
        else
        {
            gameObject.GetComponent<Image>().sprite = On;
            GetComponent<Button>().enabled = true;
        }
    }
}

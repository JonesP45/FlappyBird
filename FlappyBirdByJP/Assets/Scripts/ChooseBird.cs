using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBird : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //si un bird a déjà été choisi plus tot, on check le bon bird
        if (ParamManager.Instance.getBird().name != null)
        {
            if (gameObject.GetComponent<Toggle>().isOn)
            {
                if (!ParamManager.Instance.getBird().name.Contains(gameObject.name))
                {
                    gameObject.GetComponent<Toggle>().isOn = false;
                }
            }
            else
            {
                if (ParamManager.Instance.getBird().name.Contains(gameObject.name))
                {
                    gameObject.GetComponent<Toggle>().isOn = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //si le toggle est check
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            onClick();
        }
    }

    public void onClick()
    {
        //on met à jour ParamManager
        string name = gameObject.name;
        if (name.Contains("Blue"))
        {
            ParamManager.Instance.SetBlueBird();
        }
        else if (name.Contains("Purple"))
        {
            ParamManager.Instance.SetPurpleBird();
        }
        else
        {
            ParamManager.Instance.SetGreenBird();
        }
    }
}

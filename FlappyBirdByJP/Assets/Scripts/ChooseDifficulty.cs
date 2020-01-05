using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseDifficulty : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //si une difficulté a déjà été choisi plus tot, on check la bonne difficulté
        if (ParamManager.Instance.getDifficulty() != null)
        {
            if (gameObject.GetComponent<Toggle>().isOn)
            {
                if (!ParamManager.Instance.getDifficulty().Equals(gameObject.name))
                {
                    gameObject.GetComponent<Toggle>().isOn = false;
                }
            }
            else
            {
                if (ParamManager.Instance.getDifficulty().Equals(gameObject.name))
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
        if (name.Equals(ParamManager.Easy))
        {
            ParamManager.Instance.SetEasy();
        }
        else if (name.Equals(ParamManager.Normal))
        {
            ParamManager.Instance.SetNormal();
        }
        else
        {
            ParamManager.Instance.SetHard();
        }
    }
}

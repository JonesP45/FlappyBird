using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseDifficulty : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            onClick();
        }
    }

    public void onClick()
    {
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

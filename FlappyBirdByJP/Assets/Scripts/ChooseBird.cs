using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBird : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            onClick();
        }
    }

    public void onClick()
    {
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

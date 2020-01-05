using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButtonParameter : MonoBehaviour
{
    public void onClick()
    {
        //on charge la scene des paramètres
        SceneManager.LoadScene("Scene1_1-Param");
        ButtonPlayManager.Instance.Remove();
    }
}

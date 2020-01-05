using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButtonOk : MonoBehaviour
{
    public void onClick()
    {
        //on charge la scene des initiale
        SceneManager.LoadScene("Scene1-Init");
    }
}

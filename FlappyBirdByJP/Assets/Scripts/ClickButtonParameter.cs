using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButtonParameter : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene("Scene1_1-Param");
        ButtonPlayManager.Instance.Remove();
    }
}

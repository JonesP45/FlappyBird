using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButtonOk : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene("Scene1-Init");
    }
}

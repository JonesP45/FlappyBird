using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButtonMenu : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene("Scene1-Init");
        GameObject.FindGameObjectWithTag("floor").GetComponent<FloorScroll>().enabled = true;
    }
}

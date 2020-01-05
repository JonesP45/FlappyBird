using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButtonMenu : MonoBehaviour
{
    public void onClick()
    {
        //on charge la 1ère scène et on rapplique un mouvement de scrolling sur le floor qui est DontDestryOnLoad
        SceneManager.LoadScene("Scene1-Init");
        GameObject.FindGameObjectWithTag("floor").GetComponent<FloorScroll>().enabled = true;
    }
}

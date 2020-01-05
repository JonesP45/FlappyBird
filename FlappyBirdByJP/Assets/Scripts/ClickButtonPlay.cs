using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButtonPlay : MonoBehaviour
{
    public void onClick()
    {
        StartCoroutine(PlaySound());
        if (SceneManager.GetActiveScene().name.Contains("3"))
        {
            GameObject.FindGameObjectWithTag("floor").GetComponent<FloorScroll>().enabled = true;
        }
    }

    IEnumerator PlaySound()
    {
        //on joue le son, on cache le bouton puis on charge la scene
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        ButtonPlayManager.Instance.Hidden();
        SceneManager.LoadScene("Scene2-Menu");
        //tant que le son est en train de jouer, on ne detruit pas le bouton (pour que le son se joue dans son intégralité)
        yield return new WaitWhile(() => GetComponent<AudioSource>().isPlaying);
        ButtonPlayManager.Instance.Remove();
    }
}

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
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        ButtonPlayManager.Instance.Hidden();
        SceneManager.LoadScene("Scene2-Menu");
        yield return new WaitWhile(() => GetComponent<AudioSource>().isPlaying);
        ButtonPlayManager.Instance.Remove();
    }
}

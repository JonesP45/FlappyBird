using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAction : MonoBehaviour
{
    private bool gameOver = false;
    private bool isDie = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        //si le bird touche un pipe
        if (col.gameObject.name == "UpPipe" || col.gameObject.name == "DownPipe")
        {
            //on met à jour son état dans GameState
            GameState.Instance.setIsDead(true);
            //on désactive le script touchaction pour qu'il ne puisse plus sauter
            gameObject.GetComponent<TouchAction>().enabled = false;
            //on remet sa rotation à 0
            transform.eulerAngles = new Vector3(0, 0, 0);
            //puis on desactive applyrootmotion de l'animator pour pouvoir appliquer le trigger Die normalement
            gameObject.GetComponentInChildren<Animator>().applyRootMotion = false;
            gameObject.GetComponentInChildren<Animator>().SetTrigger("Die");
            //on arrete le mouvement du background, du floor et des pipes
            StopMoving();
            //on joue les sons
            if (!isDie)
            {
                playSoundHit();
                playSoundDie();
            }
            isDie = true;
        }
        //si le bird touche le sol
        else if (col.gameObject.name.Contains("Floor"))
        {
            GameState.Instance.setIsDead(true);
            gameObject.GetComponent<TouchAction>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            transform.eulerAngles = new Vector3(0, 0, 0);
            gameObject.GetComponentInChildren<Animator>().applyRootMotion = false;
            gameObject.GetComponentInChildren<Animator>().SetTrigger("Die");
            StopMoving();
            if (!isDie)
            {
                playSoundHit();
            }
        }
    }

    void StopMoving()
    {
        ButtonPausePlayManager.Instance.Delete();
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("pipe");
        foreach (GameObject pipe in pipes)
        {
            pipe.GetComponent<MovePipes>().movement = new Vector3(0, 0, 0);
        }

        GameObject.FindWithTag("background").GetComponent<BackgroundScroll>().enabled = false;
        GameObject.FindWithTag("floor").GetComponent<FloorScroll>().enabled = false;

        //on met à jour le meilleur score et on charge la scene 4
        if (!gameOver)
        {
            GameState.Instance.UpdateBestScorePlayer();
            gameOver = true;
            SceneManager.LoadScene("Scene4-GameOver", LoadSceneMode.Additive);
        }
    }

    void playSoundHit()
    {
        GetComponent<SoundAction>().playSoundHit();
    }

    void playSoundDie()
    {
        GetComponent<SoundAction>().playSoundDie();
    }
}

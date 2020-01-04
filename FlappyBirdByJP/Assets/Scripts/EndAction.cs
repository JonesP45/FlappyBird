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
        if (col.gameObject.name == "UpPipe" || col.gameObject.name == "DownPipe")
        {
            GameState.Instance.setIsDead(true);
            gameObject.GetComponent<TouchAction>().enabled = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
            gameObject.GetComponentInChildren<Animator>().applyRootMotion = false;
            gameObject.GetComponentInChildren<Animator>().SetTrigger("Die");
            StopMoving();
            if (!isDie)
            {
                playSoundHit();
                playSoundDie();
            }
            isDie = true;
        }
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
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("pipe");
        foreach (GameObject pipe in pipes)
        {
            pipe.GetComponent<MovePipes>().movement = new Vector3(0, 0, 0);
        }

        GameObject.FindWithTag("background").GetComponent<BackgroundScroll>().enabled = false;
        GameObject.FindWithTag("floor").GetComponent<FloorScroll>().enabled = false;

        if (!gameOver)
        {
            //GameState.Instance.setIsDead(true);
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

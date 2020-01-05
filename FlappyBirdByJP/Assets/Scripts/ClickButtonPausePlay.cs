using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButtonPausePlay : MonoBehaviour
{
    private bool isPaused = false;

    public Sprite pause;
    public Sprite play;

    public void onClick()
    {
        //si le jeu est en pause, on le remet en route
        if (isPaused)
        {
            GameState.Instance.setIsPause(false);
            Time.timeScale = 1;
            isPaused = false;
            gameObject.GetComponent<Image>().sprite = pause;
        }
        //sinon on le met en pause
        else
        {
            GameState.Instance.setIsPause(true);
            Time.timeScale = 0;
            isPaused = true;
            gameObject.GetComponent<Image>().sprite = play;
        }
    }
}

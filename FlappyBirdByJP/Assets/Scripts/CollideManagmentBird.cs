using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideManagmentBird : MonoBehaviour
{
    //si le bird touche une box, on met à jour le score
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Box1") || col.gameObject.name.Equals("Box2"))
        {
            GameState.Instance.addScorePlayer(1);
            playSoundPoint();
        }
    }

    void playSoundPoint()
    {
        GetComponent<SoundAction>().playSoundPoint();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIsNewBest : MonoBehaviour
{
    public Sprite newBest;

    // Start is called before the first frame update
    void Start()
    {
        //si on obtient un nouveau meilleur score laors on affiche un petit sprite a coté du best score
        if (GameState.Instance.getNewBest())
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = newBest;
        }
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

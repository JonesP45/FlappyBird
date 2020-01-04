using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBird : MonoBehaviour
{
    private Vector3 size;
    private Vector3 hautdroit;
    private Vector3 basGauche;

    // Start is called before the first frame update
    void Start()
    {
        hautdroit = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        basGauche = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Calcul de la taille du sprite auquel ce script est attaché.
         * Taill normal = gameObject.GetComponent<SpriteRenderer>().bounds.size
         * On prend en compte les éventuelles transformations demandés lors de l'intégration su sprite dans l'éditeur de Unity
         * siz vaut alors normale * par les déformations (notamment le zoom)
         */
        size.x = gameObject.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        size.y = gameObject.GetComponentInChildren<SpriteRenderer>().bounds.size.y;
        /*
         * Positionnement du vaisseau contre le bord gauche de l'écran
         */
        /*
         * Si la position en Y de notre vaisseau est inférieur à la limite basse de l'écran,
         * on repositionne le vaisseau en bas de l'écran
         */
        if (transform.position.y < basGauche.y + (size.y / 2))
        {
            gameObject.transform.position = new Vector3(transform.position.x, basGauche.y + (size.y / 2), transform.position.z);
        }
        /*
         * Si la position en Y de notre vaisseau est supérieur à la limite haute de l'écran,
         * on repositionne le vaisseau en haut de l'écran
         */
        if (transform.position.y > hautdroit.y - (size.y / 2))
        {
            gameObject.transform.position = new Vector3(transform.position.x, hautdroit.y - (size.y / 2), transform.position.z);
        }
        /*
         * Si la position en Y de notre vaisseau est inférieur à la limite gauche de l'écran,
         * on repositionne le vaisseau à gauche de l'écran
         */
        if (transform.position.x < basGauche.x + (size.x / 2))
        {
            gameObject.transform.position = new Vector3(basGauche.x + (size.x / 2), transform.position.y, transform.position.z);
        }
        /*
         * Si la position en Y de notre vaisseau est supérieur à la limite droite de l'écran,
         * on repositionne le vaisseau à droite de l'écran
         */
        if (transform.position.x > hautdroit.x - (size.x / 2))
        {
            gameObject.transform.position = new Vector3(hautdroit.x - (size.x / 2), transform.position.y, transform.position.z);
        }
    }
}

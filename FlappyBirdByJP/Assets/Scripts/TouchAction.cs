using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchAction : MonoBehaviour
{
    private Vector2 movement;
    public float moveUp;

    // dernière position du bird quand on a touché l'écran
    private float lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = GetComponent<Rigidbody2D>().velocity.y;
        movement = new Vector2(0, moveUp);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(movement);
        playSoundFlying();
    }

    // Update is called once per frame
    void Update()
    {
        // si le bird est au dessus de sa position lors dernier touch alors il a une inclinaison positive
        if (lastPosition <= transform.position.y)
        {
            Vector3 to = new Vector3(0, 0, 30);
            // si l'inclinaison est inf à 30° alors on fait augmenter l'angle
            if (Vector3.Distance(transform.eulerAngles, to) > 0f)
            {
                transform.eulerAngles = Vector3.Slerp(transform.rotation.eulerAngles, to, Time.deltaTime * 100);
            }
            // sinon on le laisse à 30°
            else
            {
                transform.eulerAngles = to;
            }
        }
        //même principe mais avec l'angle -30°
        else
        {
            Vector3 to = new Vector3(0, 0, -30);
            if (Vector3.Angle(transform.eulerAngles, to) > 0f)
            {
                transform.eulerAngles = Vector3.Slerp(transform.rotation.eulerAngles, to, Time.deltaTime * 100);
            }
            else
            {
                transform.eulerAngles = to;
            }
        }

        if (Input.touchCount > 0) // gestion jump avec phone
        {
            //le dernier doight posé sur l'écran
            Touch theLastTouch = Input.GetTouch(Input.touchCount - 1);

            //si le doight touche l'écran, on applique une force vers le haut et on joue un son
            if (theLastTouch.phase == TouchPhase.Began)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce(movement);
                playSoundFlying();
                lastPosition = transform.position.y;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) //gestion jump avec ordi
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            lastPosition = transform.position.y;
            GetComponent<Rigidbody2D>().AddForce(movement);
            playSoundFlying();
        }
    }

    void playSoundFlying()
    {
        GetComponent<SoundAction>().playSoundFlying();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchAction : MonoBehaviour
{
    private Vector2 movement;
    public float moveUp;

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
        if (lastPosition <= transform.position.y)
        {
            Vector3 to = new Vector3(0, 0, 30);
            if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
            {
                transform.eulerAngles = Vector3.Slerp(transform.rotation.eulerAngles, to, Time.deltaTime * 100);
            }
            else
            {
                transform.eulerAngles = to;
            }
        }
        else
        {
            Vector3 to = new Vector3(0, 0, -30);
            if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
            {
                transform.eulerAngles = Vector3.Slerp(transform.rotation.eulerAngles, to, Time.deltaTime * 100);
            }
            else
            {
                transform.eulerAngles = to;
            }
        }

        if (Input.touchCount > 0) //phone
        {
            Touch theLastTouch = Input.GetTouch(Input.touchCount - 1);

            if (theLastTouch.phase == TouchPhase.Began)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce(movement);
                playSoundFlying();
                lastPosition = transform.position.y;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) //ordi
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(movement);
            playSoundFlying();
            lastPosition = transform.position.y;
        }
    }

    void playSoundFlying()
    {
        GetComponent<SoundAction>().playSoundFlying();
    }
}

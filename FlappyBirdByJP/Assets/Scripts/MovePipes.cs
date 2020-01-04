using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipes : MonoBehaviour
{
    public Vector3 movement;
    public GameObject pipeUp;
    public GameObject box;
    public GameObject pipeDown;

    public Sprite UpDay;
    public Sprite DownDay;
    public Sprite UpNight;
    public Sprite DownNight;

    private Vector3 pipe1UpOriginalVector;
    private Vector3 pipe1DownOriginalVector;
    private Vector2 leftBottomCameraBorder;
    private Vector2 rightBottomCameraBorder;
    private Vector2 size;

    void Awake()
    {
        if (gameObject.name.Contains("2"))
        {
            if (ParamManager.Instance.difficulty.Equals(ParamManager.Normal) || ParamManager.Instance.difficulty.Equals(ParamManager.Hard))
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        movement = new Vector3(-2 * GameObject.FindWithTag("floor").GetComponent<FloorScroll>().xVelocity, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {

        pipe1UpOriginalVector = pipeUp.transform.position;
        pipe1DownOriginalVector = pipeDown.transform.position;
        leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));

        if (!GameObject.FindWithTag("background").GetComponent<BackGroundManager>().quad.GetComponent<Renderer>().material.name.Contains("2"))
        {
            pipeUp.GetComponent<SpriteRenderer>().sprite = UpDay;
            pipeDown.GetComponent<SpriteRenderer>().sprite = DownDay;
            pipeDown.transform.rotation = new Quaternion(0, 0, 0, 1);
        }
        else
        {
            pipeUp.GetComponent<SpriteRenderer>().sprite = UpNight;
            pipeDown.GetComponent<SpriteRenderer>().sprite = DownNight;
            pipeUp.transform.rotation = new Quaternion(0, 0, 180, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        pipeUp.GetComponent<Rigidbody2D>().velocity = movement;
        box.GetComponent<Rigidbody2D>().velocity = movement;
        pipeDown.GetComponent<Rigidbody2D>().velocity = movement;
        size.x = pipeUp.GetComponent<SpriteRenderer>().bounds.size.x; // Récupera;on de la taille d’un pipe
        // Le pipe est sorti de l’écran ? Si oui appel de la méthode moveTORightPipe
        if (pipeUp.transform.position.x < leftBottomCameraBorder.x - (size.x / 2))
            moveToRightPipe();
    }

    void moveToRightPipe()
    {
        float randomY = Random.Range(0, 5) - 2; // Tirage aléatoire d’un décalage en Y
        float posX = rightBottomCameraBorder.x + (size.x / 2); // Calcul du X du bord droite de l’écran
        // Calcul du nouvel Y en reprenant la position Y d’origine du pipe, ici le downPipe1
        float posY = pipe1UpOriginalVector.y + randomY;
        // Création du vector3 contenant la nouvelle posi;on
        Vector3 tmpPos = new Vector3(posX, posY, pipeUp.transform.position.z);
        // Affectation de ceVe nouvelle position au transform du gameObject
        pipeUp.transform.position = tmpPos;
        // Idem pour le second pipe
        posY = pipe1DownOriginalVector.y + randomY;
        tmpPos = new Vector3(posX, posY, pipeDown.transform.position.z);
        pipeDown.transform.position = tmpPos;

        posY = (pipeUp.transform.position.y + pipeDown.transform.position.y) / 2;
        tmpPos = new Vector3(posX, posY, pipeDown.transform.position.z);
        box.transform.position = tmpPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    private static int scorePlayer;
    private static int bestScorePlayer;

    private bool isDead = false;
    private bool isPause = false;
    private bool newBest = false;

    public Sprite zero;
    public Sprite un;
    public Sprite deux;
    public Sprite trois;
    public Sprite quatre;
    public Sprite cinq;
    public Sprite six;
    public Sprite sept;
    public Sprite huit;
    public Sprite neuf;

    private float posY;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            bestScorePlayer = 0;
            bestScorePlayer = PlayerPrefs.GetInt("bestScore");
        }
        else if (SceneManager.GetActiveScene().name.Equals("Scene2-Menu"))
        {
            bestScorePlayer = Instance.getBestScorePlayer();
            Destroy(Instance.gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(Instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        scorePlayer = 0;
        posY = GameObject.FindWithTag("score1").transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            string score = scorePlayer.ToString();
            if (score.Length == 1)
            {
                GameObject.FindWithTag("score1").transform.position = new Vector3(0, posY, 0);
            }
            else if (score.Length == 2)
            {
                GameObject.FindWithTag("score1").transform.position = new Vector3(0.15f, posY, 0);
                GameObject.FindWithTag("score2").transform.position = new Vector3(-0.15f, posY, 0);
            }
            else if (score.Length == 3)
            {
                GameObject.FindWithTag("score1").transform.position = new Vector3(0.3f, posY, 0);
                GameObject.FindWithTag("score2").transform.position = new Vector3(0, posY, 0);
                GameObject.FindWithTag("score3").transform.position = new Vector3(-0.3f, posY, 0);
            }
            else if (score.Length == 4)
            {
                GameObject.FindWithTag("score1").transform.position = new Vector3(0.45f, posY, 0);
                GameObject.FindWithTag("score2").transform.position = new Vector3(0.15f, posY, 0);
                GameObject.FindWithTag("score3").transform.position = new Vector3(-0.15f, posY, 0);
                GameObject.FindWithTag("score4").transform.position = new Vector3(-0.45f, posY, 0);
            }
            int indice = score.Length;
            for (int i = 0; i < score.Length; i++)
            {
                switch (score[i])
                {
                    case '0':
                        GameObject.FindWithTag("score" + indice).GetComponent<SpriteRenderer>().sprite = zero;
                        break;
                    case '1':
                        GameObject.FindWithTag("score" + indice).GetComponent<SpriteRenderer>().sprite = un;
                        break;
                    case '2':
                        GameObject.FindWithTag("score" + indice).GetComponent<SpriteRenderer>().sprite = deux;
                        break;
                    case '3':
                        GameObject.FindWithTag("score" + indice).GetComponent<SpriteRenderer>().sprite = trois;
                        break;
                    case '4':
                        GameObject.FindWithTag("score" + indice).GetComponent<SpriteRenderer>().sprite = quatre;
                        break;
                    case '5':
                        GameObject.FindWithTag("score" + indice).GetComponent<SpriteRenderer>().sprite = cinq;
                        break;
                    case '6':
                        GameObject.FindWithTag("score" + indice).GetComponent<SpriteRenderer>().sprite = six;
                        break;
                    case '7':
                        GameObject.FindWithTag("score" + indice).GetComponent<SpriteRenderer>().sprite = sept;
                        break;
                    case '8':
                        GameObject.FindWithTag("score" + indice).GetComponent<SpriteRenderer>().sprite = huit;
                        break;
                    case '9':
                        GameObject.FindWithTag("score" + indice).GetComponent<SpriteRenderer>().sprite = neuf;
                        break;
                }
                indice--;
            }
        }
    }

    public void UpdateBestScorePlayer()
    {
        if (scorePlayer > bestScorePlayer)
        {
            bestScorePlayer = scorePlayer;
            PlayerPrefs.SetInt("bestScore", bestScorePlayer);
            newBest = true;
        }
    }

    public void addScorePlayer(int toAdd)
    {
        scorePlayer += toAdd;
    }

    public void setIsDead(bool b)
    {
        isDead = b;
    }
    public bool getIsDead()
    {
        return isDead;
    }

    public void setIsPause(bool b)
    {
        isPause = b;
    }
    public bool getIsPause()
    {
        return isPause;
    }

    public bool getNewBest()
    {
        return newBest;
    }
    public int getScorePlayer()
    {
        return scorePlayer;
    }
    public int getBestScorePlayer()
    {
        return bestScorePlayer;
    }
}

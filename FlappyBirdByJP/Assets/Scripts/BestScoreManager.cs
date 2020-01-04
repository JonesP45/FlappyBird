using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
    public GameObject score1;
    public GameObject score2;
    public GameObject score3;
    public GameObject score4;

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

    // Start is called before the first frame update
    void Start()
    {
        string score = GameState.Instance.getBestScorePlayer().ToString();
        int indice = score.Length;
        for (int i = 0; i < score.Length; i++)
        {
            switch (score[i])
            {
                case '0':
                    getGoodScore(indice).GetComponent<SpriteRenderer>().sprite = zero;
                    break;
                case '1':
                    getGoodScore(indice).GetComponent<SpriteRenderer>().sprite = un;
                    break;
                case '2':
                    getGoodScore(indice).GetComponent<SpriteRenderer>().sprite = deux;
                    break;
                case '3':
                    getGoodScore(indice).GetComponent<SpriteRenderer>().sprite = trois;
                    break;
                case '4':
                    getGoodScore(indice).GetComponent<SpriteRenderer>().sprite = quatre;
                    break;
                case '5':
                    getGoodScore(indice).GetComponent<SpriteRenderer>().sprite = cinq;
                    break;
                case '6':
                    getGoodScore(indice).GetComponent<SpriteRenderer>().sprite = six;
                    break;
                case '7':
                    getGoodScore(indice).GetComponent<SpriteRenderer>().sprite = sept;
                    break;
                case '8':
                    getGoodScore(indice).GetComponent<SpriteRenderer>().sprite = huit;
                    break;
                case '9':
                    getGoodScore(indice).GetComponent<SpriteRenderer>().sprite = neuf;
                    break;
            }
            indice--;
        }
        for (int i = score.Length; i < 4; i++)
        {
            getGoodScore(i + 1).GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    GameObject getGoodScore(int i)
    {
        if (score1.name.Equals("Most" + i))
        {
            return score1;
        }
        else if (score2.name.Equals("Most" + i))
        {
            return score2;
        }
        else if (score3.name.Equals("Most" + i))
        {
            return score3;
        }
        else if (score4.name.Equals("Most" + i))
        {
            return score4;
        }
        else
        {
            return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int Player1Score;
    public static int Player2Score;
    [Range(1, 2)]
    public int playerScore;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScore == 1)
        {
            text.text = "Score :" + Player1Score;
        }else if(playerScore == 2)
        {
            text.text = "Score :" + Player2Score;
        }
    }
}

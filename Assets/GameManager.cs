using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int player1Score = 0;
    public static int player2Score = 0;

    public GUISkin layout;

    GameObject theball;

    public static void Score(string wallID)
    {
        if (wallID == "RightWall")
            player1Score++;
        else
            player2Score++;
    }
    private void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + player1Score);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + player2Score);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            player1Score = 0;
            player2Score = 0;
            theball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if(player1Score == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 175, 200, 2000, 1000), "PLAYER ONE WINS");
            theball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (player2Score == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 175, 200, 2000, 1000), "PLAYER TWO WINS");
            theball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        theball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

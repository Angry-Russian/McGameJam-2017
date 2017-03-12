using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustTextBubble : MonoBehaviour {
    public VerticalLayoutGroup vlg;
    public static bool finishedMoving;
    RectTransform myRect;
    static float move;
    public Text bubbleTextBox;
    float currentMove = 0;
    float timeMoved;
	// Use this for initialization
	void Start () {
        myRect = GetComponent<RectTransform>();
	}
    void Update()
    {
        if(bubbleTextBox.text != "default")
        {
            //vlg.childControlWidth = true;
            //vlg.childControlWidth = false;
        }
        if(currentMove < move)
        {
            timeMoved = Time.deltaTime * 6;
            if(timeMoved + currentMove > move)
            {
                timeMoved = move - currentMove;
            }
            myRect.anchoredPosition = new Vector3(0, myRect.anchoredPosition.y + timeMoved, 0);
            currentMove += timeMoved;
            finishedMoving = false;
        }
        else
        {
            finishedMoving = true;
            currentMove = 0;
            move = 0;
        }
    }
    public static void MoveUp(float moveAmount)
    {
        move = moveAmount;
        print(move);
    }
}
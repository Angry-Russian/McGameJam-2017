using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTextBubbles : MonoBehaviour {
    public GameObject messageSound;
    public static bool isIntro;
    public static bool isIntroHappy;
    public static bool isIntroEco;
    public static bool isIntroEdu;
    public static bool isIntroEnd;

    public GameObject[] buttons;
    public GameObject[] faces;
    ControlPulseAnim[] buttonAnimators = new ControlPulseAnim[3];

    public static bool is0Happy;
    public static bool is25Happy;
    public static bool is75Happy;
    public static bool is100Happy;
    
    public static bool is0Eco;
    public static bool is25Eco;
    public static bool is75Eco;
    public static bool is100Eco;
    
    public static bool is0Edu;
    public static bool is25Edu;
    public static bool is75Edu;
    public static bool is100Edu;
    
    public static bool is0Money;
    public static bool is25Money;
    public static bool is75Money;
    public static bool is100Money;

    public GameObject introConvo;
    public GameObject introHappyConvo;
    public GameObject introEcoConvo;
    public GameObject introEduConvo;
    public GameObject introEndConvo;

    public GameObject happy0Convo;
    public GameObject happy25Convo;
    public GameObject happy75Convo;
    public GameObject happy100Convo;

    public GameObject eco0Convo;
    public GameObject eco25Convo;
    public GameObject eco75Convo;
    public GameObject eco100Convo;

    public GameObject edu0Convo;
    public GameObject edu25Convo;
    public GameObject edu75Convo;
    public GameObject edu100Convo;

    public GameObject money0Convo;
    public GameObject money25Convo;
    public GameObject money75Convo;
    public GameObject money100Convo;

    string[] conversationToFollow;
    static int convoCounter = 0;
    float timePassed = 0;

    public GameObject SpeechBubble;

    GameObject bubbleCopy;

    public GameObject phonePanel;
    bool isMovingUp;
    // Use this for initialization
    void Start () {
        for(int i = 0; i < buttons.Length; i++)
            buttonAnimators[i] = buttons[i].GetComponent<ControlPulseAnim>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ResetAllConvos();
            isIntro = true;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ResetAllConvos();
            isIntroHappy = true;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            ResetAllConvos();
            isIntroEco = true;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ResetAllConvos();
            isIntroEdu = true;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ResetAllConvos();
            isIntroEnd = true;
        }
        CheckConvoToUse();
        timePassed += Time.deltaTime;
        if(conversationToFollow != null)
        {
            if (convoCounter < conversationToFollow.Length && timePassed > conversationToFollow[convoCounter].Length * 0.08f && (AdjustTextBubble.finishedMoving || convoCounter == 0))
            {
                bubbleCopy = Instantiate(SpeechBubble);
                bubbleCopy.transform.parent = phonePanel.transform;
                AdjustTextBubble atb = bubbleCopy.GetComponent<AdjustTextBubble>();
                atb.bubbleTextBox.text = conversationToFollow[convoCounter];
                bubbleCopy.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -2.3f, 0f);
                // AdjustTextBubble.MoveUp(0.6f);
                timePassed = 0;
                convoCounter++;
                isMovingUp = true;
            }
            else if (timePassed > 0.1f && convoCounter != 0 && isMovingUp)
            {
                float mod = 0.008f;
                AdjustTextBubble.MoveUp((bubbleCopy.GetComponent<RectTransform>().rect.height / 100) + mod);
                Instantiate(messageSound);
                isMovingUp = false;
            }
        }
        
    }
    void CheckConvoToUse()
    {
        if (isIntro)        { conversationToFollow = introConvo.GetComponent<Conversation>().lines;      ResetAllAnims(); ResetAllFaces(); faces[0].SetActive(true); }
        if (isIntroHappy)   { conversationToFollow = introHappyConvo.GetComponent<Conversation>().lines; ResetAllAnims(); buttonAnimators[0].TogglePulse(true); ResetAllFaces(); faces[1].SetActive(true); }
        if (isIntroEco)     { conversationToFollow = introEcoConvo.GetComponent<Conversation>().lines;   ResetAllAnims(); buttonAnimators[1].TogglePulse(true); ResetAllFaces(); faces[1].SetActive(true); }
        if (isIntroEdu)     { conversationToFollow = introEduConvo.GetComponent<Conversation>().lines;   ResetAllAnims(); buttonAnimators[2].TogglePulse(true); ResetAllFaces(); faces[1].SetActive(true); }
        if (isIntroEnd)     { conversationToFollow = introEndConvo.GetComponent<Conversation>().lines;   ResetAllAnims(); ResetAllFaces(); faces[0].SetActive(true); }

        else if (is0Happy)  { conversationToFollow = happy0Convo.GetComponent<Conversation>().lines;  ResetAllFaces(); faces[3].SetActive(true); }
        else if (is25Happy) { conversationToFollow = happy25Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[2].SetActive(true); }
        else if (is75Happy) { conversationToFollow = happy75Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[2].SetActive(true); }
        else if (is100Happy){ conversationToFollow = happy100Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[3].SetActive(true); }

        else if (is0Eco)    { conversationToFollow = eco0Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[3].SetActive(true); }
        else if (is25Eco)   { conversationToFollow = eco25Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[2].SetActive(true); }
        else if (is75Eco)   { conversationToFollow = eco75Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[2].SetActive(true); }
        else if (is100Eco)  { conversationToFollow = eco100Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[3].SetActive(true); }

        else if (is0Edu)    { conversationToFollow = edu0Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[3].SetActive(true); }
        else if (is25Edu)   { conversationToFollow = edu25Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[2].SetActive(true); }
        else if (is75Edu)   { conversationToFollow = edu75Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[2].SetActive(true); }
        else if (is100Edu)  { conversationToFollow = edu100Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[3].SetActive(true); }

        else if (is0Money)  { conversationToFollow = money0Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[3].SetActive(true); }
        else if (is25Money) { conversationToFollow = money25Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[2].SetActive(true); }
        else if (is75Money) { conversationToFollow = money75Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[1].SetActive(true); }
        else if (is100Money){ conversationToFollow = money100Convo.GetComponent<Conversation>().lines; ResetAllFaces(); faces[1].SetActive(true); }
    }

    public static void ResetAllConvos()
    {
        isIntro = false;
        isIntroHappy = false;
        isIntroEco = false;
        isIntroEdu = false;
        isIntroEnd = false;

        is0Happy = false;
        is25Happy = false;
        is75Happy = false;
        is100Happy = false;

        is0Eco = false;
        is25Eco = false;
        is75Eco = false;
        is100Eco = false;

        is0Edu = false;
        is25Edu = false;
        is75Edu = false;
        is100Edu = false;

        is0Money = false;
        is25Money = false;
        is75Money = false;
        is100Money = false;
        convoCounter = 0;
    }
    void ResetAllFaces()
    {
        for(int i = 0; i < faces.Length; i++)
        {
            faces[i].SetActive(false);
        }
    }
    void ResetAllAnims()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            buttonAnimators[i].TogglePulse(false);
        }
    }
}

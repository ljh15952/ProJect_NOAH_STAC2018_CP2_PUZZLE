using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tutotialScript : MonoBehaviour
{

    int tutorialNum;
    public GameObject ALLLL;
    public Text tutorialText;
    public Animator clickani;
    public GameObject ReakClick;

    public static bool isNodeIn;
    public static bool isSandConnected;
    void Start()
    {
        isNodeIn = false;
        isSandConnected = false;
        tutorialNum = -1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(tutorialNum);
        if (Input.GetMouseButtonUp(0))
        {
            if (tutorialNum == -1)
            {
                Sucesstuto();
            }
            MouseUpEvent();

        }
    }

    //TODO bool 변수 static으로 만들어 관리  EX)노드에 연결후 마우스 UP , 노드에 모래 연결하고 MouseUp
    void Sucesstuto()
    {
        tutorialNum++;
        MouseUpEvent();
        gameObject.SetActive(false);
        ALLLL.SetActive(true);
        ReakClick.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 0);
    }

    private void MouseUpEvent()
    {
        //TODO 모래나오는 블럭이름 정해야하~
        if (tutorialNum == 0)
        {
            tutorialText.text = "해를 드래그해 퍼즐에 놓아보아요 ~";
            clickani.SetBool("tt", false);
            clickani.SetBool("t2", true);
            if (isNodeIn)
            {
                Sucesstuto();
            }
        }
        else if (tutorialNum == 1)
        {
            Debug.Log("HI");
            tutorialText.text = "해는 우측에 있는 해와지구와모래나오는블럭만 연결이 됩니다. 해를 모래블럭과 연결 ~";
            clickani.SetBool("t2", false);
            clickani.SetBool("t3", true);
            if (isSandConnected)
            {
                Sucesstuto();
            }
        }
        else if (tutorialNum == 2)
        {
            tutorialText.text = "지구를 드래그해 퍼즐에 놓아보아요 ~";
            clickani.SetBool("t3", false);
            clickani.SetBool("t4", true);
            if (isNodeIn)
            {
                Sucesstuto();
            }

        }
        else if (tutorialNum == 3)
        {
            tutorialText.text = "지구는 전방향 해와지구와모래만 연결이 됩니다.                                                   지구를 해와 연결 ~";
            clickani.SetBool("t4", false);
            clickani.SetBool("t5", true);
            if (isSandConnected)
            {
                Sucesstuto();
            }
        }
        else if (tutorialNum == 4)
        {
            tutorialText.text = "이제 달을 드래그해 퍼즐에 놓아보아요 ~";
            clickani.SetBool("t5", false);
            clickani.SetBool("t6", true);
            if (isNodeIn)
            {
                Sucesstuto();
            }
        }
        else if (tutorialNum == 5)
        {
            tutorialText.text = "달은 좌측의 달과별과모래만 연결이 됩니다. ~ 달을 모래와 연결 ~";
            clickani.SetBool("t6", false);
            clickani.SetBool("t7", true);
            if (isSandConnected)
            {
                Sucesstuto();
            }
        }
        else if (tutorialNum == 6)
        {
            tutorialText.text = "이제 별을 드래그해 퍼즐에 놓아보아요";
            clickani.SetBool("t7", false);
            clickani.SetBool("t8", true);
            if (isNodeIn)
            {
                Sucesstuto();
            }
        }
        else if (tutorialNum == 7)
        {
            tutorialText.text = "별은 전방향과 별과달과모래만 연결이 됩니다.                               별을 달과 연결~";
            clickani.SetBool("t8", false);
            clickani.SetBool("t9", true);
            if (isSandConnected)
            {
                Sucesstuto();
            }
        }
        else if (tutorialNum == 8)
        {
            tutorialText.text = "이제 스스로 모래를 아래까지 옮겨 보아요 ~";
            clickani.gameObject.SetActive(false);
        }
        else if ((tutorialNum == 9))
        {
            ALLLL.SetActive(false);
        }
        isNodeIn = false;
        isSandConnected = false;
    }
}



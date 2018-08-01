using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleFollowerManager : MonoBehaviour
{
    int ClickNum;

    Transform ChangePos;
  
    // Use this for initialization
    void Start()
    {
        ClickNum = 0;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

    //    if (Input.GetMouseButtonDown(0) && hit)
    //    {
    //        ClickNum++;
    //        if (ClickNum == 1)
    //        {
    //            ChangePos = hit.transform.gameObject;
    //        }
    //        else
    //        {
    //            if (hit.transform.position!=ChangePos.transform.position)
    //                ChangePos.transform.GetComponent<particleFollower>().GoPos = hit.transform.gameObject;
    //            ClickNum = 0;
    //        }
    //        Debug.Log(hit.transform.name);
    //    }
    //}

    //TODO 함수로 빼주기 디버그찍어논곳 그대로 그위치에서 이함수 실행

    public void Test1(Transform pos)
    {
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        //Debug.Log(hit.transform.name);
        ChangePos = pos;
    }

    public void Test2(RaycastHit2D hit)
    {
        if(hit.transform.GetComponent<DragAndDrop>()!=null)
        {
            hit.transform.GetComponent<DragAndDrop>().LinkOBJ = this.ChangePos.gameObject;
        }
        if (hit.transform.position != ChangePos.transform.position)
        {
            ChangePos.GetComponent<particleFollower>().GoPos = hit.transform.gameObject;
        }
        else
        {
            this.ChangePos.GetChild(0).gameObject.SetActive(false);
        }
    }
}

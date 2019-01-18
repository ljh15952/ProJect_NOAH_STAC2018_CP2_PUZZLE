using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderScript : MonoBehaviour
{

    private LineRenderer lineRenderer;

    public bool bClick;

    public AudioSource EFX;
    public AudioSource LittleEFX;
    public bool isLineOut;
    public bool isDirectionOut; // Right Left

    Camera mainCam;

    Vector3 firstClickPos;
    Vector3 dragPos;
    Vector3 ssssseeePos;


    public GameMng GM;

    public float maxRoudius; //3
    float dis;

    float angle;

    public GameObject LinePrefab;

    int ObjectNum; // 1=해 2=달 3=별 4=지구

    public particleFollowerManager pfm;

    int count;

    void Start()
    {
        mainCam = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
        bClick = false;
        isLineOut = false;
        angle = 0;
    }


    void Update()
    {
        if (Input.GetMouseButton(0) && GM.isInsert)
        {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);


            if (hit)
            {
                if (! GM.RealDragObject.isLinkBlock)
                {
                    if (hit.transform.CompareTag("SandDown"))
                    {
                        lineRenderer.SetColors(Color.green, Color.green);
                    }
                    if (GM.ClickObjName == "Sun(Clone)") //해
                    {
                        if ((hit.transform.name == "Sun(Clone)" || hit.transform.name == "Earth(Clone)"))
                            lineRenderer.SetColors(Color.green, Color.green);
                    }
                    else if (GM.ClickObjName == "Moon(Clone)") // 달
                    {
                        if ((hit.transform.name == "Moon(Clone)" || hit.transform.name == "Star(Clone)"))
                            lineRenderer.SetColors(Color.green, Color.green);
                    }
                    else if (GM.ClickObjName == "Star(Clone)") //별
                    {
                        if ((hit.transform.name == "Moon(Clone)" || hit.transform.name == "Star(Clone)"))
                            lineRenderer.SetColors(Color.green, Color.green);
                    }
                    else if (GM.ClickObjName == "Earth(Clone)") // 지구
                    {
                        if ((hit.transform.name == "Sun(Clone)" || hit.transform.name == "Earth(Clone)"))
                            lineRenderer.SetColors(Color.green, Color.green);
                    }
                }
                else
                {
                    if (hit.transform.CompareTag("SandDown"))
                    {
                        lineRenderer.SetColors(Color.green, Color.green);
                    }
                    if (GM.ClickObjName == "Sun(Clone)") //해
                    {
                        if ((hit.transform.name == "Moon(Clone)" || hit.transform.name == "Star(Clone)"))
                            lineRenderer.SetColors(Color.green, Color.green);
                    }
                    else if (GM.ClickObjName == "Moon(Clone)") // 달
                    {
                        if ((hit.transform.name == "Sun(Clone)" || hit.transform.name == "Earth(Clone)"))
                            lineRenderer.SetColors(Color.green, Color.green);
                    }
                    else if (GM.ClickObjName == "Star(Clone)") //별
                    {
                        if ((hit.transform.name == "Sun(Clone)" || hit.transform.name == "Earth(Clone)"))
                            lineRenderer.SetColors(Color.green, Color.green);
                    }
                    else if (GM.ClickObjName == "Earth(Clone)") // 지구
                    {
                        if ((hit.transform.name == "Moon(Clone)" || hit.transform.name == "Star(Clone)"))
                            lineRenderer.SetColors(Color.green, Color.green);
                    }
                }
            }
            else
            {
                lineRenderer.SetColors(Color.red, Color.red);
            }



            dragPos = mainCam.ScreenToWorldPoint(Input.mousePosition); //드래그 하고있는 pos 대입
            dragPos.z = 0;

            dis = Vector3.Distance(firstClickPos, dragPos); // 처음클릭좌표와 지금 드래그하고있는 좌표의 거리 구하기

            if (dis < maxRoudius) //거리가 최대거리보다 작을경우
            {
                isLineOut = false;
                ssssseeePos = dragPos; //두번째Vector에 지금 드래그하고있는 Vector를 넣어줌 
            }
            else //거리가 최대거리보다 커질경우 *****
            {
                lineRenderer.SetColors(Color.red, Color.red);
                isLineOut = true;
                angle = Mathf.Atan2(dragPos.y - firstClickPos.y, dragPos.x - firstClickPos.x);

                ssssseeePos.x = (maxRoudius * Mathf.Cos(angle)) + firstClickPos.x;
                ssssseeePos.y = (maxRoudius * Mathf.Sin(angle)) + firstClickPos.y;
                ssssseeePos.z = 0;
            }

            switch (GM.ClickObjName)
            {
                case "Sun(Clone)":
                    ObjectNum = 1;
                    DrawRightLine();
                    break;
                case "Moon(Clone)":
                    ObjectNum = 2;
                    DrawLeftLine();
                    break;
                case "Star(Clone)":
                    ObjectNum = 3;
                    lineRenderer.SetPosition(1, ssssseeePos);
                    break;
                case "Earth(Clone)":
                    ObjectNum = 4;
                    lineRenderer.SetPosition(1, ssssseeePos);
                    break;
            }

        }

       
        if (Input.GetMouseButtonUp(0) && GM.isInsert && count == 1)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            //해는 오른쪽으로만 지구랑 해만연결됨
            //달은 왼쪽으로만 달이랑 별이랑만 연결됨
            //그니깐 지구는 해랑만 연결되고
            //그니깐 별은 달이랑만 연결됨



            if (hit)
            {
                LittleEFX.Play();
              
                if (!GM.RealDragObject.isLinkBlock)
                {
                    if (hit.transform.CompareTag("SandDown"))
                    {
                        GM.RealDragObject.GetComponent<DragAndDrop>().ishaSand = true;
                        GetMouseDownSuccessEvent(hit);
                    }
                    if (ObjectNum == 1) //해
                    {
                        if ((hit.transform.name == "Sun(Clone)" || hit.transform.name == "Earth(Clone)") && hit.transform.GetComponent<DragAndDrop>().LinkOBJ == null)
                            GetMouseDownSuccessEvent(hit);
                    }
                    else if (ObjectNum == 2) // 달
                    {
                        if ((hit.transform.name == "Moon(Clone)" || hit.transform.name == "Star(Clone)") && hit.transform.GetComponent<DragAndDrop>().LinkOBJ == null)
                            GetMouseDownSuccessEvent(hit);
                    }
                    else if (ObjectNum == 3) //별
                    {
                        if ((hit.transform.name == "Moon(Clone)" || hit.transform.name == "Star(Clone)") && hit.transform.GetComponent<DragAndDrop>().LinkOBJ == null)
                            GetMouseDownSuccessEvent(hit);
                    }
                    else if (ObjectNum == 4) // 지구
                    {
                        if ((hit.transform.name == "Sun(Clone)" || hit.transform.name == "Earth(Clone)") && hit.transform.GetComponent<DragAndDrop>().LinkOBJ == null)
                            GetMouseDownSuccessEvent(hit);
                    }
                    else if (!hit)
                    {
                        Debug.Log("SDADASDSDSD");
                    }
                }
                else
                {
                    if (hit.transform.CompareTag("SandDown"))
                    {
                        GM.RealDragObject.GetComponent<DragAndDrop>().ishaSand = true;
                        GetMouseDownSuccessEvent(hit);
                    }
                    if (ObjectNum == 1) //해
                    {
                        if ((hit.transform.name == "Moon(Clone)" || hit.transform.name == "Star(Clone)") && hit.transform.GetComponent<DragAndDrop>().LinkOBJ == null)
                        {
                            GetMouseDownSuccessEvent(hit);
                        }
                    }
                    else if (ObjectNum == 2) // 달
                    {
                        if ((hit.transform.name == "Sun(Clone)" || hit.transform.name == "Earth(Clone)") && hit.transform.GetComponent<DragAndDrop>().LinkOBJ == null)
                        {


                            GetMouseDownSuccessEvent(hit);
                        }
                    }
                    else if (ObjectNum == 3) //별
                    {
                        if ((hit.transform.name == "Sun(Clone)" || hit.transform.name == "Earth(Clone)") && hit.transform.GetComponent<DragAndDrop>().LinkOBJ == null)
                        {


                            GetMouseDownSuccessEvent(hit);
                        }
                    }
                    else if (ObjectNum == 4) // 지구
                    {
                        if ((hit.transform.name == "Moon(Clone)" || hit.transform.name == "Star(Clone)") && hit.transform.GetComponent<DragAndDrop>().LinkOBJ == null)
                        {
                            Debug.Log("HI4");

                            GetMouseDownSuccessEvent(hit);
                        }
                    }
                    else if (!hit)
                    {
                        Debug.Log("SDADASDSDSD");
                    }
                    if(hit.transform.gameObject == GM.RealDragObject.gameObject)
                    {

                        GetMouseDownSuccessEvent(hit);
                    }
                }
                if (GM.RealDragObject.GetComponent<DragAndDrop>().traceObj.GetComponent<ads>() != null)
                    GM.RealDragObject.GetComponent<DragAndDrop>().traceObj.GetComponent<ads>().SetLastNode();
            }

        }
        if (Input.GetMouseButtonUp(0) && GM.isInsert && count == 0) //클릭하고 있을때
        {
            //
            bClick = true;
            count++;

            pfm.Test1(GM.RealDragObject.transform);

            firstClickPos = GM.RealDragObject.traceObj.position;
            firstClickPos.z = 0;

            EFX.Play();

            lineRenderer.SetPosition(0, firstClickPos);
            lineRenderer.SetPosition(1, new Vector3(this.firstClickPos.x, this.firstClickPos.y + 0.5f, 0));
            GM.RealDragObject.traceObj.GetComponent<NodeScript>().NodeLine = lineRenderer;
            //

        }

    }

    void isAble2DrawLine()
    {

    }
    void GetMouseDownSuccessEvent(RaycastHit2D hit)
    {
        if (hit.collider != null && !isLineOut && !isDirectionOut)
        {
            bClick = false;
            ssssseeePos = Vector3.zero;
            dragPos = Vector3.zero;

            lineRenderer.SetPosition(1, hit.transform.position);
            lineRenderer.SetColors(Color.white, Color.white);

            count = 0;

            tutotialScript.isSandConnected = true;

            if (!hit.transform.CompareTag("SandDown") && hit.transform.GetComponent<DragAndDrop>().ishaSand)
            {
                this.GM.RealDragObject.GetComponent<DragAndDrop>().ishaSand = true;
            }

            if (this.GM.RealDragObject.GetComponent<DragAndDrop>().ishaSand)
            {
                GM.RealDragObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (this.GM.RealDragObject.GetComponent<DragAndDrop>().traceObj.CompareTag("goal"))
            {
                this.GM.RealDragObject.GetComponent<DragAndDrop>().traceObj.GetComponent<NodeScript>().isEnd();
            }

            LineRenderer a = Instantiate(LinePrefab).GetComponent<LineRenderer>();
            a.SetPosition(0, Vector3.zero);
            a.SetPosition(1, Vector3.zero);
            a.gameObject.name = "LineObjectDesu";
            if (hit.transform.gameObject.GetComponent<DragAndDrop>() != null)
            {
                hit.transform.gameObject.GetComponent<DragAndDrop>().LineObj = this.lineRenderer;
            }
            pfm.Test2(hit);

            gameObject.GetComponent<LineRenderScript>().enabled = false;
            GM.isInsert = false;
        }
    }


    //IEnumerator StartParticle()
    //{
    //    DragAndDrop PaticleObj = GM.RealDragObject;
    //    yield return new WaitForSeconds(1.5f);
    //}

    public void SetLine()
    {
        bClick = true;


        GM.RealDragObject.traceObj.GetComponent<NodeScript>().NodeLine = lineRenderer;

        firstClickPos = GM.RealDragObject.traceObj.position;
        firstClickPos.z = 0;


        lineRenderer.SetPosition(0, firstClickPos);
        lineRenderer.SetPosition(1, mainCam.ScreenToWorldPoint(Input.mousePosition));
    }

    void DrawRightLine()
    {
        if (!(lineRenderer.GetPosition(0).x - ssssseeePos.x > 0))
        {
            isDirectionOut = false;
            lineRenderer.SetPosition(1, ssssseeePos);
        }
        else
        {
            isDirectionOut = true;
            lineRenderer.SetColors(Color.red, Color.red);
            lineRenderer.SetPosition(1, new Vector3(lineRenderer.GetPosition(0).x, ssssseeePos.y, 0));
        }
    }

    void DrawLeftLine()
    {
        if (lineRenderer.GetPosition(0).x - ssssseeePos.x > 0)
        {
            isDirectionOut = false;
            lineRenderer.SetPosition(1, ssssseeePos);
        }
        else
        {
            isDirectionOut = true;
            lineRenderer.SetColors(Color.red, Color.red);
            lineRenderer.SetPosition(1, new Vector3(lineRenderer.GetPosition(0).x, ssssseeePos.y, 0));
        }
    }
}

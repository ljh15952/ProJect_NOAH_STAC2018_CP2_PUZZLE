using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    public Transform currentChoiceNode;


    public DragAndDrop RealDragObject;

    public LineRenderScript LRS;

    public bool isInsert;

    public string ClickObjName;

    int FUCK = 0;

    // Use this for initialization
    void Start()
    {
        isInsert = false;
        currentChoiceNode = null;
    }

    // Update is called once per frame
    void Update()
    {

        MouseDownEvent();

        MouseDragEvent();

        MouseUpEvent();
    }


    void MouseDownEvent()
    {
        if (Input.GetMouseButtonDown(0)&&!isInsert)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hitArray = Physics2D.RaycastAll(mousePos, Vector2.zero);

            for (int i = 0; i < hitArray.Length; i++)
            {
                if (hitArray[i].collider.gameObject.name.Contains("Clone")&&this.currentChoiceNode==null)
                {
                        currentChoiceNode = hitArray[i].transform;

                        DragAndDrop dragObj = currentChoiceNode.GetComponent<DragAndDrop>();


                        ClickObjName = dragObj.name;



                        RealDragObject = dragObj;
                     
                        dragObj.SetTraceObjfalse();


                        break;
                }
            }
        }
    }


    void MouseDragEvent()
    {
        if (Input.GetMouseButton(0) && currentChoiceNode != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentChoiceNode.position = mousePos;
        }

    }


    void MouseUpEvent()
    {
        if (Input.GetMouseButtonUp(0) && currentChoiceNode != null)
        {
            DragAndDrop dragObj = currentChoiceNode.GetComponent<DragAndDrop>();

            //RealDragObject = dragObj;

            RemoveNodeFunc();

            if (RealDragObject != null)
            {
                if (RealDragObject.traceObj !=null)
                {
                    if (FUCK == 0)
                    {
                        LRS.SetLine();
                        FUCK = 231224234;
                    }
                    isInsert = true;
                }
                dragObj.TracePuzzleObject();
            }
            currentChoiceNode = null;
        }
    }

    void RemoveNodeFunc()
    {
        DragAndDrop dragObj = currentChoiceNode.GetComponent<DragAndDrop>();

        if (currentChoiceNode.transform.position.x > 6.6f && currentChoiceNode.name.Contains("Clone"))
        {
            RemoveNode();
        }
    }

    public void RemoveNode()
    {
        DragAndDrop dragObj = currentChoiceNode.GetComponent<DragAndDrop>();

        Destroy(currentChoiceNode.gameObject);
        dragObj.UI.nCount++;
        dragObj.UI.SetCountText(dragObj.UI.nCount);
        RealDragObject = null;
    }

}

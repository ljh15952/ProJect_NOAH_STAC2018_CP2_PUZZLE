using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragAndDrop : MonoBehaviour
{
    //Instantiate(ButtonArr[ClickNum], vec, Quaternion.identity);
    public Vector2 defaultPos; //원위치
    public UIManager UI;
    public GameObject LinkOBJ;
    public Transform traceObj;
    String NodeName;

    public GameMng GM;

    public LineRenderer LineObj;
    public bool ishaSand;

    //TODO!!!


    private void Start()
    {
        this.ishaSand = false;
        traceObj = null;
    }
    private void Update()
    {
        if (base.GetComponent<SpriteRenderer>().sortingOrder <= 0)
            base.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
    void OnMouseUp()
    {

    }
    private void OnMouseDown()
    {
        defaultPos = this.transform.position;
        if (!this.name.Contains("Clone") && UI.nCount > 0 && !GM.isInsert) //클릭한게 클론아닐때
        {
            UI.nCount--;
            Instantiate(this, defaultPos, Quaternion.identity);
            UI.SetCountText(UI.nCount);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Puzzle") || collision.gameObject.CompareTag("goal")) && !collision.GetComponent<NodeScript>().isNodepull)
        {
            defaultPos = collision.transform.position;
            traceObj = collision.transform;
        }

        //if(collision.gameObject.CompareTag("SandDown"))
        //{
        //    defaultPos = collision.transform.position;
        //    traceObj = collision.transform;
        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
    public void TracePuzzleObject()
    {
        if (traceObj != null && !traceObj.GetComponent<NodeScript>().isNodepull)
        {
            traceObj.GetComponent<NodeScript>().isNodepull = true;  ///
            traceObj.GetComponent<NodeScript>().inNodeName = gameObject.name;
            this.traceObj.GetComponent<NodeScript>().inNode = base.gameObject;
            this.transform.position = traceObj.position;
        }
        else
        {
            Debug.Log(defaultPos);
            this.GM.RemoveNode();
            this.transform.position = defaultPos;
        }

    }
    public void SetTraceObjfalse()
    {
        Debug.Log("SA");
        if (this.traceObj != null)
        {
            this.ishaSand = false;
            base.transform.GetChild(0).gameObject.SetActive(false);
            if (this.LinkOBJ != null)
            {
                this.LinkOBJ.transform.GetChild(0).gameObject.SetActive(false);
                this.LinkOBJ.GetComponent<DragAndDrop>().ishaSand = false;
                this.LinkOBJ.GetComponent<particleFollower>().GoPos = null;
            }
            if (this.LineObj != null)
            {
                this.LineObj.SetPosition(0, Vector3.zero);
                this.LineObj.SetPosition(1, Vector3.zero);
            }
            if (base.gameObject.GetComponent<particleFollower>().GoPos != null)
            {
                if (base.gameObject.GetComponent<particleFollower>().GoPos.GetComponent<DragAndDrop>()!=null)
                 base.gameObject.GetComponent<particleFollower>().GoPos.GetComponent<DragAndDrop>().LinkOBJ = null;
            }
            else if (base.GetComponent<DragAndDrop>().LinkOBJ == base.gameObject)
            {
                base.GetComponent<DragAndDrop>().LinkOBJ = null;
            }

            base.gameObject.GetComponent<DragAndDrop>().LinkOBJ = null;
            base.gameObject.GetComponent<particleFollower>().GoPos = null;
            traceObj.GetComponent<NodeScript>().isNodepull = false; ///
            traceObj.GetComponent<NodeScript>().inNodeName = null; ///
            Destroy(traceObj.GetComponent<NodeScript>().NodeLine.gameObject);
            traceObj.GetComponent<NodeScript>().NodeLine = null;
        }
       
    }


}


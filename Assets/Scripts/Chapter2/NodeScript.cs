using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour {


    public bool isNodepull;

    public LineRenderer NodeLine;
    public string inNodeName;

    public GameObject inNode;
    public bool isgoal;

    public void isEnd()
    {
        if(inNode.GetComponent<DragAndDrop>().ishaSand)
        {
            isgoal = true;
        }
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(NodeLine)
        {
        }
	}
}

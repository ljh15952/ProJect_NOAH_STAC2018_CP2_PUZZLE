using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NodesArray : MonoBehaviour
{

    public GameObject[,] NodeArray;
    public int[,] direction;

    int SpecialNum;
    int SpecialNum2;

    public GameObject text;
    public stageManager SM;
    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(1280, 720, false);
        NodeArray = new GameObject[4, 7];
    }

    public void AddArray()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                NodeArray[i, j] = GameObject.Find("Node[" + i.ToString() + ']' + '[' + j.ToString() + ']');
            }
        }
    }
    IEnumerator ClearFuncI()
    {
        yield return new WaitForSeconds(1.7f);
        ClearFunc();
    }
    // Update is called once per frame
    void Update()
    {
        if(stageManager.StageNum ==1)
        {
            if (NodeArray[3, 1].GetComponent<NodeScript>().isgoal && NodeArray[3, 5].GetComponent<NodeScript>().isgoal)
            {
                StartCoroutine(ClearFuncI());
            }
        }
        if(stageManager.StageNum ==2)
        {
            if (NodeArray[3, 2].GetComponent<NodeScript>().isgoal && NodeArray[3, 4].GetComponent<NodeScript>().isgoal)
                StartCoroutine(ClearFuncI());

        }
        if (stageManager.StageNum==3)
        {
            if ((NodeArray[2, 0] !=null && NodeArray[2, 6] != null && NodeArray[3, 1] != null && NodeArray[3, 3] != null && NodeArray[3, 5] != null))
            {
                if (NodeArray[2, 0].GetComponent<NodeScript>().isgoal && NodeArray[2, 6].GetComponent<NodeScript>().isgoal && NodeArray[3, 1].GetComponent<NodeScript>().isgoal && NodeArray[3, 3].GetComponent<NodeScript>().isgoal && NodeArray[3, 5].GetComponent<NodeScript>().isgoal)
                    StartCoroutine(ClearFuncI());

            }
        }
    }

    void ClearFunc()
    {
        text.gameObject.SetActive(true);

    }
}

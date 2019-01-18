using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ads : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    bool hi = false;
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NodeScript>().inNode != null)
            if (GetComponent<NodeScript>().inNode.GetComponent<DragAndDrop>().ishaSand == false)
            {

                GetComponent<NodeScript>().inNode.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            }

    }


    public void SetLastNode()
    {
        if (GetComponent<NodeScript>().inNode == null)
            return;

        if (GetComponent<NodeScript>().inNode.GetComponent<DragAndDrop>().ishaSand == false)
        {
            Debug.Log("HIHH");
            return;
        }
        StartCoroutine(SetAlphaState());
    }



    IEnumerator SetAlphaState()
    {
        int i = 255;
        while (i >= 0)
        {
            yield return new WaitForSeconds(0.005f);
            GetComponent<NodeScript>().inNode.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, (byte)i);
            i--;
        }
    }
}

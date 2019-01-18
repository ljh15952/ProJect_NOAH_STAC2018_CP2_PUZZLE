using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuckingSibal : MonoBehaviour {

    public GameObject FUCK;
    float curangle;
    float curangle2;
    private void OnMouseDown()
    {
        curangle2 = FUCK.transform.eulerAngles.z;
        curangle = GetAngle();
    }

    private void OnMouseDrag()
    {
        
        FUCK.transform.eulerAngles = new Vector3(0,0, (curangle2 + (GetAngle()-curangle)*2));
        
       
    }
    float GetAngle()
    {
        Vector3 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle;

        float xPos = FUCK.transform.position.x - mousePos.x;
        float yPos = FUCK.transform.position.y - mousePos.y;

        angle = Mathf.Atan2(yPos, xPos) * Mathf.Rad2Deg;
        return angle;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    public Text CountText;
    public int nCount;


    public void SetCountText(int nCount)
    {
        CountText.text = nCount.ToString();
    }
}

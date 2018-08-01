using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class stageManager : MonoBehaviour {


    public static int StageNum =1;
    public NodesArray NA;

    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;


    public Text SunText;
    public Text MoonText;
    public Text StarText;
    public Text EarthText;


    // Use this for initialization
    void Start ()
    {

        switch (StageNum)
        {
            case 1:
                Stage1.SetActive(true);
                SunText.GetComponent<UIManager>().nCount = 2;
                MoonText.GetComponent<UIManager>().nCount = 2;
                StarText.GetComponent<UIManager>().nCount = 2;
                EarthText.GetComponent<UIManager>().nCount = 2;
                break;
            case 2:
                Stage2.SetActive(true);
                SunText.GetComponent<UIManager>().nCount = 3;
                MoonText.GetComponent<UIManager>().nCount = 3;
                StarText.GetComponent<UIManager>().nCount = 3;
                EarthText.GetComponent<UIManager>().nCount = 3;
                break;
            case 3:
                Stage3.SetActive(true);
                SunText.GetComponent<UIManager>().nCount = 2;
                MoonText.GetComponent<UIManager>().nCount = 4;
                StarText.GetComponent<UIManager>().nCount = 3;
                EarthText.GetComponent<UIManager>().nCount = 2;
                break;
        }
        NA.AddArray();
        SunText.GetComponent<UIManager>().SetCountText(SunText.GetComponent<UIManager>().nCount);
        MoonText.GetComponent<UIManager>().SetCountText(MoonText.GetComponent<UIManager>().nCount);
        StarText.GetComponent<UIManager>().SetCountText(StarText.GetComponent<UIManager>().nCount);
        EarthText.GetComponent<UIManager>().SetCountText(EarthText.GetComponent<UIManager>().nCount);

    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}

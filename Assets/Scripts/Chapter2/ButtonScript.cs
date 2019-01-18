using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour {



    // Use this for initialization

    // Update is called once per frame

    public GameObject tuto;
    public GameObject Click;
    public GameObject RealClick;

    public AudioSource UIclickSound;
	void Update () {
		
	}

    public void goToIngame()
    {
        UIclickSound.Play();

      //  SceneManager.LoadScene("a3");
    }

    public void ClickOkBt()
    {
        UIclickSound.Play();
        tuto.SetActive(false);
        Click.SetActive(true);
        RealClick.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
    }

    public void SoundPlay()
    {
        UIclickSound.Play();
    }

    public void RestartStage()
    {
        UIclickSound.Play();

        SceneManager.LoadScene("a3");
    }

    public void GoToStageSelect()
    {
        UIclickSound.Play();
        Debug.Log("HI");
        // SceneManager.LoadScene("a3");
    }

    public void NextStage()
    {
        UIclickSound.Play();

        SceneManager.LoadScene("a3");
        stageManager.StageNum++;
    }

    
}

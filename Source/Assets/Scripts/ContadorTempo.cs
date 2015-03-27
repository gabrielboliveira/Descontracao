using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ContadorTempo : MonoBehaviour {

    private DateTime endTime;

    bool endTimeSet = false;

    Canvas canv;

    private GlobalScript globalScript;

	// Use this for initialization
	void Start () {
        
        this.globalScript = GameObject.Find("GlobalScript").GetComponent<GlobalScript>();

        canv = GameObject.Find("Canvas").GetComponent<Canvas>();
        
	}

    public void SetEndTime(float val)
    {
        this.endTime = DateTime.Now.AddMinutes(val);
        this.endTimeSet = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (endTime >= DateTime.Now && this.endTimeSet)
        {
            TimeSpan t = endTime.Subtract(DateTime.Now);

            string answer = string.Format("{0:D2}:{1:D2}",
                            t.Minutes,
                            t.Seconds);

            Text tempo = gameObject.GetComponent<Text>();

            tempo.text = answer;
        }
        else
        {
            // Terminou o tempo, abrir o final

            Time.timeScale = 0;
            GameObject.Find("Player").GetComponent<CharacterMotor>().enabled = false;
            //GameObject.Find("Player").GetComponent<CharacterMotor>().movingPlatform.enabled = false;
            GameObject.Find("Player").GetComponent<MouseLook>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;

            canv.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            canv.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            canv.gameObject.transform.GetChild(2).gameObject.SetActive(true);

            Text score = GameObject.Find("Score").GetComponent<Text>();
            score.text = this.globalScript.scoreAtual.ToString() + " pontos";

            Screen.showCursor = true;
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseCanvasScript : MonoBehaviour {
    bool added = false;
    public GameObject gris;
    public GameObject startText;
    public GameObject deathText;
    float timer;
    public GameObject levelFinishObject;

    public Text timeText;
    public Text deathsText;
    public Text coinsText;

	// Use this for initialization
	void Start () {
        //if (GameLogic.instance != null) {
        //    GameLogic.instance.pauseCanvas = this;
        //    added = true;
        //}
        gris.SetActive(false);
        levelFinishObject.SetActive(false);
	}
	
    public void ActivateFinishScreen() {
        if (!levelFinishObject.activeInHierarchy) {
            GameLogic.instance.savedCoins += GameLogic.instance.coinsGrabbed;
            levelFinishObject.SetActive(true);
            //timeText.text = GameLogic.instance.timeElapsed.ToString();

            int approxTime = (int)GameLogic.instance.timeElapsed;
            timeText.text = approxTime.ToString();

            deathsText.text = GameLogic.instance.timesDied.ToString();
            coinsText.text = GameLogic.instance.coinsGrabbed.ToString();
        }
    }

    public void ShowDeath() {
        deathText.SetActive(true);
        if (InputManager.GetKeyDown(1)) {
            Debug.Log("Reset=");
            GameLogic.instance.ResetScene();
        }else if (InputManager.GetKeyDown(0)) {
            GameLogic.instance.ToMainMenu();
        }

    }

	// Update is called once per frame
	void Update () {

        if (GameLogic.instance != null) {
            if (!added) {
                GameLogic.instance.pauseCanvas = this;
                added = true;
            }
            if (GameLogic.instance.started) {

                if (GameLogic.instance.paused) {
                    if (!gris.activeInHierarchy) {
                        gris.SetActive(true);
                    }
                } else {
                    timer += Time.deltaTime;
                    if (gris.activeInHierarchy) {
                        gris.SetActive(false);
                    }
                }
            } else {
                PreStartStuff();
            }


        }
    }

    void PreStartStuff() {
        if (InputManager.GetKeyDown(1)) {
            GameLogic.instance.StartGame();
            startText.SetActive(false);
            timer = 0;
        } else {

            timer += Time.deltaTime;
            if (timer > 0.3f && timer < 0.6f) {
                startText.SetActive(true);
            } else if (timer > 0.6f) {
                startText.SetActive(false);
                timer = 0;
            }

        }
    }
}

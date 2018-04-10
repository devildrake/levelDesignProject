using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {
    [HideInInspector]
    public static GameLogic instance;
    bool inMainMenu;
    public bool paused;
    public bool deadPlayer;
    public float localTimeScale;
    public PauseCanvasScript pauseCanvas;
    public bool started = false;
    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
        } else if(instance!=this) {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        localTimeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (inMainMenu) {
            if (pauseCanvas != null) {
                if (!deadPlayer) {
                    if (started) {
                        if (InputManager.GetKeyDown(0)) {
                            paused = !paused;
                        }

                        if (paused) {
                            Time.timeScale = 0;
                        } else {
                            Time.timeScale = localTimeScale;

                        }

                        if (InputManager.GetKeyDown(3)) {
                            ResetScene();
                        }
                    }
                } else{
                    pauseCanvas.ShowDeath();
                    Debug.Log("DeadPlayer");
                }
            } else {
                Debug.Log("NullPauseCanvas");
            }
        }
	}

    public void ToMainMenu() {
        SceneManager.LoadScene("MainMenu");
        started = false;
        inMainMenu = true;
    }

    public void ResetScene() {
        started = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        inMainMenu = false;
    }

    public void LoadScene(int index) {
        inMainMenu = false;
        started = false;
        SceneManager.LoadScene(index);
    }
    
    public void StartGame() {
        started = true;
    }

}

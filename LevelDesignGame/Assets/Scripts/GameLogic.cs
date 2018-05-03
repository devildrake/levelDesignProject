using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {
    [HideInInspector]
    public static GameLogic instance;
    bool inMainMenu;
    public bool paused;
    public float localTimeScale;
    public PauseCanvasScript pauseCanvas;
    public bool started = false;
    public bool died = false;
    public bool godMode = false;
    public bool levelFinished = false;
    public PlayerController player;
    public Vector3 originalPlayerPos;
    public int timesDied = 0;
    public double timeElapsed = 0;
    public int coinsGrabbed = 0;
    public int savedCoins = 0;
    public List<ResetableObject> ResetableObjects;
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
        if (!inMainMenu) {
            if (pauseCanvas != null) {
                if (started&&!levelFinished) {
                        if (InputManager.GetKeyDown(0)) {
                            paused = !paused;
                        }
                        if (paused) {
                            Time.timeScale = 0;
                        } else {
                            Time.timeScale = localTimeScale;
                        timeElapsed += Time.deltaTime;
                        }

                        if (InputManager.GetKeyDown(3)) {
                            ResetScene();
                        }
                } else if (died){
                    pauseCanvas.ShowDeath();
                    Debug.Log("DeadPlayer");
                }

                if (levelFinished) {
                    pauseCanvas.ActivateFinishScreen();
                    player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

                    foreach(ResetableObject r in ResetableObjects) {
                        if (r.GetComponent<Rigidbody2D>() != null) {
                            r.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                        }
                    }

                }

            } else {
                Debug.Log("NullPauseCanvas");
            }
        }
	}

    public void ToMainMenu() {
        levelFinished = false;
        ResetableObjects.Clear();
        SceneManager.LoadScene("MainMenu");
        started = false;
        inMainMenu = true;
    }

    public void ResetScene() {
        levelFinished = false;
        ResetableObjects.Clear();
        started = false;
        paused = false; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        inMainMenu = false;
    }

    public void LoadScene(int index) {
        levelFinished = false;
        ResetableObjects.Clear();
        inMainMenu = false;
        started = false;
        SceneManager.LoadScene(index);
    }
    
    public void StartGame() {
        started = true;
    }

    public void KillPlayer() {
        if (player != null) {
            if (!godMode) {
                player.speedMultiplier = 1;
                died = true;
                started = false;
                timesDied++;
                coinsGrabbed = 0;
                player.transform.position = originalPlayerPos;
                //gameObject.SetActive(false);
                foreach(ResetableObject r in ResetableObjects) {
                    r.ResetPosition();
                }
            }
        }
    }

}

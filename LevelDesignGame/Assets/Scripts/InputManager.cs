using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    [HideInInspector]
    public GameLogic instance;

    public static bool upButton = false;
    public static bool prevUpButton = false;
    public static bool pauseButton = false;
    public static bool prevPauseButton = false;
    public static bool restartButton = false;
    public static bool prevRestartButton = false;
    public static bool rightButton = false;
    public static bool prevRightButton = false;
    public static bool godModeButton = false;
    public static bool prevGodModeButton = false;

    static void PrevInputs() {
        prevPauseButton = pauseButton;
        prevRestartButton = restartButton;
        prevRightButton = rightButton;
        prevUpButton = upButton;
        prevGodModeButton = godModeButton;

    }

    static void CheckInputs() {
        pauseButton = Input.GetAxisRaw("Pause")==1;
        upButton = Input.GetAxisRaw("Up") == 1;
        rightButton = Input.GetAxisRaw("Horizontal") == 1;
        restartButton = Input.GetAxisRaw("Restart") == 1;
        godModeButton = Input.GetAxisRaw("GodMode") == 1;
    }

    /// <summary>
    /// Pause, Up, Horizontal, Restart, GodMode
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool GetKeyDown(int i) {
        bool temp=false;
        switch (i) {
            case 0:
                temp = pauseButton && !prevPauseButton;
                break;
            case 1:
                temp = upButton && !prevUpButton;
                break;
            case 2:
                temp = rightButton && !prevRightButton;
                break;
            case 3:
                temp = restartButton && !prevRestartButton;
                break;
            case 4:
                temp = godModeButton && !prevGodModeButton;
                break;

        }
        return temp;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PrevInputs();
        CheckInputs();

	}
}

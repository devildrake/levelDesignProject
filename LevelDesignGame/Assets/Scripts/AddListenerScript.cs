using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Script para añadir un listener al método GameLogic.LoadMenu() a los botones que pertoque;
public class AddListenerScript : MonoBehaviour {
    [Tooltip("0 -> Menu Principal \n1 -> Reincio nivel")]
    public int toDo;
    public int index;
    private Button myselfButton;

    void Start() {
        myselfButton = GetComponent<Button>();
        switch (toDo) {
            case 0:
                myselfButton.onClick.AddListener(() => GameLogic.instance.ToMainMenu());
                break;
            case 1:
                myselfButton.onClick.AddListener(() => GameLogic.instance.LoadScene(index));//(GameLogic.instance.GetCurrentLevelIndex()+1));
                break;
            case 2:
                myselfButton.onClick.AddListener(() => GameLogic.instance.ResetScene());//(GameLogic.instance.GetCurrentLevelIndex()+1));
                break;
            case 3:
                myselfButton.onClick.AddListener(() => GameLogic.instance.paused = false);
                break;
            case 4:
                myselfButton.onClick.AddListener(() => GameLogic.instance.paused = true);
                break;
            case 5:
                myselfButton.onClick.AddListener(() => GameLogic.instance.LoadScene(SceneManager.GetActiveScene().buildIndex+1));
                break;
            default:
                break;
        }
    }
}

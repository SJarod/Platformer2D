using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameObject menu;
    GameObject pause;
    GameObject youWin;
    GameObject youLose;
    GameObject hud;

    public float gameSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu");
        pause = GameObject.FindGameObjectWithTag("Pause");
        youWin = GameObject.FindGameObjectWithTag("YouWin");
        youLose = GameObject.FindGameObjectWithTag("YouLose");
        hud = GameObject.FindGameObjectWithTag("Display");

        menu.SetActive(true);
        pause.SetActive(false);
        youWin.SetActive(false);
        youLose.SetActive(false);
        hud.SetActive(false);

        gameSpeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            showPause();
    }

    public void showMenu()
    {
        menu.SetActive(true);
        pause.SetActive(false);
        youWin.SetActive(false);
        youLose.SetActive(false);
        hud.SetActive(false);

        gameSpeed = 0f;
        SceneManager.LoadScene("level1");
    }

    public void showPause()
    {
        menu.SetActive(false);
        pause.SetActive(true);
        youWin.SetActive(false);
        youLose.SetActive(false);
        hud.SetActive(false);

        gameSpeed = 0f;
    }

    public void showYouWin()
    {
        menu.SetActive(false);
        pause.SetActive(false);
        youWin.SetActive(true);
        youLose.SetActive(false);
        hud.SetActive(false);

        gameSpeed = 0f;
    }

    public void showYouLose()
    {
        menu.SetActive(false);
        pause.SetActive(false);
        youWin.SetActive(false);
        youLose.SetActive(true);
        hud.SetActive(false);

        gameSpeed = 0f;
    }

    public void showHUD()
    {
        menu.SetActive(false);
        pause.SetActive(false);
        youWin.SetActive(false);
        youLose.SetActive(false);
        hud.SetActive(true);

        gameSpeed = 1f;
    }
}

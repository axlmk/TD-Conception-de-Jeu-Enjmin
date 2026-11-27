using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tenkoku.Core;

public enum Choice
{
    Time,
    Weather,
    Enemy
};


public class GameManagement : MonoBehaviour
{
    public Canvas dialogCanvas;
    public GameObject menu;
    public TenkokuModule weatherSystem;
    private Choice currentChoice;
    public GameObject bigBoss;
    public GameObject swarm;
    private bool bossIsChoosen = false;

    void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (bossIsChoosen)
        {
            if (bigBoss == null || swarm.transform.childCount == 0)
            {
                menu.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void Jouer()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        menu.SetActive(false);
    }

    public void triggerChoice(bool IsA)
    {
        switch (currentChoice)
        {
            case Choice.Time:
                if (IsA)
                {
                    setDay();
                }
                else
                {
                    setNight();
                }
                break;

            case Choice.Weather:
                if (IsA)
                {
                    setSnow();
                }
                else
                {
                    setRain();
                }
                break;

            case Choice.Enemy:
                bossIsChoosen = true;
                if (IsA) { setBigBoss(); } else { setSwarm(); }
                break;

            default:
                break;
        }

        dialogCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void displayChoiceUI(Choice c)
    {
        dialogCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        string label = "label";
        string buttonA = "A";
        string buttonB = "B";

        switch (c)
        {
            case Choice.Time:
                label = "- Il faut qu'il fasse nuit, comme ca il se battra comme un ninja\n- Bah non sinon on y verra rien, faut que ce soit le jour";
                buttonA = "Jour";
                buttonB = "Nuit";
                break;
            case Choice.Weather:
                label = "- J'aimerai trop qu'il se batte sous la neige, en plus c'est bientot noel\n- Non, moi je veux qu'il pleuve, comme dans les films tristes";
                buttonA = "Neige";
                buttonB = "Pluie";
                break;
            case Choice.Enemy:
                label = "- Faut qu'il finisse son combat contre un gros villain avec plein de points de vie\n- Non, c'est mieux s'il y a plein de petits ennemis, il va trop galerer a tous les tuer";
                buttonA = "Gross boss";
                buttonB = "Essain boss";
                break;
            default:
                break;
        }
        currentChoice = c;

        dialogCanvas.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = label;
        dialogCanvas.gameObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonA;
        dialogCanvas.gameObject.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonB;
    }

    private void setDay()
    {
        weatherSystem.currentHour = 12;
    }

    private void setNight()
    {
        weatherSystem.currentHour = 3;
    }

    private void setRain()
    {
        weatherSystem.weather_OvercastAmt = 0.2f;
        weatherSystem.weather_RainAmt = 0.6f;
    }

    private void setSnow()
    {
        weatherSystem.weather_OvercastAmt = 0.15f;
        weatherSystem.weather_SnowAmt = 0.6f;
    }

    private void setBigBoss()
    {
        bigBoss.SetActive(true);
    }

    private void setSwarm()
    {
        swarm.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
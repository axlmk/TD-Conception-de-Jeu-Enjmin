using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tenkoku.Core;

public enum Choice
{
    Time,
    Weather
};


public class GameManagement : MonoBehaviour
{
    public Canvas dialogCanvas;

    public TenkokuModule weatherSystem;

    private Choice currentChoice;

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
                    Debug.Log("Neige");
                }
                else
                {
                    Debug.Log("Pluie");
                }
                break;

            default:
                Debug.Log("Error");
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
                currentChoice = Choice.Time;
                break;
            case Choice.Weather:
                label = "- J'aimerai trop qu'il se batte sous la neige, en plus c'est bientot noel\n- Non, moi je veux qu'il pleuve, comme dans les films tristes";
                buttonA = "Neige";
                buttonB = "Pluie";
                currentChoice = Choice.Weather;
                break;
            default:
                break;
        }

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
}
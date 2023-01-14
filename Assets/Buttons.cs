using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Buttons : MonoBehaviour
{
    [SerializeField] Button buttonPrefab;
    [SerializeField] GameObject buttonsGroupParent;
    Button[] calculatorButtons;
    Calculation calculation;
    string calculationScreen;

    string[] buttonTypes = 
        {"AC", "±", "%", "clear",
         "7", "8", "9", "÷",
         "4", "5", "6", "x",
         "1", "2", "3", "-",
         "0", ".", "=", "+",
        };

    void Awake() {
        calculation = FindObjectOfType<Calculation>();
    }

    void Start()
    {
        //CreateAllButtons();
        GetAllButtons();
    }
    
    void CreateAllButtons()
    {
        for (int i=0; i<buttonTypes.Length; i++)
        {
            Button newButton = Instantiate(buttonPrefab);
            newButton.transform.SetParent(buttonsGroupParent.transform, false);
            newButton.gameObject.name = "button_" + buttonTypes[i];
            // newButton.gameObject.tag = "CalculatorButton";
            TextMeshProUGUI t = newButton.GetComponentInChildren<TextMeshProUGUI>();
            t.text = buttonTypes[i];
        }
    }

    void GetAllButtons()
    {
        calculatorButtons = buttonsGroupParent.GetComponentsInChildren<Button>();

        if (calculatorButtons.Length != buttonTypes.Length)
        {
            Debug.LogWarning("Number of buttons are not same to number of types\nCheck code");
            return;
        }
        int i=0;
        foreach (Button b in calculatorButtons)
        {
            b.gameObject.name = "button_" + buttonTypes[i]; // renaming buttons
            TextMeshProUGUI t = b.GetComponentInChildren<TextMeshProUGUI>();
            t.text = buttonTypes[i];
            i++;

            // Debug.Log(b.name);
        }
    }

    public void OnButtonSelected_number(int num)
    {
        calculation.UpdateScreen_numbers(num);
    }

    public void OnButtonSelected_function(string str)
    {
        calculation.UpdateScreen_functions(str);
    }
}

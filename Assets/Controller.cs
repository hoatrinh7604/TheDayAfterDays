using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject inputField;
    [SerializeField] Button addButton;
    [SerializeField] Button continueButton;
    [SerializeField] TextMeshProUGUI amountText;
    [SerializeField] TextMeshProUGUI resultText;

    [SerializeField] TextMeshProUGUI currentDate;
    [SerializeField] TextMeshProUGUI dateAfterDays1;
    [SerializeField] TextMeshProUGUI dateAfterDays2;
    [SerializeField] TextMeshProUGUI dayOfTheWeek1;
    [SerializeField] TextMeshProUGUI dayOfTheWeek2;

    [SerializeField] GameObject listFieldParent;

    private List<GameObject> list = new List<GameObject>();
    private List<double> listInt = new List<double>();
    private int amount = 0;
    private double result = 0;

    public string CURRENCY_FORMAT = "#,##0.00";
    public NumberFormatInfo NFI = new NumberFormatInfo { NumberDecimalSeparator = ",", NumberGroupSeparator = "." };

    //Singleton
    public static Controller Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    private void Start()
    {
        Clear();
    }

    public void UpdateResult()
    {
        resultText.text = result.ToString();
    }

    public void UpdateAmount()
    {
        amountText.text = amount.ToString();
    }

    public void OnValueChanged(int index)
    {
        int days = 0;
        if(inputField.GetComponent<TMP_InputField>().text == "")
        {
            days = 0;
        }
        else
        {
            if (CheckValidate(inputField.GetComponent<TMP_InputField>().text))
                days = int.Parse(inputField.GetComponent<TMP_InputField>().text);
            else
                return;
        }

        DateTime date = DateTime.Now.AddDays(days);

        currentDate.text = DateTime.Now.ToString("MM/dd/yyyy");

        dateAfterDays1.text = days.ToString();
        dateAfterDays2.text = date.ToString("MM/dd/yyyy");

        dayOfTheWeek1.text = date.ToString("MM/dd/yyyy");
        dayOfTheWeek2.text = date.DayOfWeek.ToString();
    }

    private bool CheckValidate(string text)
    {
        return text.All(char.IsDigit);
    }

    private void Sum()
    {
        double sum = 0;
        for(int i = 0; i < listInt.Count; i++)
        {
            sum += listInt[i];
        }

        result = sum/amount;
        UpdateResult();
    }

    public void Continue()
    {
        if(amount==0) return;
        double currentResult = result;
        Clear();
        list[0].GetComponent<TMP_InputField>().text = currentResult.ToString();
        listInt[0] = currentResult;
    }

    public void Clear()
    {
        //amount = 0;
        //result = 0;
        //UpdateAmount();
        //UpdateResult();
        //list.Clear();
        //listInt.Clear();
        //continueButton.interactable = false;
        //addButton.interactable = true;
        //for (int i = 0; i < listFieldParent.transform.childCount; i++)
        //{
        //    Destroy(listFieldParent.transform.GetChild(i).gameObject);
        //}
    }

    public void Quit()
    {
        Clear();
        Application.Quit();
    }
}

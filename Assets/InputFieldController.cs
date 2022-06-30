using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldController : MonoBehaviour
{
    [SerializeField] int index;
    [SerializeField] TMP_InputField input;
    private string currentString;
    public void OnValueChanged()
    {
        if (input.text.Length > 6)
        {
            input.text = currentString;
        }
        else
        {
            currentString = input.text;
        }
        Controller.Instance.OnValueChanged(index);
    }

    public void SetIndex(int index)
    {
        this.index = index;
    }
}

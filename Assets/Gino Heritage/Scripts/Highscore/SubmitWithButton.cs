using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
[DisallowMultipleComponent]
[RequireComponent(typeof(TMP_InputField))]
public class SubmitWithButton : MonoBehaviour
{
    public ComputePercurredDistance playerDistanceComponent = null;
    public GameObject SubmitPanel = null;

    public string submitKey = "Submit";
    public bool trimWhitespace = true;
    //Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
    //Apropriate when initializing fields.
    void Start() {
        _inputField = GetComponent<TMP_InputField>();
        _inputField.onEndEdit.AddListener(fieldValue => {
            if (trimWhitespace)
                _inputField.text = fieldValue = fieldValue.Trim();
            if (Input.GetButton(submitKey))
                validateAndSubmit(fieldValue);
        });
    }
    TMP_InputField _inputField;

    bool isInvalid(string fieldValue) {
        // change to the validation you want
        return string.IsNullOrEmpty(fieldValue);
    }
    void validateAndSubmit(string fieldValue) {
        if (isInvalid(fieldValue))
            return;
        Highscores.AddNewHighscore(fieldValue, playerDistanceComponent.neutrinoPercurredDistance);
        SubmitPanel?.SetActive(false);

        // change to whatever you want to run when user submits
       // doSomething(_inputField); // or doSomething(fieldValue);
    }
    // to be called from a submit button onClick event
    public void validateAndSubmit() {
        validateAndSubmit(_inputField.text);
    }
}
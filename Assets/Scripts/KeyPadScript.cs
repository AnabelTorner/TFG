using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadScript : MonoBehaviour
{
    string code;
    string padCode = null;
    int padCodeIndex = 0;

    public GameObject door;
    public GameObject padTrigger;
    public TextMeshProUGUI padCodeText;
    public TextMeshProUGUI codeText;

    private void Start()
    {
        code = codeText.text;
        Debug.Log(code);
    }

    public void CodeFunction(string Numbers)
    {
        if(padCodeIndex < 4)
        {
            padCodeIndex++;
            padCode = padCode + Numbers;
            padCodeText.text = padCode;
        }
    }
    public void Enter()
    {
        if (padCode == code)
        {
            RotateDoor();
            padTrigger.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    public void Delete()
    {
        padCodeIndex = 0;
        padCode = null;
        padCodeText.text = padCode;
    }

    public void RotateDoor()
    {
        if (door != null)
        {
            // Girar el objeto 90 grados alrededor del eje Y
            door.transform.Rotate(0, 90, 0);
        }
    }
}

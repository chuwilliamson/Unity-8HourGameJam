using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetTextBehaviour : MonoBehaviour
{
    [SerializeField]
    private IntVariable variable;
    [SerializeField]
    private string prependText = "Score: ";
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
	void Update ()
    {
        text.text = prependText +  variable.Value.ToString();

    }
}

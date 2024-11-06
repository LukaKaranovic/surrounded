using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public float typingSpeed = 0.05f;
    public string Text;
    private string currentText = "";
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        // Get the TextMeshPro component
        textMeshPro = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        foreach (char x in Text.ToCharArray())
        {
            currentText += x; 
            textMeshPro.text = currentText; 
            yield return new WaitForSeconds(typingSpeed);
        }
        yield break;
    }
}

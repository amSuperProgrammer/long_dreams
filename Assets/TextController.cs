using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] int textNum;
    int thisTextNum;
    TextMesh textMesh;
    List<string> textList = new List<string>
    {
        /*"",*/
        "Hello",
        "Bye"
    };
    int wordNum;

    private void Start()
    {
        textMesh = GetComponent<TextMesh>();
        textMesh.text = "";
    }

    private void FixedUpdate()
    {
        if (thisTextNum != textNum)
        {
            textMesh.text = textList[thisTextNum].Substring(0, wordNum);
            wordNum--;

            if (wordNum == 0)
                thisTextNum = textNum;
        }
        else if(thisTextNum == textNum && wordNum < textList[textNum].Length + 1)
        {
            textMesh.text = textList[thisTextNum].Substring(0, wordNum);
            wordNum++;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] int textNum;
    [SerializeField] List<string> textList;
    TextMesh textMesh;
    int wordNum;
    int oldTextNum;

    private void Start()
    {
        textMesh = GetComponent<TextMesh>();
        textList.Insert(0, "");
        textMesh.text = "";
        textNum = 0;
    }

    private void FixedUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;

        if (textNum != oldTextNum)
        {
            if (wordNum == 0)
                oldTextNum = textNum;
            else
            {
                textMesh.text = textList[oldTextNum].Substring(0, wordNum - 1);
                wordNum--;
            }
        }
        else if (textNum == oldTextNum && textList[textNum].Length > wordNum)
        {
            textMesh.text = textList[textNum].Substring(0, wordNum + 1);
            wordNum++;
        }
    }
}

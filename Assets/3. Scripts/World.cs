using TMPro;
using static MainManager;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;
using System.Collections;

public class World : MonoBehaviour
{
    public int lastline;
    public float startyougjiL;
    public TMP_Text memotext;
    public RectTransform yougjiLengh;

    public string selectRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        memotext = gameObject.transform.Find("Text").GetComponentInChildren<TextMeshProUGUI>();
        yougjiLengh = gameObject.transform.parent.GetComponentInParent<RectTransform>();

        startyougjiL = yougjiLengh.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (memotext.textInfo.lineCount != lastline) // 문자열 길이가 기존과 달라졌다면
        {
            int s = memotext.textInfo.lineCount * 40;
            yougjiLengh.sizeDelta = new Vector2(yougjiLengh.sizeDelta.x, 2000 + s);


            RectTransform rect = gameObject.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, 100 + s);
        }

        lastline = memotext.textInfo.lineCount;

        InputField iF = gameObject.GetComponent<InputField>();
        selectRange = iF.text.Substring(iF.selectionAnchorPosition, iF.selectionFocusPosition - iF.selectionAnchorPosition); // 선택 범위 텍스트
        select = selectRange;
    }
}


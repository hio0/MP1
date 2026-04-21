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
    TMP_InputField iF;

    public string selectRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        memotext = gameObject.transform.Find("Text").GetComponentInChildren<TextMeshProUGUI>();
        yougjiLengh = gameObject.transform.parent.GetComponentInParent<RectTransform>();
        iF = gameObject.GetComponent<TMP_InputField>();

        startyougjiL = yougjiLengh.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (memotext.textInfo.lineCount != lastline) // 문자열 길이가 기존과 달라졌다면
        {
            int s = memotext.textInfo.lineCount * 50;
            yougjiLengh.sizeDelta = new Vector2(yougjiLengh.sizeDelta.x, 2000 + s);


            RectTransform rect = gameObject.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, 100 + s);
        }

        lastline = memotext.textInfo.lineCount;

        if(iF.selectionAnchorPosition > 0 && iF.selectionFocusPosition != iF.selectionAnchorPosition) // 드래그 되었다
        {
            int a = Mathf.Min(iF.selectionAnchorPosition, iF.selectionFocusPosition); // 작은 쪽
            int b = Mathf.Max(iF.selectionAnchorPosition, iF.selectionFocusPosition); // 큰 쪽

            selectRange = iF.text.Substring(a, b - a); // 드레그의 텍스트 가져오기(앞으로 드레그하던, 뒤로 드래그하던 동일하게,) 
            select = selectRange;
        }
    }
}


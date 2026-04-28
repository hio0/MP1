using TMPro;
using static MainManager;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class World : MonoBehaviour
{
    public int lastline;
    public float startyougjiL;
    public TMP_Text memotext;
    public RectTransform yougjiLengh;
    public TMP_InputField iF;

    public string selectRange;
    public string selectRangeP;

    /*
    int a;
    int b;
    */

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
            int s = memotext.textInfo.lineCount * 70;
            yougjiLengh.sizeDelta = new Vector2(yougjiLengh.sizeDelta.x, 2000 + s);


            RectTransform rect = gameObject.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, 100 + s);
        }

        lastline = memotext.textInfo.lineCount;
        /*

        if(iF.selectionAnchorPosition > 0 && iF.selectionFocusPosition != iF.selectionAnchorPosition) // 드래그 되었다
        {
            selectRangeP = null;

            a = Mathf.Min(iF.selectionAnchorPosition, iF.selectionFocusPosition); // 작은 쪽
            b = Mathf.Max(iF.selectionAnchorPosition, iF.selectionFocusPosition); // 큰 쪽

            selectRange = iF.text.Substring(a, b - a); // 드레그의 텍스트 가져오기(앞으로 드레그하던, 뒤로 드래그하던 동일하게,) 
            select = selectRange;

            you = gameObject.GetComponent<World>();
        }
        */
    }
    /*

    public bool IsIt(string st)
    {
        string c = "";
        string d = "";
        string ovTwhat = $"<{st}>";
        string fnLwhat = $"</{st}>";

        for (int i = a; i > 0; i--)
        {
            c = iF.text.Substring(i, a);

            if (c.Contains(ovTwhat))
            {
                break; // c는 a 뒤의 문자열을 스타일을 여는 곳 까지 저장.
            }
            else if (c.Contains(fnLwhat) || c.Length == 1)
            {
                c = "";
                break; // 닫는 것에 닿았거나 끝까지 갔으면 이 드래그 영역엔 없다. 
            }
        }
        for (int i = b; i < iF.text.Length; i++)
        {
            d = iF.text.Substring(b, i);

            if (d.Contains(fnLwhat))
            {
                break;
            }
            else if (d.Contains(ovTwhat) || d.Length == iF.text.Length - 1)
            {
                d = "";
                break;
            }
        }
        if (c.Length != 0 && d.Length != 0)
        {
            selectRangeP = iF.text.Substring(c.Length, d.Length); // 선택 범위보다 조금 더 넓은 범위(스타일이 있는 곳 까지)
            return true;
        }
        else
        {
            return false;
        }
    }
    */
}


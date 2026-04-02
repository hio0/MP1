using TMPro;
using static MainManager;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;
using System.Collections;

public class World : MonoBehaviour
{
    public float startmemoT;
    public float startyougjiL;
    public TMP_Text memotext;
    public RectTransform yougjiLengh;
    public int linelimit;

    int me;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        memotext = gameObject.transform.Find("Text").GetComponentInChildren<TextMeshProUGUI>();
        yougjiLengh = gameObject.transform.parent.GetComponentInParent<RectTransform>();

        startmemoT = memotext.textInfo.lineCount;
        startyougjiL = yougjiLengh.rect.height;

        me = content.childCount - 1; // 내가 몇번째 자식인가?
        linelimit = 4;
    }

    // Update is called once per frame
    void Update()
    {
        float mTI = memotext.textInfo.lineCount;
        if (mTI > startmemoT) // 맨 처음보다 문자열이 늘었다면
        {
            float mt = mTI - startmemoT; // 늘어난 문자열을 계산(현 문자열 수 - 이전 문자열 수

            if (me != 0 && mTI == linelimit)
            {
                for (int i = me; i < content.childCount; i++) // 다음 순서 오브젝트들을 한칸식 이동.
                {
                    RectTransform rect = content.GetChild(i).GetComponent<RectTransform>();
                    rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y - 50f);
                }

                linelimit++;
                float nowL = startyougjiL + 50 * mt;
                yougjiLengh.sizeDelta = new Vector2(yougjiLengh.rect.x, nowL);
            }
            else
            {
                float nowL = startyougjiL + 50 * mt; // 원래 용지 크기에서 50 씩 늘어날 예정.
                yougjiLengh.sizeDelta = new Vector2(yougjiLengh.rect.x, nowL);
            }

        }
    }
}


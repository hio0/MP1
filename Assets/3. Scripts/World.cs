using TMPro;
using UnityEngine;

public class World : MonoBehaviour
{
    public float startmemoT;
    public float startyougjiL;
    public TMP_Text memotext;
    public RectTransform yougjiLengh;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        memotext = gameObject.transform.Find("Text").GetComponentInChildren<TextMeshProUGUI>();
        yougjiLengh = gameObject.transform.parent.GetComponentInParent<RectTransform>();

        startmemoT = memotext.textInfo.lineCount;
        startyougjiL = yougjiLengh.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        float mTI = memotext.textInfo.lineCount;
        if (mTI > startmemoT) // 맨 처음보다 문자열이 늘었다면
        {
            float mt = mTI - startmemoT; // 늘어난 문자열을 계산(현 문자열 수 - 이전 문자열 수

            float nowL = startyougjiL + 50 * mt; // 원래 용지 크기에서 50 씩 늘어날 예정.
            yougjiLengh.sizeDelta = new Vector2(yougjiLengh.rect.x, nowL);

        }
    }
}


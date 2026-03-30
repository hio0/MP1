using static MainManager;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float start;
    public float Lengh;

    int me;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        me = content.childCount - 1; // 내가 몇번째 자식인가?
    }

    // Update is called once per frame
    void Update()
    {
        if (me != content.childCount - 1)
        {
            if (content.GetChild(me + 1).gameObject.tag == "middlename") // 내 다음번째 오브젝트가 목차라면 = 늘어날 수 없다.
            {
                RectTransform rect = content.GetChild(me + 1).GetComponent<RectTransform>();
                rect.transform.position = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + 50);

                //float nowL = start + 50 * mt; // 원래 용지 크기에서 50 씩 늘어날 예정.
                //Lengh.sizeDelta = new Vector2(Lengh.rect.x, nowL);
            }
        }
    }
}

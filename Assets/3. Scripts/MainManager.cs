using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Purchasing.MiniJSON;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainManager : MonoBehaviour
{
    public static Transform content;
    public static string select;

    public TMP_Text mainnamed;
    public GameObject middleMemo;
    public GameObject world;
    public ScrollRect scroll;

    public List<int> contentchilds;
    public List<string> whats;

    string open;
    string close;
    public static World you;

    [System.Serializable]
    public class Data
    {
        public string mainname; // 제목
        public List<int> contentchild; // 용지 배열
        public List<string> what; // 용지 내용
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        content = GameObject.Find("Content").transform;
        Instantiate(world, content);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnMiddle() //목차 삽입
    {
        if (content.transform.childCount == 1 && content.GetChild(0).GetComponent<TMP_InputField>().text == "") // 백지 상태라면
        {
            Destroy(content.GetChild(0).gameObject); // 현재 용지 제거

            Instantiate(middleMemo, content);
            contentchilds.Add(0);
            Instantiate(world, content);
            contentchilds.Add(1);
        }
        else // 이미 내용이 있다면
        {
            Instantiate(middleMemo, content);
            contentchilds.Add(0);
            Instantiate(world, content);
            contentchilds.Add(1);
        }
    }

    public void OnStyle(string st)
    {
        if (select != null) // 드래그 영역에 스타일 넣기
        {
            string ovTwhat = $"<{st}>";
            string fnLwhat = $"</{st}>";

            if (select.Contains(ovTwhat) && select.Contains(fnLwhat)) // 정직하게 있는거 빼러온 놈
            {
                open = open.Replace(ovTwhat, "");
                close = close.Replace(fnLwhat, "");
            }
            else // 아무것도 없다
            {
                if (you.IsIt(st)) // 근범위 내에 받았음에도 또 받으려 오는 간악한 스슝좍이 있을거다
                {
                    open = open.Replace(ovTwhat, ""); // 뻬버려(지금 작동 안됨)
                    close = close.Replace(fnLwhat, "");
                }
                else // 아니었으니 진짜 받으러 온 놈
                {
                    open += ovTwhat; // 나중에 들어오면 뒤로 정렬되기에 별도의 식 필요 없음.
                    close = fnLwhat + close; // 나중에 들어온게 안으로 들어가야하기에 
                }
            }

            // 여기가 멘탈 나간 부분입니다 이 코드는 드래그 대상이 같은 때만 상정해놓고 open이랑 close의 초기화를 안 해 놨습니다. 초기화를 해주면 되지 않냐, 할 수도 있지만...이전에 드래그했던 영역을 다시 드래그하면 그 때의 open과 close를 다시 불러와주게 하는 저장 시스템도 필요한데 유니티 기능으론 진짜 물리적으로 불가능합니다. 유니티로 메모장을 만드려 했던 것은, 완전히 실패한 발상이였습니다. 

            select = open + select + close;
            you.iF.text = you.iF.text.Replace(you.selectRange, select);
            select = null;
        }
        else // 드래그 없을 경우 그냥 쭈욱
        {

        }
    }


    public void End()
    {
        Data data = new Data();

        data.mainname = mainnamed.text;
        data.contentchild = contentchilds;
        for (int i = 0; i > contentchilds.Count; i++)
        {
            data.what[i] = content.GetChild(i).transform.Find("Text").GetComponentInChildren<TextMeshProUGUI>().text;
        }

        SceneManager.LoadScene(0);
    }
}

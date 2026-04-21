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
        if (select != null)
        {
            string what = $"<{st}>";
            Color c = gameObject.GetComponent<UnityEngine.UI.Image>().color;

            if (select.Contains(what))
            {
                c.a = 76f;

                open.Replace(what, "");
                close.Replace($"/{what}", "");
            }
            else
            {
                open += what;
                close = $"/{what}" + close;

                c.a = 105f;
            }

            select = open + select + close;
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

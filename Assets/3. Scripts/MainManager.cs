using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Purchasing.MiniJSON;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public TMP_Text mainnamed;
    public Transform content;
    public GameObject middleMemo;
    public GameObject world;

    public List<int> contentchilds;
    public List<string> whats;

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
        Instantiate(world, content);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnMiddle() //목차 삽입
    {
        if (content.transform.childCount == 1)
        {
            Destroy(content.GetChild(0));

            Instantiate(middleMemo, content);
            contentchilds.Add(0);
            Instantiate(world, content);
            contentchilds.Add(1);
        }
        else
        {
            Instantiate(middleMemo, content);
            contentchilds.Add(0);
            Instantiate(world, content);
            contentchilds.Add(1);
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
    }
}

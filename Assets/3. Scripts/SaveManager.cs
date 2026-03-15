using TMPro;
using UnityEngine;
using static MainManager;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using Unity.VisualScripting;

public class SaveManager : MonoBehaviour
{
    public static string path;
    public static string[] files = Directory.GetFiles(Application.persistentDataPath);  // 추천 경로의 모든 파일 이름 가져오기
    public static bool isit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static class savemanager
    {
        /*
        public static void Save<T>(T data, string filename) // T는 재너릭이라는 것으로, 형식을 나중에 지정하겠다는 의미. 즉, 아무거나 다 수용 가능.
        {
            path = Application.persistentDataPath + filename; // filename 이름의 파일을 unity 추천 저장 경로에 생성.

            saveholder.json = JsonUtility.ToJson(data); // 저장할 값을 json 형식으로 변환
            File.WriteAllText(path, saveholder.json); // 저장 경로로 json 형식의 저장값을 저장.
        */
        public static void Save(Data data, string filename) // 어차피 전송할 값은 Data형식 뿐이니 제너릭 안씀
        {
            path = Application.persistentDataPath + filename; 

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json); 
            
        }
        /*
        public static T Load<T>() // T를 쓰면 함수 호출 시 <>로 지정을 해야함. 이 코드에선 반환값이 <>안에 들어간 형식.
        {
            string json = File.ReadAllText(path); // 저장 경로를 읽고 json이라는 변수에 저장.
            return JsonUtility.FromJson<T>(json); // Load를 호출한 경로로 json을 보낸다.
        }
        */
        public static Data Load(string filename) 
        {
            isit = false;

            for(int i=0;files.Length < i;i++)
            {
                if(Path.GetFileName(files[i]) == filename)
                {
                    isit = true;
                    break;
                }
            }

            if(isit == true)
            {
                string json = File.ReadAllText(filename);
                return JsonUtility.FromJson<Data>(json);
            }
            else
            {
                return null;
            }
        }
    }
}

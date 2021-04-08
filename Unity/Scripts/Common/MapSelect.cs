using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelect : MonoBehaviour
{
    public List<string> mapList;
    public int cnt = 0;
    public int curCnt = 1;
    public int distanceRay = 100;
    private RaycastHit hit;
    public GameObject initialPlayer;
    public GameObject initialCamera;

    public static bool isStartedFadeOut = false;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(initialPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartedFadeOut)
        {
            isStartedFadeOut = false;
            initialCamera.SetActive(false);
            LoadingSceneManager.LoadScene(mapList[0]);
        }
    }

    public void SelectMap()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out hit, distanceRay))
        {
            if (cnt == 1)
            {
                if (mapList[0] != hit.transform.tag)
                {
                    mapList.Add(hit.transform.tag);
                    cnt += 1;
                }
                else
                {
                    mapList.RemoveAt(0);
                    cnt -= 1;
                    Debug.Log(mapList);
                }
            }
            else
            {
                mapList.Add(hit.transform.tag);
                Debug.Log(mapList);
                cnt += 1;
            }
        }

        //mapList.Add()
        if (cnt == 2)
        {
            FadeOutScene.GoFadeOut2();
            // FadeOutScene.GoFadeOut(mapList[0]);
            // initialCamera.SetActive(false);
            // LoadingSceneManager.LoadScene(mapList[0]);

            // DontDestroyOnLoad(initialPlayer);
        }
    }

    public static void StartedFadeOut()
    {
        isStartedFadeOut = true;
    }
}

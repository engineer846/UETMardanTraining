using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Text LoadingPCT;
    public Slider LoadingBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadYourAsyncScene());
    }
    IEnumerator LoadYourAsyncScene()    //coroutine
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            LoadingPCT.text = (asyncLoad.progress * 100) + " %";
            LoadingBar.value = asyncLoad.progress;
            if(asyncLoad.progress >= 0.9f)
            {
                LoadingPCT.text =  "100 %";
                LoadingBar.value = 1;

                yield return new WaitForSeconds(5);
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}

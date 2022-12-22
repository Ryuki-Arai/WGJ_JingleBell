using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    [SerializeField, Header("タイトルシーン名 数字指定時は「１」")]
    string _titleSceneName;
    [SerializeField, Header("ゲームシーン名 数字指定時は「２」")]
    string _GameSceneName;
    SceneState _sceneState;
    /// <summary>
    /// 呼ぶときにシーンステイト指定してください
    /// </summary>
    public void ChangeScene(SceneState state)
    {
        _sceneState = state;
        switch (this._sceneState)
        {
            case SceneState.Title:
                StartCoroutine(LoadScene(_titleSceneName));
                break;
            case SceneState.inGame:
                StartCoroutine(LoadScene(_GameSceneName));
                break;
        }
    }
    public IEnumerator LoadScene(string name)
    {
        Debug.Log("Start Fade");
        //フェードする画像の方のBoolがtrueにならない限りここで待ってくれる
        yield return new WaitUntil(() => Triger._fadeDone);
        Debug.Log("Fade has already done");
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);//名前被ってるからこう
    }
    public void OnButtonChangeScene(int enumNum)
    {
        ChangeScene((SceneState)enumNum);//キャスト
    }
}

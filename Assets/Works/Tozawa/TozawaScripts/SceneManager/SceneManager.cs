using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    [SerializeField, Header("�^�C�g���V�[���� �����w�莞�́u�P�v")]
    string _titleSceneName;
    [SerializeField, Header("�Q�[���V�[���� �����w�莞�́u�Q�v")]
    string _GameSceneName;
    [SerializeField, Header("���U���g�V�[���� �����w�莞�́u�R�v")]
    string _resultSceneName;
    SceneState _sceneState;
    /// <summary>
    /// �ĂԂƂ��ɃV�[���X�e�C�g�w�肵�Ă�������
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
            case SceneState.Result:
                StartCoroutine(LoadScene(_resultSceneName));
                break;
        }
    }
    public IEnumerator LoadScene(string name)
    {
        Debug.Log("Start Fade");
        //�t�F�[�h����摜�̕���Bool��true�ɂȂ�Ȃ����肱���ő҂��Ă����
        yield return new WaitUntil(() => Triger._fadeDone);
        Debug.Log("Fade has already done");
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);//���O����Ă邩�炱��
    }
    public void OnButtonChangeScene(int enumNum)
    {
        ChangeScene((SceneState)enumNum);//�L���X�g
    }
}

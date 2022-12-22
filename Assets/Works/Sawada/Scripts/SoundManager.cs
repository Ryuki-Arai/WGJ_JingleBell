using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Tooltip("ScriptableObjectを格納する変数")]
    SoundScriptable _soundDataBase = null;
    [Tooltip("現在再生しているBGM")]
    GameObject _loopingBGM = null;
    /// <summary>
    /// _soundDataBaseのプロパティ
    /// </summary>
    public SoundScriptable SoundDataBase { get => _soundDataBase; set => _soundDataBase = value; }

    /// <summary>
    /// サウンドを再生する関数
    /// </summary>
    /// <param name="type">サウンドの種類</param>
    /// <param name="soundNumber">SoundScriptableに保存されているサウンドの要素番号
    /// 呼ぶサウンドはSoundScriptableを見てほしい</param>
    public void CallSound(SoundType type,int soundNumber)
    {
        switch(type)
        {
            case SoundType.BGM:
                if(_loopingBGM)
                {
                    Destroy(_loopingBGM);
                }
                SoundPlay(_soundDataBase.Sounds.BGM,soundNumber);
                break;
            case SoundType.SE:
                SoundPlay(_soundDataBase.Sounds.SE, soundNumber);
                break;
        }
    }

    /// <summary>
    /// サウンドを流すオブジェクトを生成する関数
    /// </summary>
    /// <param name="sounds">サウンドの要素を指定した構造体</param>
    /// <param name="soundNumber">サウンドの要素番号</param>
    void SoundPlay(SoundElements[] sounds,int soundNumber)
    {
        if(soundNumber >= sounds.Length)
        {
            Debug.LogError("サウンドがありません");
            return;
        }
        //オブジェクトを生成＆初期化
        SoundElements sound = sounds[soundNumber];
        GameObject soundPlayer = Instantiate(_soundDataBase.SoundPlayer);
        AudioSource audioSource = soundPlayer.GetComponent<AudioSource>();

        audioSource.clip = sound.Clip;
        audioSource.volume = sound.Volume;
        audioSource.loop = sound.IsLoop;
        audioSource.Play();
        _loopingBGM = soundPlayer;

        //ループしない場合、指定した秒数後に削除
        if(!sound.IsLoop)
        {
            Destroy(audioSource, _soundDataBase.WaitDestorySecond);
        }
    }
}

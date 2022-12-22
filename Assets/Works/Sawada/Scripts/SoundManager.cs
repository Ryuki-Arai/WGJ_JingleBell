using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    SoundScriptable _soundDataBase = null;

    public SoundScriptable SoundDataBase { get => _soundDataBase; set => _soundDataBase = value; }

    public void CallSound(SoundType type,int soundNumber)
    {
        switch(type)
        {
            case SoundType.BGM:
                SoundPlay(_soundDataBase.Sounds.BGM,soundNumber);
                break;
            case SoundType.SE:
                SoundPlay(_soundDataBase.Sounds.SE, soundNumber);
                break;
        }
    }

    void SoundPlay(SoundElements[] sounds,int soundNumber)
    {
        if(soundNumber >= sounds.Length)
        {
            Debug.LogError("ƒTƒEƒ“ƒh‚ª‚ ‚è‚Ü‚¹‚ñ");
            return;
        }
        SoundElements sound = sounds[soundNumber];
        GameObject soundPlayer = Instantiate(_soundDataBase.SoundPlayer);
        AudioSource audioSource = soundPlayer.GetComponent<AudioSource>();

        audioSource.clip = sound.Clip;
        audioSource.volume = sound.Volume;
        audioSource.loop = sound.IsLoop;
        audioSource.Play();

        if(!sound.IsLoop)
        {
            Destroy(audioSource, _soundDataBase.WaitDestorySecond);
        }
    }
}

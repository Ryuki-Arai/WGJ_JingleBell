using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInitializer : MonoBehaviour
{
    [SerializeField,Tooltip("�T�E���h�̏�������ScriptableObject")] 
    SoundScriptable _soundScriptableObj = null;

    private void Awake()
    {
        if (Test._instance.SoundDataBase == null)
        {
            Test._instance.SoundDataBase = _soundScriptableObj;
        }
    }
}

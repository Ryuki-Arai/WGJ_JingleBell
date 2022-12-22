using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInitializer : MonoBehaviour
{
    [SerializeField,Tooltip("サウンドの情報を持つScriptableObject")] 
    SoundScriptable _soundScriptableObj = null;

    private void Awake()
    {
        if (Test._instance.SoundDataBase == null)
        {
            Test._instance.SoundDataBase = _soundScriptableObj;
        }
    }
}

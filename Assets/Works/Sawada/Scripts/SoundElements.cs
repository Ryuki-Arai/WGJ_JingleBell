using UnityEngine;

/// <summary>
/// サウンドの要素
/// </summary>
[System.Serializable]
public struct SoundElements
{
    public AudioClip Clip; //サウンドのクリップ
    public bool IsLoop; //ループするかどうか
    public float Volume; //ループする時間
}

/// <summary>
/// BGMとSEの配列
/// </summary>
[System.Serializable]
public struct SoundArray
{
    public SoundElements[] BGM; //BGMデータの配列
    public SoundElements[] SE;  //SEデータの配列
}


using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "ScriptableObjects/SoundScriptable", order = 1)]
public class SoundScriptable : ScriptableObject
{
    [SerializeField, Tooltip("サウンドを再生するオブジェクト")]
    GameObject _soundPlayer = null;
    [SerializeField, Tooltip("サウンドのデータ")]
    SoundArray _soundAllay;
    [SerializeField, Tooltip("オブジェクトの破棄時間")]
    float _waitDestorySecond = 1f;

    public GameObject SoundPlayer => _soundPlayer;
    public SoundArray Sounds => _soundAllay;
    public float WaitDestorySecond => _waitDestorySecond;
}

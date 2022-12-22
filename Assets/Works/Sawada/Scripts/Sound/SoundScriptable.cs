using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "ScriptableObjects/SoundScriptable", order = 1)]
public class SoundScriptable : ScriptableObject
{
    [SerializeField, Tooltip("�T�E���h���Đ�����I�u�W�F�N�g")]
    GameObject _soundPlayer = null;
    [SerializeField, Tooltip("�T�E���h�̃f�[�^")]
    SoundArray _soundAllay;
    [SerializeField, Tooltip("�I�u�W�F�N�g�̔j������")]
    float _waitDestorySecond = 1f;

    public GameObject SoundPlayer => _soundPlayer;
    public SoundArray Sounds => _soundAllay;
    public float WaitDestorySecond => _waitDestorySecond;
}

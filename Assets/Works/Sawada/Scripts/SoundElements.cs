using UnityEngine;

/// <summary>
/// �T�E���h�̗v�f
/// </summary>
[System.Serializable]
public struct SoundElements
{
    public AudioClip Clip; //�T�E���h�̃N���b�v
    public bool IsLoop; //���[�v���邩�ǂ���
    public float volume; //���[�v���鎞��
}

/// <summary>
/// BGM��SE�̔z��
/// </summary>
[System.Serializable]
public struct SoundArray
{
    public SoundElements[] BGM; //BGM�f�[�^�̔z��
    public SoundElements[] SE;  //SE�f�[�^�̔z��
}


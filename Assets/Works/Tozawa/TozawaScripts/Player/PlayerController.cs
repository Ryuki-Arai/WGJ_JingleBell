using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player�̈ړ��ƃA�C�e���擾���̓�����Ǘ�����R���|�[�l���g
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("�v���C���[�̏c���͒l")]
    float _h = default;
    [SerializeField, Header("�v���C���[�̈ړ����x�����p�l"), Range(1, 100)]
    float _speed;
    [SerializeField]Rigidbody2D _rb;
    Vector2 _ps;
    private void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _ps.y = _h * _speed;
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }
    /// <summary>
    /// Player�̈ړ����s���֐� FixedUpdate�œ������悤��
    /// </summary>
    void PlayerMove()
    {
        _rb.velocity = _ps.normalized;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ItemBase���������ɔ�����Action���Ă�
        if(collision.TryGetComponent<ItemBase>(out var item))
        {
            item.ItemAction();
        }
    }
}

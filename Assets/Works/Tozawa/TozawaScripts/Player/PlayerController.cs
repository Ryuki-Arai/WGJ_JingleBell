using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Playerの移動とアイテム取得時の動作を管理するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("プレイヤーの縦入力値")]
    float _h = default;
    [SerializeField, Header("プレイヤーの移動速度調整用値"), Range(1, 100)]
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
    /// Playerの移動を行う関数 FixedUpdateで動かすように
    /// </summary>
    void PlayerMove()
    {
        _rb.velocity = _ps.normalized;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ItemBase持ちだけに反応しActionを呼ぶ
        if(collision.TryGetComponent<ItemBase>(out var item))
        {
            item.ItemAction();
        }
    }
}

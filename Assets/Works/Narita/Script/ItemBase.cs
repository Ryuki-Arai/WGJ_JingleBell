using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
/// <summary>
/// アイテムが最低限持つ機能
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    [SerializeField, Tooltip("確率")]
    float _probability = 0f;
    [SerializeField, Tooltip("アイテムの種類")]
    ItemType _itemType = ItemType.None;
    public float Probability { get => _probability; }
    public ItemType ItemType { get => _itemType; }

    Rigidbody2D _rb = null;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        LateralMovement();
    }
    void LateralMovement()
    {//右に移動する
        _rb.velocity = Vector2.left;
    }
    public abstract void ItemAction();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.InstanceSM.CallSound(SoundType.SE,1);
    }
}

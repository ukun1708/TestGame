using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Item : MonoBehaviour, ICollectable
{
    [Inject] private Inventory inventory;

    [SerializeField] private ItemSO itemSO;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (itemSO != null)
            spriteRenderer.sprite = itemSO.Sprite;
    }

    public void Collect()
    {
        inventory.AddItemToCell(itemSO);
        Destroy(gameObject);
    }
}

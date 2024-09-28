using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InventoryCell : MonoBehaviour
{
    [Inject] private Inventory inventory;
    [Inject] private StatsManager statsManager;
    [Inject] private DataManager dataManager;

    [SerializeField] private Image image;
    [SerializeField] private TMP_Text quantityText;

    private bool empty = true;

    private IntReactiveProperty quantity = new();
    private ItemSO itemSO;
    private Button button;

    private void Awake() => button = GetComponent<Button>();

    private void OnEnable() => button.onClick.AddListener(() => SelectCellShow());

    public void Init()
    {
        LoadData();
        Subscribe();
    }

    private void LoadData()
    {
        for (int i = 0; i < inventory.inventoryCells.Count; i++)
        {
            if (inventory.inventoryCells[i] == this)
            {
                switch (dataManager.data.itemTypes[i])
                {
                    case ItemType.book:
                        itemSO = Resources.Load<ItemSO>("Data/book");
                        break;
                    case ItemType.hammer:
                        itemSO = Resources.Load<ItemSO>("Data/hammer");
                        break;
                    case ItemType.health:
                        itemSO = Resources.Load<ItemSO>("Data/health");
                        break;
                    case ItemType.poison:
                        itemSO = Resources.Load<ItemSO>("Data/poison");
                        break;
                    case ItemType.speed:
                        itemSO = Resources.Load<ItemSO>("Data/speed");
                        break;
                }
                quantity.Value = dataManager.data.quantityItems[i];
                break;
            }
        }
    }

    private void SafeData()
    {
        for (int i = 0; i < inventory.inventoryCells.Count; i++)
        {
            if (inventory.inventoryCells[i] == this)
            {
                if (itemSO != null)
                {
                    dataManager.data.itemTypes[i] = itemSO.Type;
                }
                
                dataManager.data.quantityItems[i] = quantity.Value;

                dataManager.SaveData();

                break;
            }
        }
    }

    private void SelectCellShow()
    {
        if (empty == false)
        {
            inventory.SelectCellShow(itemSO, UseItem, DeleteItem);
        }
    }

    private void UseItem()
    {
        statsManager.Change(itemSO);

        quantity.Value--;

        if (quantity.Value <= 0)
        {
            inventory.SelectCellHide();        
        }

        SafeData();
    }
    private void DeleteItem()
    {
        quantity.Value--;

        if (quantity.Value <= 0)
        {
            inventory.SelectCellHide();
        }

        SafeData();
    }

    private void Subscribe()
    {
        quantity.Subscribe(value =>
        {
            if (value < 1)
            {
                empty = true;
                image.enabled = false;
                quantityText.text = "";
                itemSO = null;
            }
            if (value > 0)
            {
                empty = false;
                image.enabled = true;
                image.sprite = itemSO.Sprite;
                quantityText.text = value.ToString();
            }
        });
    }

    public bool SetItem(ItemSO itemSO)
    {
        bool added = false;

        if (empty == true)
        {
            this.itemSO = itemSO;
            quantity.Value++;

            added = true;
        }
        else
        {
            if (this.itemSO.Id == itemSO.Id)
            {
                quantity.Value++;

                added = true;
            }
        }

        SafeData();

        return added;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public List<InventoryCell> inventoryCells = new();

    [SerializeField] private SelectCell selectCell;

    private void Awake() => SelectCellHide();

    private void Start()
    {
        foreach (var cell in inventoryCells)
        {
            cell.Init();
        }
    }

    public void SelectCellShow(ItemSO itemSO, UnityAction useAction, UnityAction deleteAction)
    {
        selectCell.Show(itemSO, useAction, deleteAction);
    }
    public void SelectCellHide() 
    {
        selectCell.Hide();
    }

    public void AddItemToCell(ItemSO item)
    {
        foreach (var cell in inventoryCells)
        {
            if (cell.SetItem(item))
            {
                break;
            }
        }
    }
}

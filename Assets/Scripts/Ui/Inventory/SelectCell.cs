using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectCell : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private Button buttonUse;
    [SerializeField] private Button buttonDelete;

    public void Show(ItemSO itemSO, UnityAction useAction, UnityAction deleteAction)
    {
        image.enabled = true;
        image.sprite = itemSO.Sprite;
        itemName.text = itemSO.Name;

        buttonUse.gameObject.SetActive(true);
        buttonDelete.gameObject.SetActive(true);
        buttonUse.onClick.RemoveAllListeners();
        buttonDelete.onClick.RemoveAllListeners();
        buttonUse.onClick.AddListener(useAction);
        buttonDelete.onClick.AddListener(deleteAction);
    }
    public void Hide()
    {
        image.enabled = false;
        itemName.text = "";

        buttonUse.onClick.RemoveAllListeners();
        buttonDelete.onClick.RemoveAllListeners();
        buttonUse.gameObject.SetActive(false);
        buttonDelete.gameObject.SetActive(false);
    }
}

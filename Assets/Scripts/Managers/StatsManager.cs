using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class StatsManager : MonoBehaviour
{
    [Inject] private DataManager dataManager;

    public IntReactiveProperty Health { get; private set; } = new();
    public IntReactiveProperty Power { get; private set; } = new();
    public IntReactiveProperty Stamina { get; private set; } = new();
    public IntReactiveProperty Wisdom { get; private set; } = new();

    private void Start() => LoadData();

    private void LoadData()
    {
        Health.Value = dataManager.data.health;
        Power.Value = dataManager.data.power;
        Stamina.Value = dataManager.data.stamina;
        Wisdom.Value = dataManager.data.wisdom;
    }

    private void SafeData()
    {
        dataManager.data.health = Health.Value;
        dataManager.data.power = Power.Value;
        dataManager.data.stamina = Stamina.Value;
        dataManager.data.wisdom = Wisdom.Value;

        dataManager.SaveData();
    }

    public void Change(ItemSO itemSO)
    {
        switch (itemSO.Type)
        {
            case ItemType.book:
                AddWisdom(itemSO.StatChangeValue);
                break;
            case ItemType.hammer:
                AddPower(itemSO.StatChangeValue);
                break;
            case ItemType.health:
                AddHealth(itemSO.StatChangeValue);
                break;
            case ItemType.poison:
                SpendHealth(itemSO.StatChangeValue);
                break;
            case ItemType.speed:
                AddStamina(itemSO.StatChangeValue);
                break;
        }

        SafeData();
    }

    private void AddHealth(int value) => Health.Value += value;
    private void SpendHealth(int value)
    {
        Health.Value -= value;

        if (Health.Value < 0)
        {
            Health.Value = 0;
        }
    }

    private void AddPower(int value) => Power.Value += value;
    private void SpendPower(int value) => Power.Value -= value;
    private void AddStamina(int value) => Stamina.Value += value;
    private void SpendStamina(int value) => Stamina.Value -= value;
    private void AddWisdom(int value) => Wisdom.Value += value;
    private void SpendWisdom(int value) => Wisdom.Value -= value;
}

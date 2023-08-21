using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatController : MonoBehaviour
{
    public static PlayerStatController instance;
    public List<PlayerStatValue> moveSpeed, health, pickupRange, maxWeapons;
    public int moveSpeedLevelCount, healthLevelCount, pickupRangeLevelCount;
    public int moveSpeedLevel, healthLevel, pickupRangeLevel, maxWeaponsLevel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = moveSpeed.Count - 1; i < moveSpeedLevelCount; i++)
        {
            moveSpeed.Add(new PlayerStatValue(moveSpeed[i].cost + moveSpeed[1].cost, moveSpeed[i].value + (moveSpeed[1].value - moveSpeed[0].value)));
        }
        for (int i = health.Count - 1; i < healthLevelCount; i++)
        {
            health.Add(new PlayerStatValue(health[i].cost + health[1].cost, health[i].value + (health[1].value - health[0].value)));
        }
        for (int i = pickupRange.Count - 1; i < pickupRangeLevelCount; i++)
        {
            pickupRange.Add(new PlayerStatValue(pickupRange[i].cost + pickupRange[1].cost, pickupRange[i].value + (pickupRange[1].value - pickupRange[0].value)));
        }
    }

    private void Update()
    {
        if (UIController.Instance.levelUpPanel.activeSelf)
        {
            UpdateDisplay();
        }
    }

    public void UpdateDisplay()
    {
        if (moveSpeedLevel < moveSpeed.Count - 1)
        {
            UIController.Instance.moveSpeedUpgradeDisplay.UpdateDisplay(moveSpeed[moveSpeedLevel + 1].cost, moveSpeed[moveSpeedLevel].value, moveSpeed[moveSpeedLevel + 1].value);
        } else
        {
            UIController.Instance.moveSpeedUpgradeDisplay.ShowMaxLevel();
        }
        if (healthLevel < health.Count - 1)
        {
            UIController.Instance.healthUpgradeDisplay.UpdateDisplay(health[healthLevel + 1].cost, health[healthLevel].value, health[healthLevel + 1].value);
        }
        else
        {
            UIController.Instance.healthUpgradeDisplay.ShowMaxLevel();
        }
        if (pickupRangeLevel < pickupRange.Count - 1)
        {
            UIController.Instance.pickupRangeUpgradeDisplay.UpdateDisplay(pickupRange[pickupRangeLevel + 1].cost, pickupRange[pickupRangeLevel].value, pickupRange[pickupRangeLevel + 1].value);
        }
        else
        {
            UIController.Instance.pickupRangeUpgradeDisplay.ShowMaxLevel();
        }
        if (maxWeaponsLevel < maxWeapons.Count - 1)
        {
            UIController.Instance.maxWeaponsUpgradeDisplay.UpdateDisplay(maxWeapons[maxWeaponsLevel + 1].cost, maxWeapons[maxWeaponsLevel].value, maxWeapons[maxWeaponsLevel + 1].value);
        }
        else
        {
            UIController.Instance.maxWeaponsUpgradeDisplay.ShowMaxLevel();
        }
    }

    public void PurchaseMoveSpeed()
    {
        moveSpeedLevel++;
        CoinController.instance.SpendCoins(moveSpeed[moveSpeedLevel].cost);
        UpdateDisplay();

        PlayerController.Instance.moveSpeed = moveSpeed[moveSpeedLevel].value;
    }

    public void PurchaseHealth()
    {
        healthLevel++;
        CoinController.instance.SpendCoins(health[healthLevel].cost);
        UpdateDisplay();

        PlayerHealthController.Instance.maxHealth = health[healthLevel].value;
        PlayerHealthController.Instance.currentHealth += health[healthLevel].value - health[healthLevel - 1].value;
    }

    public void PurchasePickupRange()
    {
        pickupRangeLevel++;
        CoinController.instance.SpendCoins(pickupRange[pickupRangeLevel].cost);
        UpdateDisplay();

        PlayerController.Instance.pickupRange = pickupRange[pickupRangeLevel].value;
    }

    public void PurchaseMaxWeapons()
    {
        maxWeaponsLevel++;
        CoinController.instance.SpendCoins(maxWeapons[maxWeaponsLevel].cost);
        UpdateDisplay();

        PlayerController.Instance.maxWeapons = Mathf.RoundToInt(maxWeapons[maxWeaponsLevel].value);
    }
}

[Serializable]
public class PlayerStatValue
{
    public int cost;
    public float value;

    public PlayerStatValue(int newCost, float newValue)
    {
        cost = newCost;
        value = newValue;
    }
}

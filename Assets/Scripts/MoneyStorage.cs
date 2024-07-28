using System;
using UnityEngine;

public sealed class MoneyStorage : IService
{
    public event Action<int> OnMoneyChanged;
    public event Action<int> OnMoneyEarned;
    public event Action<int> OnMoneySpent;

    public int Money
    {
        get { return this.money; }
    }

    private int money;

    public void EarnMoney(int amount)
    {
        if (amount == 0)
        {
            return;
        }

        if (amount < 0)
        {
            throw new Exception($"Can not earn negative money {amount}");
        }

        var previousValue = this.money;
        var newValue = previousValue + amount;

        this.money = newValue;
        this.OnMoneyChanged?.Invoke(newValue);
        this.OnMoneyEarned?.Invoke(amount);
    }

    public void SpendMoney(int amount)
    {
        if (amount == 0)
        {
            return;
        }

        if (amount < 0)
        {
            throw new Exception($"Can not spend negative money {amount}");
        }

        var previousValue = this.money;
        var newValue = previousValue - amount;
        if (newValue < 0)
        {
            throw new Exception(
                $"Negative money after spend. Money in bank: {previousValue}, spend amount {amount} ");
        }

        this.money = newValue;
        this.OnMoneyChanged?.Invoke(newValue);
        this.OnMoneySpent?.Invoke(amount);
    }

    public void SetupMoney(int money)
    {
        this.money = money;
        this.OnMoneyChanged?.Invoke(money);
    }

    public bool CanSpendMoney(int amount)
    {
        return this.money >= amount;
    }
}
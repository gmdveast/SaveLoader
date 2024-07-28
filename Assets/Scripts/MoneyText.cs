using TMPro;
using UnityEngine;
using VContainer;

public class MoneyText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    private MoneyStorage moneyStorage;

    [Inject]
    private void Construct(MoneyStorage moneyStorage)
    {
        this.moneyStorage = moneyStorage;
        this.moneyStorage.OnMoneyChanged += MoneyStorage_OnMoneyChanged;
        
        moneyText.text = $"Money: {moneyStorage.Money}";
    }

    private void MoneyStorage_OnMoneyChanged(int money)
    {
        moneyText.text = $"Money: {money}";
    }

    private void OnDestroy()
    {
        moneyStorage.OnMoneyChanged -= MoneyStorage_OnMoneyChanged;
    }
}
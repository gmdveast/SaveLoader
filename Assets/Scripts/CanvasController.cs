using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Button earnMoney;
    [SerializeField] private Button spendMoney;

    private MoneyStorage moneyStorage;

    [Inject]
    private void Construct(MoneyStorage moneyStorage)
    {
        this.moneyStorage = moneyStorage;
    }

    private void Start()
    {
        earnMoney.onClick.AddListener(() => { moneyStorage.EarnMoney(10); });
        spendMoney.onClick.AddListener(() => { moneyStorage.SpendMoney(10); });
    }
}
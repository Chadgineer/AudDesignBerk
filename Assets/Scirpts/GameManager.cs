using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float unCollectedMoney;
    public float money;
    public TextMeshPro unCollectedMoneyText;
    public TextMeshProUGUI moneyText;

    private void Awake()
    {
        RefreshMoneyText();
        RefreshUncollectedMoneyText();  
    }
    public void CollectMoney()
    {
        AddMoney(unCollectedMoney);
        unCollectedMoney = 0;
        RefreshUncollectedMoneyText();
    }
    public void AddUncollectedMoney(float amount)
    {
        unCollectedMoney += amount;
        RefreshUncollectedMoneyText();
    }

    public void AddMoney(float amount)
    {
        money += amount;
        RefreshMoneyText();
    }

    public void SpendMoney(float amount) 
    {
        if (money - amount >= 0)
        {
            money -= amount;
        }
        else         
        {
            Debug.Log("Yetersiz bakiye!");
        }
    }

    public void RefreshUncollectedMoneyText()
    {
        unCollectedMoneyText.text = unCollectedMoney.ToString() + " $" ;
    }

    public void RefreshMoneyText()
    {
        moneyText.text = "Money: "+ money.ToString() + " $";
    }
}

using TMPro;
using UnityEngine;

public class BudgetManager : MonoBehaviour
{
    public static BudgetManager instance;
    [SerializeField] private int moneyBalance = 1000;
    [SerializeField] private TextMeshProUGUI moneyBalanceGUI;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void BuyItem(Item item)
    {
        if(moneyBalance - (int)item.value >= 0) //If moneyBalance would still be positive, then substract it
        {
            moneyBalance -= (int)item.value; //Might allow floats?
        }
        else //If not then subtract but end the game
        {
            moneyBalance -= (int)item.value;

            Debug.Log("Player overdrafted account!");
        }
        OnBalanceChanged();

        AccountItemInBudget(item);
    }
    void AccountItemInBudget(Item item)
    {
        
    }

    void OnBalanceChanged()
    {
        moneyBalanceGUI.text = "$" + moneyBalance.ToString();
        
        if(moneyBalance < 0)
        {
            moneyBalanceGUI.color = Color.red;
        }
        else
        {
            moneyBalanceGUI.color = Color.white;
        }
    }
}

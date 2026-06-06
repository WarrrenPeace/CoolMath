using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BudgetManager : MonoBehaviour
{
    public static BudgetManager instance;
    [SerializeField] private int moneyBalance = 1000;
    [SerializeField] private TextMeshProUGUI moneyBalanceGUI;

    [SerializeField,Header("Catagories")] Catagory FoodCat;
    [SerializeField] Catagory UtilitiesCat;
    [SerializeField] Catagory FunCat;
    [SerializeField] Catagory ClothingCat;
    [SerializeField] Catagory TravelCat;
    [SerializeField] Catagory MembershipCat;
    [SerializeField] Catagory PetsCat;
    [SerializeField] Catagory MiscCat;

    

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
    void Start()
    {
        FoodCat.Setup(100);
        UtilitiesCat.Setup(100);
        FunCat.Setup(100);
        ClothingCat.Setup(100);
        TravelCat.Setup(100);
        MembershipCat.Setup(100);
        PetsCat.Setup(100);
        MiscCat.Setup(100);
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
        switch (item.catagory)
        {
            case Item.Catagory.Food:
            FoodCat.amount += (int)item.value;
            FoodCat.UpdateProgress();
            break;

            case Item.Catagory.Utilities:
            UtilitiesCat.amount += (int)item.value;
            UtilitiesCat.UpdateProgress();
            break;

            case Item.Catagory.Fun:
            FunCat.amount += (int)item.value;
            FunCat.UpdateProgress();
            break;

            case Item.Catagory.Clothing:
            ClothingCat.amount += (int)item.value;
            ClothingCat.UpdateProgress();
            break;

            case Item.Catagory.Travel:
            TravelCat.amount += (int)item.value;
            TravelCat.UpdateProgress();
            break;

            case Item.Catagory.Memberships:
            MembershipCat.amount += (int)item.value;
            MembershipCat.UpdateProgress();
            break;

            case Item.Catagory.Pets:
            PetsCat.amount += (int)item.value;
            PetsCat.UpdateProgress();
            break;

            case Item.Catagory.Misc:
            MiscCat.amount += (int)item.value;
            MiscCat.UpdateProgress();
            break;
        }
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

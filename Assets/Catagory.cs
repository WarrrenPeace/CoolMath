using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Catagory : MonoBehaviour
{
    public int amount, amountMIN, amountMAX;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI budgetAmount;
    [SerializeField] private Slider progressbar;
    private Animator AM;

    void Start()
    {
        AM = GetComponent<Animator>();
        title.text = name;
    }
    public void Setup(int maxValue)
    {
        Debug.Log("Setup "+ name);
        progressbar.maxValue = maxValue;
        amountMAX = maxValue;
        amountMIN = CreateBudgetThreshold();
        budgetAmount.text = "$" + 0 + "/" + "$" + amountMAX;
    }
    int CreateBudgetThreshold()
    {
        return Mathf.RoundToInt(amountMAX * 0.7f);
    }
    public void UpdateProgress()
    {
        budgetAmount.text = "$" + amount + "/" + "$" + amountMAX;
        progressbar.value = amount;

        if(amount >= amountMAX)
        {
            BudgetManager.instance.OnBudgetSurpassed();
            Debug.Log(name + " Budget has been reached!");
            //budgetAmount.color = Color.red;
            progressbar.fillRect.GetComponent<Image>().color = Color.darkRed;
        }
        AM.SetTrigger("Stretch");
    }
}

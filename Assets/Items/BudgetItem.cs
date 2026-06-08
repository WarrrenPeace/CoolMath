using UnityEngine;

public class BudgetItem : MonoBehaviour
{
    Rigidbody2D RB;
    Animator AM;
    public Item itemObject;
    [SerializeField] private CatagoryColor colors;
    public float startForce = 1;
    [SerializeField] private Vector3 attractor;

    private bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AM = GetComponent<Animator>();

        if(itemObject)
        {
            GetComponent<SpriteRenderer>().sprite = itemObject.sprite;
            PickColorOfOutline();
        }

        PushToWallet();

        Physics2D.callbacksOnDisable = false;
    }
    void PickColorOfOutline()
    {
        switch (itemObject.catagory)
        {
            case Item.Catagory.Food:
            GetComponent<SpriteRenderer>().material.SetColor("_OutlineColor",colors.Catagory_Food_Outline);
            GetComponent<TrailRenderer>().startColor = colors.Catagory_Food_Outline;
            break;

            case Item.Catagory.Utilities:
            GetComponent<SpriteRenderer>().material.SetColor("_OutlineColor",colors.Catagory_Utilities_Outline);
            GetComponent<TrailRenderer>().startColor = colors.Catagory_Utilities_Outline;
            break;

            case Item.Catagory.Fun:
            GetComponent<SpriteRenderer>().material.SetColor("_OutlineColor",colors.Catagory_Fun_Outline);
            GetComponent<TrailRenderer>().startColor = colors.Catagory_Fun_Outline;
            break;

            case Item.Catagory.Clothing:
            GetComponent<SpriteRenderer>().material.SetColor("_OutlineColor",colors.Catagory_Clothing_Outline);
            GetComponent<TrailRenderer>().startColor = colors.Catagory_Clothing_Outline;
            break;

            case Item.Catagory.Travel:
            GetComponent<SpriteRenderer>().material.SetColor("_OutlineColor",colors.Catagory_Travel_Outline);
            GetComponent<TrailRenderer>().startColor = colors.Catagory_Travel_Outline;
            break;

            case Item.Catagory.Memberships:
            GetComponent<SpriteRenderer>().material.SetColor("_OutlineColor",colors.Catagory_Memberships_Outline);
            GetComponent<TrailRenderer>().startColor = colors.Catagory_Memberships_Outline;
            break;

            case Item.Catagory.Pets:
            GetComponent<SpriteRenderer>().material.SetColor("_OutlineColor",colors.Catagory_Pets_Outline);
            GetComponent<TrailRenderer>().startColor = colors.Catagory_Pets_Outline;
            break;

            case Item.Catagory.Misc:
            GetComponent<SpriteRenderer>().material.SetColor("_OutlineColor",colors.Catagory_Misc_Outline);
            GetComponent<TrailRenderer>().startColor = colors.Catagory_Misc_Outline;
            break;
        }
    }
    void PushToWallet()
    {
        RB.AddForce(attractor - transform.position * startForce,ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wallet" && !isDead)
        {
            isDead = true;
            //Remove money from wallet, add to budget
            BudgetManager.instance.BuyItem(itemObject);

            //Animate
            GetComponent<CircleCollider2D>().enabled = false;
            AM.SetTrigger("Bought");

            //Destroy
            Destroy(gameObject,0.5f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "KillZone")
        {
            BudgetManager.instance.ItemDiscarded();
            Debug.Log("Discarded by player");
            Destroy(gameObject);
        }
    }
}

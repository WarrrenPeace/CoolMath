using UnityEngine;

public class BudgetItem : MonoBehaviour
{
    Rigidbody2D RB;
    public Item itemObject;
    public float startForce = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();

        if(itemObject) {GetComponent<SpriteRenderer>().sprite = itemObject.sprite;}

        PushToWallet();
    }
    void PushToWallet()
    {
        RB.AddForce(Vector3.zero - transform.position * startForce,ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wallet")
        {
            //Add Item to budget

            //Remove money from wallet

            //Destroy
            Destroy(gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "KillZone")
        {
            Debug.Log("Discarded by player");
            Destroy(gameObject);
        }
    }
}

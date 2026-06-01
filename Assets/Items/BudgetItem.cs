using UnityEngine;

public class BudgetItem : MonoBehaviour
{
    Rigidbody2D RB;
    public Item itemObject;
    public float startForce = 1;
    [SerializeField] float dragSpeed = 1f;
    private Vector2 target;
    public bool dragging = false;
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

    public void DragObject(Vector2 pos)
    {
        dragging = true;
        target = pos;
    }
    void FixedUpdate()
    {
        if(dragging)
        {
            Vector2 direction = (target - RB.position).normalized;
            RB.MovePosition(RB.position + direction * dragSpeed * Time.fixedDeltaTime);
            dragging = false;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if(other.tag == "Wallet")
        {
            //Add Item to budget

            //Remove money from wallet

            //Destroy
            Destroy(gameObject);
        }
    }
}

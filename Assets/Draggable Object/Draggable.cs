using UnityEngine;

public class Draggable : MonoBehaviour
{
    Rigidbody2D RB;
    [SerializeField] float dragSpeed = 1f;
    private Vector2 target;
    public bool dragging = false;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }
    public void DragObject(Vector2 pos)
    {
        dragging = true;
        target = pos;
    }
    void FixedUpdate()
    {
        //if(dragging)
        //{
        //    Vector2 direction = (target - RB.position).normalized;
        //    RB.MovePosition(RB.position + direction * dragSpeed * Time.fixedDeltaTime);
        //    dragging = false;
        //}
        
    }
}

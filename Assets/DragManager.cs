using UnityEngine;
using UnityEngine.InputSystem;

public class DragManager : MonoBehaviour
{
    private Transform dragging = null;
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);

            if(hit)
            {
                if(hit.transform.tag == "Draggable")
                {
                    dragging = hit.transform;
                }
                
            }
        }
        else if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            dragging = null;
        }


        if(dragging != null)
        {
            dragging.gameObject.GetComponent<BudgetItem>().DragObject(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        }
    }
}

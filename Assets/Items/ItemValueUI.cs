using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemValueUI : MonoBehaviour
{
    private Transform target;
    [SerializeField] private TextMeshProUGUI text;

    public void SetUpUIObject(Transform parent, float value)
    {
        target = parent;
        text.text = "$"+value.ToString();
    }
    void Update()
    {
        if(target)
        {
            transform.position = target.position;
        }
        else
        {Destroy(gameObject);}
    }
}

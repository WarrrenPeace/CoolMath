using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public enum Catagory
    {
        Food, //Food sprites
        Utilities, //Water, electric, gas, car,
        Fun, //
        Clothing,
        Travel,
        Memberships,
        Pets,
        Misc

    }
    public Catagory catagory;
    public float value; //How much item is worth
    [SerializeField] public Sprite sprite;
    
}

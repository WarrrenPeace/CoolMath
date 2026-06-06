using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public enum Catagory
    {
        Food, //Food
        Utilities, //Water, electric, gas, car,
        Fun, //
        Clothing, //all kinds of clothes
        Travel, //Filling Gas, Insurance
        Memberships, //subscriptions, gym membership
        Pets, 
        Misc

    }
    public Catagory catagory;
    public float value; //How much item is worth
    [SerializeField] public Sprite sprite;
    
}

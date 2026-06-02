using Unity.Mathematics;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject itemValueUIPrefab;
    [SerializeField] Transform worldCanvas;
    [SerializeField] private float spawnDelay = 0.5f;
    [SerializeField] private float spawnFrequency = 0.5f;
    [SerializeField] private float spawnRadius;
    [SerializeField] private bool canSpawnItem;
    [SerializeField] float minForce = 0.1f, MaxForce = 0.25f;
    [SerializeField] Item[] Foods;
    [SerializeField] Item[] Utilities;
    [SerializeField] Item[] Fun;
    [SerializeField] Item[] Clothing;
    [SerializeField] Item[] Travel;
    [SerializeField] Item[] Memberships;
    [SerializeField] Item[] Pets;
    [SerializeField] Item[] Misc;

    


    void Start()
    {
        StartSpawnSequence();
    }
    void StartSpawnSequence()
    {
        InvokeRepeating("SpawnItem",spawnDelay,spawnFrequency);
    }

    void SpawnItem()
    {
        CreateItemToLaunchAtPlayer(PickItem(PickCatagory()));
    }

    Item[] PickCatagory() //Returns a list
    {
        int whichList = UnityEngine.Random.Range(0,8);
        if(whichList == 0)
        {
            if(Foods.Length > 0) return Foods;
        }
        else if (whichList == 1)
        {
            if(Foods.Length > 0) return Utilities;
        }
        else if (whichList == 2)
        {
            if(Foods.Length > 0) return Fun;
        }
        else if (whichList == 3)
        {
            if(Foods.Length > 0) return Clothing;
        }
        else if (whichList == 4)
        {
            if(Foods.Length > 0) return Travel;
        }
        else if (whichList == 5)
        {
            if(Foods.Length > 0) return Memberships;
        }
        else if (whichList == 6)
        {
            if(Foods.Length > 0) return Pets;
        }
        else if (whichList == 7)
        {
            if(Foods.Length > 0) return Misc;
        }

        return null;
    }
    Item PickItem(Item[] catagory) //Pick item
    {
        if(catagory.Length > 0)
        {
            return catagory[UnityEngine.Random.Range(0, catagory.Length)];
        }
        else return null;
        
    }

    void CreateItemToLaunchAtPlayer(Item item)
    {
        if(item != null)
        {
            BudgetItem spawnedBudgetItem = Instantiate(itemPrefab,GetRandomPointAroundScreen(spawnRadius),quaternion.identity).GetComponent<BudgetItem>();
            spawnedBudgetItem.itemObject = item;
            spawnedBudgetItem.startForce = UnityEngine.Random.Range(minForce, MaxForce);

            ItemValueUI itemvalueUI = Instantiate(itemValueUIPrefab,spawnedBudgetItem.transform.position, quaternion.identity,worldCanvas).GetComponent<ItemValueUI>();
            itemvalueUI.SetUpUIObject(spawnedBudgetItem.transform,spawnedBudgetItem.itemObject.value);
        }
        else
        {
            return;
        }
        
    }
    Vector2 GetRandomPointAroundScreen(float radius)
    {
        float angle = UnityEngine.Random.Range(0, Mathf.PI * 2);
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
    }
}

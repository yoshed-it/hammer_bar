using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarPatrons : MonoBehaviour
{

    public bool drunk;
    public GameObject customerPrefab;
    public GameObject[] randomPrefab;
    private int customerCount = 0;
    private int barCapacity = 4;
    public GameObject[] currentCustomers;
    

    
    // Start is called before the first frame update
    void Start()
    {
        if (customerCount < barCapacity)
        {
            InvokeRepeating("SpawnRandomNPCS", 2f, 5f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (customerCount >= barCapacity)
        {
            CancelInvoke();
        }
        
    }
    
   public void SpawnRandomNPCS()
   {
       
       customerPrefab = randomPrefab[UnityEngine.Random.Range(0, 3)];
       Instantiate(customerPrefab, new Vector2(-3, -4), Quaternion.identity);
       customerCount++;
   }
}

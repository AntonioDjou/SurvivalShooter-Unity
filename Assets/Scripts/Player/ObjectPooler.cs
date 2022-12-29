using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler current;
    public GameObject pooledObject;
    public int pooledAmount;
   // public bool willGrow;
    private List<GameObject> pooledObjects;
    
    void Awake()
    {
        current = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();// Instantiate the list of GameObjects
       
        for(int i = 0; i < pooledAmount; i++) // Loops through the whole lenght of the object's amount
        {
            GameObject obj = Instantiate(pooledObject); // Instantiate the desired object
            obj.SetActive(false); // Disable it
            pooledObjects.Add(obj); // Add the specified amount of objects
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i=0 ; i < pooledObjects.Count; i++) // Search in al the amount of pooled objects
        {
            if(!pooledObjects[i].activeInHierarchy) //  To find an object that is not active and return it 
            {
                return pooledObjects[i]; // Returns that object from the list' index
            }
        }
        
        return null;
    }
}

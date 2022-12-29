using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLoot : MonoBehaviour
{
    public List<GameObject> Drops;
    public int [] table = { 70, 30 }; // +Time + Health
    public int total;
    public int randomNumber;
    void Start()
    {
        foreach(var item in table)
        {
            total += item;
        }
        
        randomNumber = Random.Range(0,total);
        
        for(int i = 0; i < table.Length; i++)
        {
            if(randomNumber <= table[i])
            {
                Drops[i].SetActive(true);
                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }
    }
}

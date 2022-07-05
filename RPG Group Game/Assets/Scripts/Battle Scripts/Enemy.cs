using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string name;

    public int currentHP;
    public int maxHP;

    public void reduceHP(int amount)
    {
        int result = (currentHP - amount);
        if(result < 0)
        {
            result = 0;
        }
        currentHP = result;
    }
    public void increaseHP(int amount)
    {
        int result = (currentHP + amount);
        if(result > maxHP)
        {
            result = maxHP;
        }
        currentHP = result;
    }
}

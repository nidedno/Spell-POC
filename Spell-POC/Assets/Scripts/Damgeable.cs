using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damgeable : MonoBehaviour
{
    public virtual void GetDamage(int damage)
    {
        Debug.Log("Abstract damage");
    }
}

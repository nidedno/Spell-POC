using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitFinder
{
    public static float pointRadius = 3f;

    //Find units at point

    public static Unit FindAtPoint(Vector3 point)
    {
        Collider[] hitColliders = Physics.OverlapSphere(point, pointRadius);

        if(hitColliders.Length != 0){
            
            foreach (var item in hitColliders)
            {
                var unit = item.GetComponent<Unit>();
                if(unit != null)
                {
                    return unit;
                }
            }
        }

        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class SelfSpellLogic : MonoBehaviour, ISpellLogic
{
    private Cast logicOwner;
    public void SetOwner(Cast owner)
    {
        logicOwner = owner;
    }
    public async void ApplyLogic(Vector3 startPoint, Vector3 Direction)
    {
        GameObject stream = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        stream.transform.position = startPoint;


        await Task.Delay(5000);

        Destroy(stream);

    }

}

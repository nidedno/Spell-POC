using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SelfLogic : SpellLogic
{


    public override async Task ActivateLogic()
    {
        //base.ActivateLogic();
        print("self logic 1");
        await Task.Delay(3000);

        print("self logic 2");
    }

    public override Vector3 GetCastPosition()
    {
        throw new System.NotImplementedException();
    }


}

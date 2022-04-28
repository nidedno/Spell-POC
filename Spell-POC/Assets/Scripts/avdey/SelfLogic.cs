using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SelfLogic : SpellLogic
{

    

    public override async Task ActivateLogic()
    {
        //base.ActivateLogic();

        print("StartSelfLogic");
        
        await Task.Delay(3000);
        //
        /*
            var spellOwner = _logicOwner.mainSpell.caster;
            _logicOwner._spellActions;
        */
       // _logicOwner.Owner.caster;
        print("EndSelfLogic");
    }

    public override Vector3 GetCastPosition()
    {
        return _castObject.transform.position;
    }

    public override Vector3 GetCastDirection(){
        return Vector3.up;
    }


}

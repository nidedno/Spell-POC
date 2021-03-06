using System.Threading.Tasks;
using UnityEngine;

public abstract class SpellLogic : MonoBehaviour
{
    [SerializeField] protected Cast _logicOwner;
    [SerializeField] protected GameObject _castObject;
    [SerializeField] protected GameObject _effect;

    
    
  
    public abstract Vector3 GetCastPosition();
    public abstract Vector3 GetCastDirection();
    

   
    public virtual async Task ActivateLogic() { Debug.Log("main spell logic"); }

    public void SetOwner(Cast owner)
    {
        _logicOwner = owner;
    }
}

using System.Threading.Tasks;
using UnityEngine;

public interface ISpellLogic 
{
    public void SetOwner(Cast owner);
    public void ApplyLogic(Vector3 startPoint, Vector3 Direction);
}

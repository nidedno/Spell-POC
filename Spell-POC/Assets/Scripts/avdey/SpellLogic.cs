using System.Threading.Tasks;
using UnityEngine;

public abstract class SpellLogic : MonoBehaviour
{
    [SerializeField] protected Cast _castOwner;
    [SerializeField] protected GameObject _castObject;
    // есть идея, что нужно будет создавать некий пустой объект логики, к которому зацепляется логика и уже проводит с ним различные манипуляции

    // этот класс отвечает за как бы логику
    // логика, например на себя
    // не активирует какие-то тригеры, так как является замыкающей и скорее всего, такой тип логики будет действовать на точку


    // возвращает позицию, где в данный момент находится тело логики ( aka шар или центр зоны  и тд )
    public abstract Vector3 GetCastPosition();

    


    // асинхронно подрубаем логику, пришлось немного выебнуться, но вроде должно работать
    public virtual async Task ActivateLogic() { Debug.Log("main spell logic"); }
}

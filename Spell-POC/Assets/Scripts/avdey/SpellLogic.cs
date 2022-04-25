using System.Threading.Tasks;
using UnityEngine;

public abstract class SpellLogic : MonoBehaviour
{
    [SerializeField] protected Cast _castOwner;
    [SerializeField] protected GameObject _castObject;
    // ���� ����, ��� ����� ����� ��������� ����� ������ ������ ������, � �������� ����������� ������ � ��� �������� � ��� ��������� �����������

    // ���� ����� �������� �� ��� �� ������
    // ������, �������� �� ����
    // �� ���������� �����-�� �������, ��� ��� �������� ���������� � ������ �����, ����� ��� ������ ����� ����������� �� �����


    // ���������� �������, ��� � ������ ������ ��������� ���� ������ ( aka ��� ��� ����� ����  � �� )
    public abstract Vector3 GetCastPosition();

    


    // ���������� ��������� ������, �������� ������� ����������, �� ����� ������ ��������
    public virtual async Task ActivateLogic() { Debug.Log("main spell logic"); }
}

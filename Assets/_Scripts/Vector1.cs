using CustomInspector;
using Unity.VisualScripting;
using UnityEngine;

public class Vector1 : MonoBehaviour
{
    float Force;
    public Vector3 Va = new Vector3(0.0f, 0.0f, 0.0f);
    public Vector3 Vb = new Vector3(0.0f, 0.0f, 0.0f);
    public Vector3 Vc = new Vector3(0.0f, 0.0f, 0.0f);
    [ReadOnly(disableStyle = DisableStyle.OnlyText)] public Vector3 Vadd = new Vector3(0.0f, 0.0f, 0.0f);
    [ReadOnly(disableStyle = DisableStyle.OnlyText)] public Vector3 Vsub = new Vector3(0.0f, 0.0f, 0.0f);
    [ReadOnly(disableStyle = DisableStyle.OnlyText)] public Vector3 VNormalFoce = new Vector3(0.0f, 0.0f, 0.0f);
    public float magnitude;

    void OnDrawGizmos()
    {


            // Gizmos.color = Color.red;
            // Gizmos.DrawLine(Vector3.zero, Vector3.one);
            // Gizmos.DrawLine(Vector3.zero, Vector3.forward);
            // Gizmos.DrawLine(Vector3.zero, Vector3.back);
            // Gizmos.DrawLine(Vector3.zero, Vector3.up);
            // Gizmos.DrawLine(Vector3.zero, Vector3.down);
            // Gizmos.DrawLine(Vector3.zero, Vector3.right);
            // Gizmos.DrawLine(Vector3.zero, Vector3.left);
            // magnitude = (to - from).magnitude;                            // magnitude(규모) : 벡터의 힘 값

            // VectorElrment();
           VectorOperator();
     
    }

    
    [Button("VectorElrment", label = "벡터의 기본요소", size = Size.big), HideField] public bool _b1;

    void VectorElrment()
    {
        Debug.Log($"제로 : {Vector3.zero} 1 : {Vector3.one} ");
        Debug.Log($"앞 :{Vector3.forward} 뒤 : {Vector3.back}");
        Debug.Log($"위  :{Vector3.up} 아래 : {Vector3.down}");
        Debug.Log($"오른쪽 : {Vector3.right} 왼쪽 : {Vector3.left}");

        
        
            Gizmos.color = Color.white;
            Gizmos.DrawRay(Vector3.zero, Vector3.one);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(Vector3.zero, Vector3.forward);
            // Gizmos.DrawRay(Vector3.zero, Vector3.back);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(Vector3.zero, Vector3.up);
            // Gizmos.DrawRay(Vector3.zero, Vector3.down);
            Gizmos.color = Color.green;
             Gizmos.DrawRay(Vector3.zero, Vector3.right);
            // Gizmos.DrawRay(Vector3.zero, Vector3.left);

    }

    void VectorOperator()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(Vector3.zero, Va);
        Gizmos.DrawRay(Vector3.zero, Vb);
        Gizmos.DrawRay(Vector3.zero, Vc);
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(Vector3.zero, Vadd);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(Vector3.zero, Vsub);
        
        Vadd = Va + Vb + Vc;
        Vsub = Va - Vb - Vc;
    }

    void VectorNormalize()
    {
        VNormalFoce=Vadd.normalized;                                  // 벡터를 -1~1사이의 방향성만 가져온다.
     
         Gizmos.color = Color.black;
        Gizmos.DrawRay(Vector3.zero,VNormalFoce);

    }
}

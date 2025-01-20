using CustomInspector;
using Unity.VisualScripting;
using UnityEngine;

public class RAndomSpawnGenerator : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform propRoot;


    void OnDrawGizmos() // 에디터에서 기즈모를 그릴 수 있는 공간
    {
        Vector3 temp = new Vector3(transform.position.x, y, transform.position.z);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(temp, Radius);

        Gizmos.DrawWireCube(temp,Vector3.one*Radius);

    }


    [Space(20), HorizontalLine("스포너", color: FixedColor.Orange), HideField] public bool _l1;
    [Button("Spawn",size = Size.big), HideField] public bool _b0;
    [SerializeField] float Radius;
    [SerializeField] float y;
    [SerializeField] int number;
    [SerializeField] [AsRange(0.5f,2f)] Vector2 scaleRange;
    float angle;
    public void Spawn()
    {
        // Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);

        for (int a = 0; a < number; a++)
        {
        float scale = Random.Range(scaleRange.x,scaleRange.y);                                            // 스케일 랜덤 돌리기
        angle = Random.Range(0f,360.0f);
        GameObject clone = Instantiate(prefab);                                     // 클론 찍기(출력)
        Vector3 rndpos = Random.insideUnitSphere * Radius + transform.position;     // 포지션 반지름 곱한 x,z만 랜덤 돌리고 

        Vector3 temp = new Vector3(transform.position.x, y, transform.position.z);  // temp에 y빼고 클론의 포지션 지정
        Vector3 temp2 = new Vector3(scale, scale, scale);                           // temp2에 랜덤된 scale 입력
        Vector3 temp3 = new Vector3(0.0f, angle, 0.0f);
        rndpos.y = temp.y;                                                          // temp에 y값 넣기


        // add = Random.insideUnitSphere
            clone.transform.position = rndpos;
            clone.transform.localScale = temp2;
            clone.transform.localEulerAngles = temp3;
            clone.transform.SetParent(propRoot);
        }

    }


    [Space(20), Button("Despawn", size = Size.big), HideField] public bool _b1;
    void Despawn()

    {
        // propRoot.transform.childCount : 리스트 자료구조형
        // Destroy() : 플레이 모드일 때        
        
        foreach (Transform t in propRoot)
        {
           DestroyImmediate(t.gameObject); /*에디터 모드일 때*/
        
        }
    }


}

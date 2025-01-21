using System.Collections.Generic;
using CustomInspector;
using UnityEngine;

public class RAndomSpawnGenerator : MonoBehaviour
{
    [SerializeField][Preview] List<GameObject> prefabs;
    [SerializeField] Transform propRoot;


    void OnDrawGizmos()      // 에디터에서 기즈모를 그릴 수 있는 공간
    {
        if (deleteOn == false)
        {
            Vector3 temp = new Vector3(transform.position.x, hieght, transform.position.z);
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(temp, Radius);
        }

        // Gizmos.DrawWireCube(temp,Vector3.one*Radius);
        else
        {
            Vector3 destroied = new Vector3(transform.position.x, hieght, transform.position.z);
            Gizmos.color = Color.gray;
            Gizmos.DrawWireSphere(destroied, Radius);
        }

        // Gizmos.DrawWireCube(temp,Vector3.one*Radius);
    }

    [Space(20), HorizontalLine("스포너", color: FixedColor.Orange), HideField] public bool _l1;
    [Button("Spawn", size = Size.big), HideField] public bool _b0;
    [Title("범위 속성", fontSize = 15, alignment = TextAlignment.Center), HideField] public bool _t0;
    [SerializeField, Space(10)] float Radius;
    [SerializeField] float hieght;
    [SerializeField] LayerMask layerMask;
    [Space(20), HideField] public bool _s0;
    [Title("객체 속성", fontSize = 15, alignment = TextAlignment.Center), HideField] public bool _t1;
    [SerializeField, AsRange(1, 1000)] Vector2 number;
    [SerializeField][AsRange(0.0f, 2f)] Vector2 scaleRange;
    float angle;
    public void add()
    {
        // Instantiate(prefabs, new Vector3(x, y, z), Quaternion.identity);

        int rndindex = Random.Range(0, prefabs.Count);
        float scale = Random.Range(scaleRange.x, scaleRange.y);                           // 스케일 랜덤 돌리기
        angle = Random.Range(0f, 360.0f);                                                 // 랜덤 로테이션 찍기    

        Vector3 rndpos = Random.insideUnitSphere * Radius + transform.position;           // 포지션 반지름 곱한 x,z만 랜덤 돌리고 
        if (CheckHeight(rndpos, out Vector3 point) == true)
        {
            GameObject clone = Instantiate(prefabs[rndindex]); /*출력*/                       // 클론 찍기(출력)

            Vector3 temp = new Vector3(point.x, point.y, point.z);   // temp에 y빼고 클론의 포지션 지정
            rndpos.y = temp.y;                                                                // temp y값을 랜덤포지션에 넣기
            Vector3 temp2 = new Vector3(scale, scale, scale);                                 // temp2에 랜덤된 scale 입력
            Vector3 temp3 = new Vector3(0.0f, angle, 0.0f);                                   // temp3에 램덤된 y회전율 넣기


            // add = Random.insideUnitSphere
            clone.transform.position = rndpos;                                                 // 클론 포지션은 랜덤포지션
            clone.transform.localScale = temp2;                                                // 클론 스케일은 temp2
            clone.transform.localEulerAngles = temp3;                                          // 클론 회전은 temp3
            clone.transform.SetParent(propRoot);                                               // 클론 부모는 propRoot 안에
        }
        else
        {
            return;
        }

    }
    public void Spawn()
    {
        if (deleteOn == false)
        {
            int i = (int)Random.RandomRange(number.x, number.y);
            for (int a = 0; a < i; a++)
            {
                add();
            }
        }
        else
            Debug.Log("!!삭제!!의 \"Delete on\"을 꺼주세요");

    }

    [Space(20), HorizontalLine("!!삭제!!", color: FixedColor.Orange), HideField] public bool _l2;
    public bool deleteOn;


    bool CheckInside(Vector3 A, Vector3 B)                                                    // 두점 사이의 거리를 구하는 함수
    {
        float dist = Vector3.Distance(A, B);
        return dist <= Radius;
    }

    bool CheckHeight(Vector3 clonepoint, out Vector3 hitpoint)                                                    // 생성할 오브젝트와 지형이 만나는 지점을 찾기(Ray를 활용해서 직선과 오브젝트 표면의 교점을 찾기)
    {
        RaycastHit hit;

        if (Physics.Raycast(clonepoint + Vector3.up * 30f, -Vector3.up, out hit, 100.0f, layerMask))
        {
            hitpoint = hit.point;
            return true;
        }
        else
        {
            hitpoint = Vector3.zero;
            return false;
        }

    }
    [Space(20), Button("Erase", size = Size.big), HideField] public bool _b1;
    void Erase()

    {
        if (deleteOn == true)
        {
            // propRoot.transform.childCount : 리스트 자료구조형

            // foreach (Transform t in propRoot)
            // {
            //     DestroyImmediate(t.gameObject); /*에디터 모드일 때*/  // Destroy() : 플레이 모드일 때 
            // }

            foreach (Transform t in propRoot)
            {
                if (CheckInside(t.position, transform.position) == true)
                    DestroyImmediate(t.gameObject);
            }
        }


        else
            Debug.Log("\"Delete on\"을 켜주세요");
    }



}

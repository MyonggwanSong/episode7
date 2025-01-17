using System.Collections.Generic;
using CustomInspector;
using UnityEngine;
public class Array1 : MonoBehaviour
{
    // int, float, string, bool, ....
    // Array(배열), List화 할 수 있다.

    [Range(0, 10)] public int[] num;

    [Space(10), Button("ArrayGetvalue", size = Size.big), HideField] public bool _b0;

    void ArrayGetvalue()
    {///////////////////배열의 길이//////////////////////
        Debug.Log($"Array의 총 개수는 : {num.Length}");
     ///////////////배열의 특정 위치의 값//////////////
        Debug.Log($"Array의 index 0 의 값 : {num.GetValue(0)}");
        Debug.Log($"Array의 index 0 의 값 : {num[0]}");


    }

    [Space(30), Button("ArrayLoop", size = Size.big), HideField] public bool _b1;

    void ArrayLoop()
    {
        int a;
        for (num.GetValue(a = 0); a < num.Length; a++)
        {
            num.SetValue(a, a);
            Debug.Log($"index {a}에 {num.GetValue(a)}를 찍었습니다.");
        }
    }

    [Space(30), Button("ArrayLoop2", size = Size.big), HideField] public bool _b2;
    void ArrayLoop2()
    {
        int index=0;
        foreach(int a in num) // foreach(자식 부모) : 배열을 넣어주면 각 인덱스마다 한번씩 실행
        {
            
            Debug.Log($"index{index} : {a}");
            index++;
        }
    }
    

    
    
    
    public int[] num2 = { 1, 3, 5, 7 };
    [Range(0.0f, 2.0f)] public List<float> numList;

    public List<GameObject> add;
    public List<string> namearray;
    public string findname;



    [Space(30), Button("ArrayFind", size = Size.big), HideField] public bool _b3;
    void ArrayFind()
    {
        int temp = 0;
        int index = 0;
        foreach (string Name in namearray) // foreach(자식 부모) : 배열을 넣어주면 각 인덱스마다 한번씩 실행
        {
            if (Name == findname)
            {
                Debug.Log($"index{index}에 위치한 {Name}를 찾았습니다.");
                temp++;
                break;
            }

            index++;

        }

        if (temp==0)
        {
            Debug.Log($"해당 이름을 찾지 못했습니다. 다시 한번 확인 해주세요.");

        }

    }


    [Space(30), Button("ArrayFind2", size = Size.big), HideField] public bool _b4;
    void ArrayFind2()
    {

        int index = 0;
        foreach (string Name in namearray) // foreach(자식 부모) : 배열을 넣어주면 각 인덱스마다 한번씩 실행
        {
            if (Name == findname)
            {
                Debug.Log($"index{index}에 위치한 {Name}를 찾았습니다.");
                return; // 함수 자체를 탈출!(void로 리턴해버리기~)
            }
            index++;
        }

        Debug.Log($"해당 이름을 찾지 못했습니다. 다시 한번 확인 해주세요.");
    }


}

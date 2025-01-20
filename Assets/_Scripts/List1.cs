using System;
using System.Collections.Generic;
using CustomInspector;
using UnityEngine;

public class List1 : MonoBehaviour
{
    public List<int> datas;

    // datas.Add() :   추가
    // datas.Clear() : 전체 삭제
    // datas.Remove() : 하나 삭제
    // datas.Count : 총 길이 출력
    // datas.Foreach() : 각 항목 순회 실행
    // datas.find() : 탐색

    [Space(20), Button("AddData", true, size = Size.medium)] public int Add;
    void AddData(int n)
    {
        datas.Add(n);
        Debug.Log($"입력한 숫자 {n}");
    }

    [Space(20), Button("ClearData", size = Size.medium), HideField] public bool _b1;
    void ClearData()
    {
        datas.Clear();
    }
    [Space(20), Button("RemoveData", true, size = Size.medium)] public int Remove;
    void RemoveData(int n)
    {
        datas.Remove(n);
    }

    [Space(20), Button("RemoveAtData", true, size = Size.medium)] public int RemoveAT;
    void RemoveAtData(int i)
    {
        // if (datas.Exists(a => a == i))
        // {
        //     datas.RemoveAt(i);
        // }
        // else
        //     return;

        try  // 시도해봐라
        {
             datas.RemoveAt(i);
        }
        catch(ArgumentOutOfRangeException) // 안되면 이거 해봐라
        {

        }
        finally{} // 이건 다 하고 가라
    }
    [Space(20), Button("sortData",  size = Size.medium),HideField] public bool Sort;
    void sortData()
    {

        datas.Sort();

    }


    [Space(20), Button("showAllData", size = Size.medium), HideField] public bool ShowData;
    void showAllData()
    {
        // for (int i = 0; i < datas.Count; i++)
        // {
        //     Debug.Log($"{i}의 값 : {datas[i]}");
        // }

        // int a = 0;
        // while (a < datas.Count)
        // {
        //     Debug.Log($"{a}의 값 : {datas[a]}");
        //     a++;
        // }

        // int index=0;
        // foreach (int a in datas)
        // {
        //     Debug.Log($"{index}의 값 : {a}");
        //     index++;
        // }


        int index=0;

        datas.ForEach(v => Debug.Log($"{index}의 값 : {v}"));




    }





    [Space(20), HorizontalLine(color: FixedColor.Orange), HideField] public bool _l1;

    public List<string> dataStr = new List<string>();
    public List<GameObject> dataGame = new List<GameObject>();

    void adfasdf()
    {
        dataGame.Clear();
    }


}
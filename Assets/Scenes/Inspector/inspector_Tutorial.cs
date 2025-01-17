using UnityEngine;
using CustomInspector;
public class inspector_Tutorial : MonoBehaviour
{
    [Title("인스펙터 꾸미기", fontSize = 25, alignment = TextAlignment.Center)]
    [HorizontalLine("세부 속성", color: FixedColor.Orange), HideField] public bool _l0;

    [Range(0,10)] public int a;
    [Range(0.0f, 1000.0f)] public float b;
    [RichText(true)]
    [Multiline(lines: 4)]
    public string text1;
    [TextArea(minLines: 2, maxLines: 10)]
    public string text2;


    [Space(20), Button("Method", size = Size.big), HideField] public bool _b0;
    [Space(20), HorizontalLine("세부 속성", color: FixedColor.Orange), HideField] public bool _l1;

    [Space(20)]
    public int c;
    public int d;
    [Space(20), Button("Method2", size = Size.small)] public int inputnum;


    [Space(20), HorizontalLine("세부 속성", color: FixedColor.Orange), HideField] public bool _l2;

    [Space(20)]
    public int e;
    public int f;
    [Preview] public Sprite text3;
    [Space(20) ,ReadOnly(DisableStyle.OnlyText)] public string text4 = "ReadOnly test"; 

    [Space(20), Button("Method3", size = Size.big), HideField] public bool _b4;
    [Space(20), HideField] public bool _b5;


    void Method()
    {
        Debug.Log(1);
    }

    void Method2()
    {
        Debug.Log(2);
    }

     void Method3()
    {
        Debug.Log(3);
    }

}

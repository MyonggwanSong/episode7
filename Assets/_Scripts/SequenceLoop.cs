using UnityEngine;
using DG.Tweening;
using CustomInspector;
// DoTween : Update() 콜 아닌, 단발성 함수 호출 : 내부에서 자체 Thread 생성
//
public class SequenceLoop : MonoBehaviour
{
    public float moveDuration = 1f;
    public float colorDuration = 1f;
    public float popUpHeight;
    public Ease ease = Ease.Unset;
    private Vector3 initPos ;
    private Color initColor;
    private Vector3 initScale = new Vector3(1, 1, 1);
    [Button("MoveY"), HideField] public bool _B0;
    [Button("CompositedMove"), HideField] public bool _B1;
    [Button("ChangeColor"), HideField] public bool _B2;
    [Space]
    public MeshRenderer Meshrend;
    public Color MeshColor;
    [Space]
    public RotateMode rotateMode;
    void Start() // 초기값 설정 용도
    {
        initPos = transform.position;
        initColor = Meshrend.material.color;
        Debug.Log("Start");
    }
    void OnDestroy() // 사용한 리소스들 청소 (삭제)
    {
        DOTween.KillAll();
        Debug.Log("OnDestroy");
    }
    
    void MoveY()
    {
        KillMoveY();
        transform.position = initPos;
        Meshrend.material.color = initColor;
        float h = popUpHeight;
        transform.DOLocalMoveY(initPos.y+h, moveDuration)
                .SetLoops(1, LoopType.Incremental)
                .SetEase(ease)
                .OnComplete(() =>
                {
                    Debug.Log(" 트윈 종료, 컬러 변경 시작");
                    ChangeColor();
                }
                    );
        // transform.DOLocalMove(new Vector3(0f, 2f, 0f), moveDuration);
    }
    
    //          () =>
    // function () {}
    void ChangeColor()
    {
        // Meshrend.material.color = MeshColor;
        // Meshrend.material.color = initColor;
        Meshrend.material.DOColor(MeshColor, colorDuration)
                        .SetLoops(-1, LoopType.Yoyo);
        // Meshrend.material.DOFade(0f, colorDuration)
        //                 .SetLoops(-1, LoopType.Yoyo);
    }
    [Button("KillMoveY",size =Size.small), HideField] public bool _B3;
    void KillMoveY()
    {
        // DOTween.Kill() : 현재 동작중인 Tween 의 Thread 를 지운다 (삭제)
        DOTween.Kill(transform);
        DOTween.Kill(Meshrend.material);
    }
    void CompositedMove()
    {
        KillMoveY();
        transform.position = initPos;
        Meshrend.material.color = initColor;
        transform.localScale = initScale;
        float h = popUpHeight;
        transform.DOLocalMoveY(initPos.y+h, moveDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(ease);
        transform.DOScale(1.5f, moveDuration)
                .SetLoops(-1, LoopType.Yoyo);
        Meshrend.material.DOColor(MeshColor, colorDuration)
                .SetLoops(-1, LoopType.Yoyo);
        transform.DOLocalRotate(Vector3.up * 360f, moveDuration, rotateMode)
                .SetLoops(-1, LoopType.Incremental)
                .SetEase(ease);
    }

    [Space(20)]
    [Button("backup"), HideField] public bool _B4;
    void backup()
    {
        transform.DOLocalMoveX(1f, 1f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);
        transform.DOScaleY(1.5f, 1f).SetLoops(-1, LoopType.Yoyo);
        transform.DOLocalMoveY(1f, moveDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);
        transform.DOLocalRotate(new Vector3(0f, 360f, 0f), moveDuration + 0.5f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Incremental);
        // .SetEase(Ease.InOutQuad);
    }
}
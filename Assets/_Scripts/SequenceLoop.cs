using UnityEngine;
using DG.Tweening;
using CustomInspector;
// DoTween : Update() 콜 아닌, 단발성 함수 호출 : 내부에서 자체 Thread 생성
//
public class SequenceLoop : MonoBehaviour
{
    public float duration = 1f;
    public Ease ease = Ease.Unset;
    private Vector3 initPos;
    private Color initColor;
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
    [Button("MoveY"), HideField] public bool _B0;
    void MoveY()
    {
        KillMoveY();
        transform.position = initPos;
        Meshrend.material.color = initColor;
        transform.DOLocalMoveY(2f, duration)
                .SetLoops(1, LoopType.Incremental)
                .SetEase(ease)
                .OnComplete(() =>
                {
                    Debug.Log(" 트윈 종료, 컬러 변경 시작");
                    ChangeColor();
                }
                    );
        // transform.DOLocalMove(new Vector3(0f, 2f, 0f), duration);
    }
    //          () =>
    // function () {}
    [Button("ChangeColor"), HideField] public bool _B1;
    void ChangeColor()
    {
        // Meshrend.material.color = MeshColor;
        // Meshrend.material.color = initColor;
        Meshrend.material.DOColor(MeshColor, duration)
                        .SetLoops(-1, LoopType.Yoyo);
        // Meshrend.material.DOFade(0f, duration)
        //                 .SetLoops(-1, LoopType.Yoyo);
    }
    [Button("KillMoveY"), HideField] public bool _B2;
    void KillMoveY()
    {
        // DOTween.Kill() : 현재 동작중인 Tween 의 Thread 를 지운다 (삭제)
        DOTween.Kill(transform);
        DOTween.Kill(Meshrend.material);
    }
    [Button("CompositedMove"), HideField] public bool _B3;
    void CompositedMove()
    {
        KillMoveY();
        transform.position = initPos;
        Meshrend.material.color = initColor;
        transform.DOLocalMoveY(3f, duration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(ease);
        transform.DOScale(1.5f, duration)
                .SetLoops(-1, LoopType.Yoyo);
        Meshrend.material.DOColor(MeshColor, duration)
                .SetLoops(-1, LoopType.Yoyo);
        transform.DOLocalRotate(Vector3.up * 360f, duration, rotateMode)
                .SetLoops(-1, LoopType.Incremental)
                .SetEase(ease);
    }
    void backup()
    {
        // transform.DOLocalMoveX(1f, 1f)
        //     .SetLoops(-1, LoopType.Yoyo)
        //     .SetEase(Ease.InOutQuad);
        //transform.DOScaleY(1.5f, 1f).SetLoops(-1, LoopType.Yoyo);
        // transform.DOLocalMoveY(1f, duration)
        //     .SetLoops(-1, LoopType.Yoyo)
        //     .SetEase(Ease.InOutQuad);
        // transform.DOLocalRotate(new Vector3(0f, 360f, 0f), duration + 0.5f, RotateMode.FastBeyond360)
        //     .SetLoops(-1, LoopType.Incremental);
        // // .SetEase(Ease.InOutQuad);
    }
}
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Tween2Sequence : MonoBehaviour
{
    public List<Vector3> targetPos;

    
    void Start()
    {
        //SequenceMove();
        //SequenceMoveLoop();
        SequenceMoveWander();
        //Sequence1();
    }


    void SequenceMove()
    {
        // Append : 시퀀스 뒤에 첨가 , DoTween 함수를 바로 사용한다.
        // AppendInterval : 시퀀스 뒤에 첨가 , 지정한 시간만큼 지연 시킨다.
        // AppednCallback : 시퀀스 뒤에 첨가 , 일반적인 함수를 람다형식으로 사용한다.

        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(0.5f);
        seq.Append( transform.DOMove(targetPos[0], 1f) );
        seq.Append( transform.DOLocalRotate(Vector3.up*90f, 0.25f) );
        seq.Append( transform.DOMove(targetPos[1], 1f) );
        seq.Append( transform.DOLocalRotate(Vector3.up*180f, 0.25f) );
        seq.Append( transform.DOMove(targetPos[2], 1f) );
        seq.Append( transform.DOLocalRotate(Vector3.up*270f, 0.25f) );
        seq.Append( transform.DOMove(targetPos[3], 1f) );
        seq.Append( transform.DOLocalRotate(Vector3.up*360f, 0.25f) );
        seq.SetLoops(-1);

        //seq.AppendCallback( ()=> SequenceMove() );

        //seq.AppendCallback( ()=> Debug.Log("시퀀스 종료"));
    }

    // 반복문을 사용해서 루프 돌리기
    // while (무한반복 유리), for (유한반복 유리 : index ) , foreach (유한반복 유리 : value)
    void SequenceMoveLoop()
    {
        // foreach
        Sequence seq = DOTween.Sequence();

        int r=1;
        foreach( Vector3 v in targetPos )
        {
            seq.Append( transform.DOMove(v, 1f) );
            seq.Append( transform.DOLocalRotate(Vector3.up*90f*r, 0.25f) );
            r++;
        }
        
        seq.SetLoops(-1);
    }


    // Wander : 반지름 10 영역안에서 왔다갔다 하도록 한다. (Patrol)
    // SetLoop 와 Random 활용
    public Vector3 rndpos;

    void SequenceMoveWander()
    {
        // 범위 : -1f ~ 1f => -10f ~ 10f
        //Random.value // float 1개
        //Random.insideUnitCircle  // float 2개
        //Random.insideUnitSphere  // float 3개

        // Vector3 rndpos = Random.insideUnitSphere * 10f;
        // rndpos.y = 0.5f;
        
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback( ()=> 
        {
            rndpos = Random.insideUnitSphere * 10f;
            rndpos.y = 0.5f;

            transform.rotation = Quaternion.LookRotation(rndpos - transform.position);

            transform.DOMove(rndpos, 1f);
        });
        seq.AppendInterval(0.5f);        
        seq.SetLoops(-1);
    }




    void Sequence1()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(1f);
        seq.AppendCallback( () => Debug.Log("1초") );
        seq.AppendInterval(1f);
        seq.AppendCallback( () => Debug.Log("2초") );
        seq.AppendInterval(1f);
        seq.AppendCallback( () => Debug.Log("3초") );       
    }
}
using UnityEngine;
using CustomInspector;

public class VectorMovement : MonoBehaviour
{
   
    /// ///////// inpout(legacy):  키보드 마우스 모바일(터치)의 입력을 처리한다.
    
    
    [ReadOnly] public Vector2 Movement;
    [Range(1,100)]public float movespeed;
    public float torque=100;
    void Update()
    {
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");                         // 
        Movement.x= horz;
        Movement.y= vert;

        if (Input.GetButton("Fire1"))                                   // 버튼 누르면 참 = 실행, 누르지 않으면 거짓 = 패스
        {
            // Debug.Log("Fire!");
        }
        if (Input.GetButtonDown("Jump"))
        {
            // Debug.Log("Jump Down!");
        }
        if (Input.GetButtonUp("Jump"))
        {
            // Debug.Log("Jump Up!");
        }
        // Debug.Log(Movement.normalized);
         transform.Translate(0.0f,0f,vert*movespeed*Time.deltaTime);
        transform.Rotate(0.0f,horz*torque*Time.deltaTime, 0.0f);

    }
}

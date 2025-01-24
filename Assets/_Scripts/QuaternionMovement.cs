using CustomInspector;
using UnityEngine;

public class QuaternionMovement : MonoBehaviour
{
    [Title("카메라")] public Camera cameraName;
    public float yaw;
    public float pitch;
    public bool jump;
    public float angleSpeed;
    public float moveSpeed;
    public float jumpPower = 5f;
    public float jumpDuration = 1f;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Vector3 forward = Vector3.forward * pitch;
        // Vector3 right = Vector3.right * yaw;
        // Vector3 add = forward + right;
        // Gizmos.DrawRay(Vector3.zero, add * 5f);

        Vector3 forward = cameraName.transform.forward * pitch;


        Vector3 right = cameraName.transform.right * yaw;
        Vector3 add = forward + right;
        //Gizmos.DrawRay(transform.position, add * 5f);


    }
    void Update()
    {
        yaw = Input.GetAxisRaw("Horizontal") * 360f * Time.deltaTime;           // "d,a를 눌렀을 때 각각 1,-1 의 값을 넣음 
        pitch = Input.GetAxisRaw("Vertical") * 360f * Time.deltaTime;           // "w,s를 눌렀을 때 각각 1,-1 의 값을 넣음 
        jump = Input.GetButtonDown("Jump");                                    // space를 눌렀을 때 true를 넣음

        //  Input.GetAxis() : -1~1 사이의 값이 연속적으로 부드럽게 찍힘
        // Input.GetAxisRaw(): -1,0,1,이 양자화 돼있음
        // Quaternion rot = Quaternion.Euler(0.0f,yaw*360,0.0f);

        UpdateRotation();
        UpdatePosition();
        UpdateJump();



    }

    void UpdatePosition()               // 이동 처리
    {
        if (cameraName.transform.eulerAngles.x == 90f)
        {
            Vector3 forward = cameraName.transform.up * pitch;                       // 카메라의 전방
            forward.y = 0.0f;                                                        // y값만 날림
            Vector3 right = cameraName.transform.right * yaw;                        // 카메라의 측방
            right.y = 0.0f;                                                          // y값만 날림
            Vector3 add = forward.normalized + right.normalized;                              // 카메라의 전방과 측방을 더해서 x,z평면에 원형으로 방향을 만듬 

            Vector3 movedir = add * moveSpeed * Time.deltaTime;                      // 방향으로 움직임을 

            transform.position += movedir;

            Debug.DrawRay(transform.position, movedir * 100f, Color.blue);


        }
        else
        {
            Vector3 forward = cameraName.transform.forward * pitch;                   // 카메라의 전방
            forward.y = 0.0f;                                                        // y값만 날림
            Vector3 right = cameraName.transform.right * yaw;                        // 카메라의 측방
            right.y = 0.0f;                                                          // y값만 날림
            Vector3 add = forward.normalized + right.normalized;                              // 카메라의 전방과 측방을 더해서 x,z평면에 원형으로 방향을 만듬 

            Vector3 movedir = add * moveSpeed * Time.deltaTime;                      // 방향으로 움직임을 

            transform.position += movedir;

            Debug.DrawRay(transform.position, movedir * 100f, Color.blue);
        }
    }
    float jumpStarttime;
    Vector3 jumpstartposition;
    void UpdateJump()                   // 점프 처리
    {   //포물선 방정식 : y(높이)=x(시간 변화량)-x(시간 변화량)*x(시간 변화량)
        // deltaTime : 한 프레임이 넘어갈 동안의 시간
        // time : 현재 시간
        // jump = Input.GetButtonDown("Jump");

        if (jump)

        {
            jumpStarttime = Time.time;
            jumpstartposition = transform.position;
        }
        // (nowtime - starttime)/duration : 몇초간 뛴 퍼센트

        float p = (Time.time - jumpStarttime) / jumpDuration;

        if (p <= 1)
        {
            float jumpHeight = p - p * p;


            transform.position = new Vector3(transform.position.x, jumpstartposition.y + jumpHeight * jumpPower, transform.position.z);

        }


    }


    void UpdateRotation()               // 회전처리
    {
         

        if (cameraName.transform.eulerAngles.x == 90f)
        {
            Vector3 forwarddirection = cameraName.transform.up * pitch;
            forwarddirection.y = 0.0f;
            Vector3 rightdirection = cameraName.transform.right * yaw;
            rightdirection.y = 0.0f;
            Vector3 add = forwarddirection.normalized + rightdirection.normalized;

            if (add.magnitude == 0)
                return;

            // Quaternion rightdir = Quaternion.LookRotation(rightdirection);
            Quaternion lookrot = Quaternion.LookRotation(add);
            Quaternion lookAt = Quaternion.RotateTowards(transform.rotation, lookrot, angleSpeed * Time.deltaTime);

            transform.rotation = lookAt;
        }
        else
        {
            Vector3 forwarddirection = cameraName.transform.forward * pitch;
            forwarddirection.y = 0.0f;

            Vector3 rightdirection = cameraName.transform.right * yaw;
            rightdirection.y = 0.0f;
            Vector3 add = forwarddirection.normalized + rightdirection.normalized;

            if (add.magnitude == 0)
                return;

            Quaternion lookrot = Quaternion.LookRotation(add);
            Quaternion lookAt = Quaternion.RotateTowards(transform.rotation, lookrot, angleSpeed * Time.deltaTime);

            transform.rotation = lookAt;
        }
    }
}

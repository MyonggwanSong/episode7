using CustomInspector;
using UnityEngine;

public class QuaternionMovement : MonoBehaviour
{
    [Title("카메라")] public Camera cameraName;
    public float yaw;
    public float pitch;
    public float angleSpeed;
    public float moveSpeed;

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
        Gizmos.DrawRay(cameraName.transform.position, add * 5f);


    }
    void Update()
    {
        yaw = Input.GetAxisRaw("Horizontal") * 360f * Time.deltaTime;
        pitch = Input.GetAxisRaw("Vertical") * 360f * Time.deltaTime;


        //  Input.GetAxis() : -1~1 사이의 값이 연속적으로 부드럽게 찍힘
        // Input.GetAxisRaw(): -1,0,1,이 양자화 돼있음
        // Quaternion rot = Quaternion.Euler(0.0f,yaw*360,0.0f);

        UpdateRotation();
        UpdatePosition();

        
    

    }

    void UpdatePosition()               // 이동 처리
    {
        Vector3 forward = cameraName.transform.forward;
        Vector3 right = cameraName.transform.right * yaw;
        Vector3 add = forward + right;
        
        Vector3 movedir = new Vector3(add.x * moveSpeed * Time.deltaTime, 0f, add.z * moveSpeed * Time.deltaTime);
        transform.position += movedir;

    }


    void UpdateRotation()               // 회전처리
    {
        Vector3 forwarddirection = cameraName.transform.forward * pitch;
        forwarddirection.y = 0.0f;

        Vector3 rightdirection = cameraName.transform.right * yaw;
        rightdirection.y = 0.0f;
        Vector3 add = forwarddirection + rightdirection;

        if (add.magnitude == 0)
            return;

        // Quaternion rightdir = Quaternion.LookRotation(rightdirection);
        Quaternion lookrot = Quaternion.LookRotation(add);
        Quaternion lookAt = Quaternion.RotateTowards(transform.rotation, lookrot, angleSpeed * Time.deltaTime);

        transform.rotation = lookAt;
        

    }
}

using CustomInspector;
using UnityEngine;

public class quaternionVector : MonoBehaviour
{

    /// <summary>
    /// Radian (회전율) : pie(π)radian = 180º, 1Radian = 57,3º , 2Radian 114.6º
    /// 이동 관련 함수 >> Vector3
    /// 회전 관련 함수 >> Quaternion
    /// 크기 관련 함수 >> Vector3
    /// </summary>/
#region 맴버변수

    public float pitch;
    public float yaw;
    public float roll;

    public float rotateSpeed;
    public float moveSpeed;
    public Camera cameraName;

    public bool moveOn;
    #endregion
    #region 상시 함수
    void Update()
    {
        yaw = Input.GetAxisRaw("Horizontal") * 360f * Time.deltaTime;
        pitch = Input.GetAxisRaw("Vertical") * 360f * Time.deltaTime;
        // yaw = Input.GetAxis("Horizontal") * 360f * Time.deltaTime;
        // pitch = Input.GetAxis("Vertical") * 360f * Time.deltaTime;

        // Quaternion rotation = Quaternion.Euler(pitch,yaw,roll);
        // transform.rotation *= rotation;

        lookRotationsmooth();
        UpdatePosition();
        if (moveOn)
        {
            UpdateRotation();
        }

    }
    #endregion
    #region 인스팩터 상호작용

    [Button("Quaternion1", label = "쿼터니언 속성", size = Size.big), HideField] public bool _0b;
    void Quaternion1()
    {
        Debug.Log($"쿼터니언 아이덴티티 : {Quaternion.identity}");
    }



    [Space(20), HorizontalLine("타겟 속성"), HideField] public bool _1b;

    [SerializeField] GameObject target;

    [Space(20), Button("LookRotate", size = Size.big), HideField] public bool _2b;
    void LookRotate()
    {
        Vector3 lookAt = target.transform.position - transform.position;


        transform.rotation = Quaternion.LookRotation(lookAt);
        // Quaternion.LookRotation(lookAt,transform.right);
    }
    #endregion
    void lookRotationsmooth()
    {
        Vector3 lookAt = target.transform.position - transform.position;
        Quaternion lookrot = Quaternion.LookRotation(lookAt);                              // 타겟을 바라보도록 연산
        lookrot.x = 0.0f;
        lookrot.z = 0.0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookrot, rotateSpeed * Time.deltaTime); // 타겟을 부드럽게 바라보도록 연산 후 transform.rotaion으로 회전

    }
    void UpdatePosition()               // 이동 처리
    {
        Vector3 forward = cameraName.transform.forward * pitch;
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
        Quaternion lookAt = Quaternion.RotateTowards(transform.rotation, lookrot, rotateSpeed * Time.deltaTime);

        transform.rotation = lookAt;
    }



}

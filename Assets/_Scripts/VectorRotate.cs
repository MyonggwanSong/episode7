using UnityEngine;
using CustomInspector;

public class VectorRotate : MonoBehaviour
{
    // x축 회전 : Pitch
    public float pitch;
    // y축 회전 : Yaw
    public float yaw;
    // z축 회전 : Roll
    public float roll;
    public float torque = 100;

    void Update()
    {
        yaw = Input.GetAxis("Horizontal")* 360f * Time.deltaTime;
        pitch = Input.GetAxis("Vertical")* 360f * Time.deltaTime;
        Vector3 rotate = new Vector3(pitch, yaw, roll);
        transform.Rotate(rotate);
    }


    [Button("GimballlockRotate", label = "짐벌락"), HideField] public bool _0b;

    void GimballlockRotate()
    {

    }
   
}

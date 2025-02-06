using UnityEngine;

public class Trigger : MonoBehaviour
{
    Vector3 _temp;
    void OnTriggerEnter(Collider col)
    {
        Debug.Log($"TriggerEnter{col.name}");
        if (col.gameObject.tag != "Item")
            return;
        _temp = col.transform.localScale;
        col.transform.localScale = _temp * 3f;
    }

    void OnTriggerStay(Collider col)
    {
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag != "Item")
            return;
        Destroy(col.gameObject);
        //col.transform.localScale = _temp;
    }
}

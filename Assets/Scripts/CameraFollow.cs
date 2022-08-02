using UnityEngine;

public class CameraFollow : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject Doll;
    [SerializeField] private float camOffset;
#pragma warning restore 0649
    
    private void LateUpdate()
    {
        transform.position = new Vector3(
            Doll.transform.position.x + camOffset, transform.position.y, transform.position.z);
    }
}
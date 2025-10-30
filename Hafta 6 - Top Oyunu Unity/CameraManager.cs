using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player; //oyuncu karakterinin ekrandaki konumu
    public Vector3 offset = new Vector3(0, 20, -50); //oyuncu ve kamera arasýndaki olacak mesafe 

    private void LateUpdate()
    {
         transform.position = player.position + offset; 
    }
}

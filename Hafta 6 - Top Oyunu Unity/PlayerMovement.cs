using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 50f; //oyuncunun haraket hýzý 
    Rigidbody rb; // fiziki compenenti

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // scriptin üzerinde baðlý olduðu nesneyi bul
        ScoreManager = FindFirstObjectByType<ScoreManager>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal"); //Yatay Haraket girdisi
        float moveZ = Input.GetAxis("Vertical"); // Diket Haraket girdisi

        Vector3 movement = new Vector3 (moveX , 0f ,moveZ); //Oyuncunun gitmek istediði yönü belirle
        rb.AddForce (movement*moveSpeed); //  Rigibody gidilmek istenen yönde kuvvet uygula böylece haraket saðlanýr
    }

    private void OnTriggerEnter(Collider other)
        //Eðer oyuncu  "Pickup" tagýna sahip bir nesneye sahip çarparsa o nesneyi yönet 
        if (other.CompareTag("Pickup"))
        {
            Destory(other.gameObject);
            ScoreManager.CollectPickup();
        }
}

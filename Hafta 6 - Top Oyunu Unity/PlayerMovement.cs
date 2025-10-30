using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 50f; //oyuncunun haraket h�z� 
    Rigidbody rb; // fiziki compenenti

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // scriptin �zerinde ba�l� oldu�u nesneyi bul
        ScoreManager = FindFirstObjectByType<ScoreManager>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal"); //Yatay Haraket girdisi
        float moveZ = Input.GetAxis("Vertical"); // Diket Haraket girdisi

        Vector3 movement = new Vector3 (moveX , 0f ,moveZ); //Oyuncunun gitmek istedi�i y�n� belirle
        rb.AddForce (movement*moveSpeed); //  Rigibody gidilmek istenen y�nde kuvvet uygula b�ylece haraket sa�lan�r
    }

    private void OnTriggerEnter(Collider other)
        //E�er oyuncu  "Pickup" tag�na sahip bir nesneye sahip �arparsa o nesneyi y�net 
        if (other.CompareTag("Pickup"))
        {
            Destory(other.gameObject);
            ScoreManager.CollectPickup();
        }
}

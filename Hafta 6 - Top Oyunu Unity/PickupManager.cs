using UnityEngine;
//Toplanabilir kapsülleri zemin üstünde rastgele oluþturmak için script

public class PickupManager : MonoBehaviour
{
    public GameObject pickup;  //kapsül prefabý
    public GameObject ground; //zemin
    public int anount; // Doðacak kapsül adedi 
    private void Start()
    {
        //Zemin boyutlarýný al, Plane nesnesini 10*10 birim olduðundan zeminin scale deðerini 10 ile çarparak boyutuna ulaþtýk
        float groundSizeX= ground.transform.localScale.x * 10f;
        float groundSizeZ = ground.transform.localScale.z * 10f;
        
        for (int i=0; i<anount;  i++)
        {
            float randomX = Random.Range(-groundSizeX / 2f, groundSizeX / 2f);
            float randomZ = Random.Range(-groundSizeZ / 2f, groundSizeZ / 2f);

            //Kapsülün doðacaðý konumunu belirle
            Vector3 location = new Vector3(randomX, 3f, randomZ);
            Instantiate(pickup,location, Quaternion.identity); // Kapsülü zeminde rastgele yere atar
        }
    }
}

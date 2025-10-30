using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    PickupManager pickups; // Sahnedeki kapsüllerin refeansý

    int totalPickups;
    int score = 0;


    private void Start()
    {
        pickups = FindFirstObjectByType<PickupManager>();
        totalPickups = pickups.anount;
        UpdateScore();
    } 
    public void CollectPickup()
    {
        score++;
        UpdateScore();

        if (score >= totalPickups)
        {
            Time.timeScale = 0f;
        }
    }

    public void UpdateScore()
    {
        scoreText.text ="Skor:"+ score.ToString(); 
    }
}

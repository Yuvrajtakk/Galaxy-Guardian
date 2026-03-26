using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreBoardText;
    int Score = 0;

    public void IncreaseScore(int amount)
    {
        Score += amount;
        scoreBoardText.text = Score.ToString();   
    }
}

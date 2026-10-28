using UnityEngine;

[System.Serializable]
public struct HighScore
{
    public string name;
    public int score;
}

[CreateAssetMenu(fileName = "Score", menuName = "Scriptable Objects/Score")]
public class Score : ScriptableObject
{
    public HighScore[] topTen;
}

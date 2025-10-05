using DefaultNamespace;
using UnityEngine;

public class PosionApple : MonoBehaviour, IAppleScore
{
    public static float bottomY = -20f;
        
    [SerializeField] private int score = -600;
    
    public int Score => score;
}
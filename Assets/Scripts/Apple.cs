using DefaultNamespace;
using UnityEngine;

public class Apple : MonoBehaviour, IAppleScore
{
    public static float bottomY = -20f;
    public int score;

    private void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);
            
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            apScript.AppleMissed();
        }
    }

    public int Score => score;
}

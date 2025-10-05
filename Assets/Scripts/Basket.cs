using DefaultNamespace;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    void Start()
    {
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGo.GetComponent<ScoreCounter>();
    }
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        
        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        
        
        if (collidedWith.CompareTag("Apple"))
        {
            var appleScore = collidedWith.GetComponent<IAppleScore>();
            scoreCounter.score += appleScore.Score;
            Destroy(collidedWith);
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }

        if (collidedWith.CompareTag("Apple_Posion"))
        {
            var appleScore = collidedWith.GetComponent<IAppleScore>();
            scoreCounter.score += appleScore.Score;
            Destroy(collidedWith);
            
            if (scoreCounter.score < 0) scoreCounter.score = 0;
            
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleMissed();
            
        }
    }
}

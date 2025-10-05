using UnityEngine;
public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject goldenApplePrefab;
    public GameObject posionApplePrefab;

    public float speed = 1f;

    public float leftAndRightEdge = 10;

    public float changeDirChance = 0.1f;

    public float appleDropDelay = 1f;

    public float GoldenAppleChance = 0.1f;
    public float PosionAppleChance = 0.1f;

    private void Start()
    {
        Invoke("DropApple",2f);
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        
    }
    
    private void DropApple()
    {


        if (Random.value < GoldenAppleChance)
        {
            var goldenApple = Instantiate(goldenApplePrefab);
            goldenApple.transform.position = transform.position;
        }
        else if (Random.value < PosionAppleChance)
        {
            var posionApple = Instantiate(posionApplePrefab);
            posionApple.transform.position = transform.position;
        }else
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
        }
        Invoke("DropApple", appleDropDelay);
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}

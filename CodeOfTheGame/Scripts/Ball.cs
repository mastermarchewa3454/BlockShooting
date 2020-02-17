using UnityEngine;

public class Ball : MonoBehaviour
{
    // configuraion parameters
    [SerializeField] DeadPoolHead head1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomness = 0.2f;

    bool isStarted = false;
    Vector2 headToBallVector;
    // Start is called before the first frame update

    AudioSource audioSource;
    Rigidbody2D myRigidBody2D;
    void Start()
    {
        headToBallVector = transform.position - head1.transform.position; // we substract with the vector of head
        audioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted == false)
        {
            LockTheBallToHead();
            ReleaseTheBall();   
        }
    }
    private void ReleaseTheBall()
    {
        if(Input.GetKey(KeyCode.RightShift))
        {
            isStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockTheBallToHead()
    {
        Vector2 headPos = new Vector2(head1.transform.position.x, head1.transform.position.y);
        transform.position = headPos + headToBallVector;
    }

    public bool getIsStarted()
    {
        return isStarted;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomness), Random.Range(0f, randomness)); // necessary to delete "using..." because of conflicts
        if(isStarted && collision.transform.gameObject.name != "DeadPoolHead")
        {
            if(ballSounds.Length != 0)
            {
                AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
                audioSource.PlayOneShot(clip);
                myRigidBody2D.velocity = myRigidBody2D.velocity + velocityTweak;
            }
            
        }   
    }
}

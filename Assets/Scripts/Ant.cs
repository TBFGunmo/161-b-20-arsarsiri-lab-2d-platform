using UnityEngine;

public class Ant : Enemy
{
    [SerializeField] Vector2 velocity;
    public Transform[] MovePoints;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialize(10);
        DamageHit = 10;

        velocity = new Vector2(-1.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() //0.02 sec
    {
        Behavior();
    }

    public override void Behavior()
    {
        rb.MovePosition( rb.position + velocity * Time.fixedDeltaTime );

        if (velocity.x < 0 && rb.position.x <= MovePoints[0].position.x) 
        {
            Flip();
        }
        if (velocity.x > 0 && rb.position.x >= MovePoints[1].position.x)
        {
            Flip();
        }

    }

    public void Flip() 
    {
        velocity.x *= -1; //change direction of movement

        //flip img
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

}

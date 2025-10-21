using UnityEngine;

public class Crocodile : Enemy
{

    [SerializeField] float attackRange;
    public Player player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialize(25);
        DamageHit = 30;
        //set atk range and target
        attackRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Behavior();
    }
    public override void Behavior()
    {
        //find distance between Croccodile and Player
        Vector2 distance = transform.position - player.transform.position;
        if (distance.magnitude <= attackRange)
        {
            Debug.Log($"{player.name} is in the {this.name} range");
            Shoot();
        }
    }
    public void Shoot()
    {
        Debug.Log($"{this.name} throw rock to the {player.name}!");
    }
}

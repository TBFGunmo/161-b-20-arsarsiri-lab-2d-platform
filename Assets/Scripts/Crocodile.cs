using UnityEngine;

public class Crocodile : Enemy, IShootable
{

    [SerializeField] float attackRange;
    public Player player;

    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialize(25);
        DamageHit = 30;

        //set atk range and target
        attackRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();

        WaitTime = 5.0f;
        ReloadTime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
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
        if (WaitTime >= ReloadTime)
        {
            /*Debug.Log($"{this.name} throw rock to the {player.name}!");*/
            anim.SetTrigger("Shoot");
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Rock rock = bullet.GetComponent<Rock>();
            rock.InitWeapon(30, this);
            WaitTime = 0.0f;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    private int health;
    public int Health
    {
        get => health;
        set 
        { 
            health = (value < 0) ? 0 : value;
            HpBarAdjust();
        }
    }

    private int maxHealth;

    protected Animator anim;
    protected Rigidbody2D rb;

    [SerializeField] private Slider hpBar;


    //initialize variable

    public void Initialize(int startHealth) 
    {
        Health = startHealth;
        Debug.Log($"{this.name} is initialize Health : {this.Health}");

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        maxHealth = Health;

    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} - took {damage} damage | Current Hp {Health}");
        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }


    private void HpBarAdjust() 
    {
        hpBar.value = (float)Health / (float)maxHealth;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

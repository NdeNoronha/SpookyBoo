using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetPPT()
    {
        return Random.Range(0, 3);
    }

    public int EnemyLife
    {
        get { return life; }
        set { life = value; }
    }

    public int EnemyDamage
    {
        get { return damage; }
        set { damage = value; }
    }
}

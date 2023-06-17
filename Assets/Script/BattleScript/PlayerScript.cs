using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
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

    public int PlayerLife
    {
        get { return life; }
        set { life = value; }
    }

    public int PlayerDamage
    {
        get { return damage; }
        set { damage = value; }
    }
}

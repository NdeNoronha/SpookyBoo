using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BattleScript : MonoBehaviour
{
    [SerializeField] Animator adiAnimator, atkAnimator, pptAnimator;
    [SerializeField] private PptScript pptScript;
    [SerializeField] public int pptValue;
    [SerializeField] private string[] pptName;
    private string result;

    // Start is called before the first frame update
    void Start()
    {
        pptName = new string[3];

        pptName[0] = "PEDRA";
        pptName[1] = "PAPEL";
        pptName[2] = "TESOURA";

        pptScript = GameObject.Find("Canvas").transform.Find("PPT").GetComponent<PptScript>();
        adiAnimator = GameObject.Find("ADI").GetComponent<Animator>();
        atkAnimator = GameObject.Find("ATK").GetComponent<Animator>();
        pptAnimator = GameObject.Find("Canvas").transform.Find("PPT").GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Ataque()
    {
        print("O jogador atacou!");
        ControlarADI(false);
        ControlarATK(true);
        ShowPPTOptions();
        
    }
    public void Defesa()
    {
        print("O jogador defendou!");
        
    }
    public void Item()
    {
        print("O jogador usou um item!");
    }


    private void ControlarADI(bool adi)
    {
        adiAnimator.SetBool("BaseButtons", adi);
    }

    private void ControlarATK(bool atk)
    {
        atkAnimator.SetBool("AtkON", atk);
    }

    private void ShowPPTOptions()
    {
        pptScript.ShowPPT();
        pptAnimator.SetBool("PptON", true);
    }

    public void EscolherPedra()
    {
        pptValue = 0;
        PPTResultado();
    }
    public void EscolherPapel()
    {
        pptValue = 1;
        PPTResultado();
    }
    public void EscolherTesoura()
    {
        pptValue = 2;
        PPTResultado();
    }

    private void PPTResultado()
    {

        int enemyValue = Random.Range(0, 3);
        switch(pptValue)
        {
            case 0:
                if(enemyValue == 0)
                {
                    result = "EMPATE";
                }else if(enemyValue == 1)
                {
                    result = "PERDEU";
                }else
                {
                    result = "VENCEU";
                }
                break;
            case 1:
                if (enemyValue == 1)
                {
                    result = "EMPATE";
                }
                else if (enemyValue == 2)
                {
                    result = "PERDEU";
                }
                else
                {
                    result = "VENCEU";
                }
                break;
            case 2:
                if (enemyValue == 2)
                {
                    result = "EMPATE";
                }
                else if (enemyValue == 0)
                {
                    result = "PERDEU";
                }
                else
                {
                    result = "VENCEU";
                }
                break;
        }

        Debug.Log("Jogador escolheu: " + pptName[pptValue] + " Inimigo escolheu: " + pptName[enemyValue] + ", o Jogador " + result);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class BattleController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI roundTxt;
    [SerializeField] private EnemyScript enemyScript;
    [SerializeField] private PlayerScript playerScript;
    [Header("Valores")]
    [SerializeField] private int pptValue;
    [SerializeField] private int roundValue;
    [Header("Nomeclatura")]
    [SerializeField] private string[] pptName;


    private ActionGroupScript aGroup;
    private bool isPlayerAtk, isPlayerDef;
    

    private void Awake()
    {
        aGroup = GameObject.Find("ActionGroup").GetComponent<ActionGroupScript>();
        enemyScript = FindObjectOfType<EnemyScript>();
        playerScript = FindObjectOfType<PlayerScript>();

        pptName = new string[3];
        isPlayerAtk = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        pptName[0] = "PEDRA";
        pptName[1] = "PAPEL";
        pptName[2] = "TESOURA";

        aGroup.GoToEnd();
    }

    // Update is called once per frame
    void Update()
    {
        roundTxt.text = "ROUND " + roundValue;
    }

    public void PPTChoice(int pptValue)
    {
        this.pptValue = pptValue;
        ResultPPT();
    }

    private void ResultPPT()
    {
        int enemyValue = enemyScript.GetPPT();
        string result = "";

        switch(pptValue)
        {
            case 0:
                if(enemyValue == 0)
                {
                    result = " nada ocorreu!";
                }else if(enemyValue == 1)
                {
                    result = " o Inimigo n�o levou dano";
                }else
                {
                    PlayerAtk(0);
                    //enemyScript.EnemyLife -= playerScript.PlayerDamage;
                    result = ", o Inimigo est� com: " + enemyScript.EnemyLife + " de vida!";
                }
                break;
            case 1:
                if (enemyValue == 1)
                {
                    result = " nada ocorreu!";
                }
                else if (enemyValue == 2)
                {
                    result = " o Inimigo n�o levou dano";
                }
                else
                {
                    //enemyScript.EnemyLife -= playerScript.PlayerDamage;
                    result = ", o Inimigo est� com: " + enemyScript.EnemyLife + " de vida!";
                }
                break;
            case 2:
                if (enemyValue == 2)
                {
                    result = " nada ocorreu!";
                }
                else if (enemyValue == 0)
                {
                    result = " o Inimigo n�o levou dano";
                }
                else
                {
                    //enemyScript.EnemyLife -= playerScript.PlayerDamage;
                    result = ", o Inimigo est� com: " + enemyScript.EnemyLife + " de vida!";
                }
                break;
        }
        if(roundValue < 6)
        {
            roundValue++;
        }
        else
        {
            Debug.Log("Fim de Jogo!");
        }
        
        Debug.Log("Jogador escolheu: " + pptName[pptValue] + " Inimigo escolheu: " + pptName[enemyValue] + result);
    }

    public void PlayerAtk([Tooltip("0 � vit�ria, 1 � empate e 2 � derrota")]int result)
    {
        switch(result)
        {
            case 0:
                break;
        }
            isPlayerAtk = false;
            enemyScript.EnemyLife -= playerScript.PlayerDamage;
            print("Chegou aqui");
    }
    public void PlayerDef()
    {

        if (!isPlayerAtk)
        {
            playerScript.PlayerLife -= enemyScript.EnemyDamage;
        }
        else
        {
            isPlayerAtk = false;
        }
    }
}

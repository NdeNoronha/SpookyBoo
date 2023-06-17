using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionGroupScript : MonoBehaviour
{
    [Header("Posicionamento do UI")]
    [SerializeField] private Vector3 origin;
    [SerializeField] private Vector3 end;
    [Header("Atributos do UI")]
    [SerializeField] private float duration;
    [Header("PPT")]
    [SerializeField] private bool ppt;
    [SerializeField] private float distancePPT;

    private void Awake()
    {
        if (ppt)
        {
            origin.y = GameObject.Find("Canvas").transform.position.y - distancePPT;
            end.y = origin.y + distancePPT;
        }
        origin.x = GameObject.Find("Canvas").transform.position.x;
        end.x = GameObject.Find("Canvas").transform.position.x;
        transform.position = origin;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToEnd()
    {

        this.transform.DOMove(end, duration);

        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(1, duration);
    }

    public void ReturnToOrigin()
    {

        this.transform.DOMove(origin, duration);

        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(0, duration);
    }
}

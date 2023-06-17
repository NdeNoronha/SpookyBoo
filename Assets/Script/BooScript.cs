using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BooScript : MonoBehaviour
{
    [SerializeField] private float durationMove;
    [SerializeField] private float minTime, maxTime;
    [SerializeField] private GameObject explosion;
    private MusicScript musicScript;

    private BalloonController bControler;

    private void Awake()
    {
        musicScript = FindObjectOfType<MusicScript>();
        bControler = FindObjectOfType<BalloonController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        BooMovement();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BooMovement()
    {
        float duration = Random.Range(2, durationMove);
        transform.DOMove(new Vector3(0, 0.5f, 0), duration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(new Vector3(0, 360, 0), durationMove * 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

        float time = Random.Range(minTime, maxTime);
        Destroy(gameObject, time);
    }

    public void OnBooTouch()
    {
        GameObject vfx = Instantiate(explosion, transform.position, transform.rotation);
        musicScript.PlayBoo();
        bControler.IncreaseScore();
        Destroy(gameObject);
        Destroy(vfx, 2);

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;
using System.IO;



public class BalloonController : MonoBehaviour
{
    public GameObject balloonPrefab;
    public GameObject textoObject;
    public float balloonLifetime = 5f;
    public float timeBetweenBalloons = 1f;
    public float timer = 35f;
    private float currentTime;
    public int scorePontos;
    private int highScore;
    public TextMeshProUGUI txtScore, txtTimer;
    private ARPlaneManager planeManager;
    private GameObject currentBalloon;
    private bool startGame;

    private void Start()
    {
        currentTime = timer;
        planeManager = FindObjectOfType<ARPlaneManager>();

        StartCoroutine(SpawnBalloon());
        Invoke("StartGame", 3);
    }

    private void Update()
    {
        TouchBoo();
        if(startGame)
        {
            currentTime -= Time.deltaTime;
        }
        if (currentTime <= 0)
        {
            SavePoints();
            currentTime = timer;
            SceneScript.ChangeSceneMenu();
        }
        txtTimer.text = currentTime.ToString("F0");
    }

    private IEnumerator SpawnBalloon()
    {
        while (true)
        {
            if (currentBalloon == null)
            {
                if (planeManager != null && planeManager.trackables.count > 0)
                {
                    List<ARPlane> planes = new List<ARPlane>();

                    foreach (var plane in planeManager.trackables)
                    {
                        if (plane.trackingState == TrackingState.Tracking)
                        {
                            planes.Add(plane);
                        }
                    }

                    if (planes.Count > 0)
                    {
                        ARPlane randomPlane = planes[UnityEngine.Random.Range(0, planes.Count)];

                        Vector3 randomPosition = GetRandomPositionOnPlane(randomPlane);

                        currentBalloon = Instantiate(balloonPrefab, randomPosition, Quaternion.identity);
                    }
                }
            }

            yield return new WaitForSeconds(timeBetweenBalloons);
        }
    }

    private Vector3 GetRandomPositionOnPlane(ARPlane plane)
    {
        Vector2 planeSize = new Vector2(plane.size.x, plane.size.y);
        Vector2 randomPoint = UnityEngine.Random.insideUnitCircle * planeSize * 0.5f;
        Vector3 position = plane.center + new Vector3(randomPoint.x, 0f, randomPoint.y);

        return position;
    }

    private void TouchBoo()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "boo")
                {
                    hit.collider.GetComponent<BooScript>().OnBooTouch();
                }
            }
        }
    }

    private void UpdateScore()
    {
        txtScore.text = scorePontos.ToString();
    }

    public void IncreaseScore()
    {
        scorePontos++;
        UpdateScore();
    }

    private void StartGame()
    {
        startGame = true;
        textoObject.SetActive(startGame);
    }

    private void SavePoints()
    {
        if(scorePontos > highScore)
        {
            highScore = scorePontos;
            PlayerPrefs.SetInt("Highscore", highScore);
            PlayerPrefs.Save();

        }
        
    }

}

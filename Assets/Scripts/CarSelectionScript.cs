using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelectionScript : MonoBehaviour
{
    [Header("Buttons and Canvas")]
    public Button nextButton;
    public Button previousButton;

    [Header("Buttons and Canvas")]
    public GameObject CarSelectionCanvas;
    public GameObject playCanvas;

    private int currentCar;
    private int selectedCar;
    public GameObject[] carList;

    private void Awake()
    {
        CarSelectionCanvas.SetActive(false);
        chooseCar(0); // to enable the first car when the game is started
    }

    private void Start()
    {

        currentCar = PlayerPrefs.GetInt("CarSelected"); // jab doosri baar game start karenge toh last baar jo car select ki thi wahi dikhegi
        // inserting car models in carList array
        carList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            carList[i] = transform.GetChild(i).gameObject;
        }

        //keeping track of current car
        foreach (GameObject go in carList)
        {
            go.SetActive(false);
        }

        if (carList[currentCar])
        {
            carList[currentCar].SetActive(true);
        }
    }

    private void chooseCar(int index)
    {

        previousButton.interactable = (currentCar != 0);
        nextButton.interactable = (currentCar != transform.childCount - 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }

    public void switchCar(int switchCars)
    {
        currentCar += switchCars;
        chooseCar(currentCar);
    }

    //public void playGame()
    //{
    //    PlayerPrefs.SetInt("CarSelected", currentCar); // yaha jo car select karke hum game khelenge usko save kar rhe hain taki
    //                                                   // jab hum game khelne ke baad game mode exit krke waps se game mode m aaye toh wahi car hume mile jo pehle thi
    //    SceneManager.LoadScene("scene_day"); // using this to switch from one scene to another scene
    //}

    public void playButton()
    {
        CarSelectionCanvas.SetActive(true);
        playCanvas.SetActive(false);
    }

    public void StartGame()
    {
        selectedCar = currentCar + 1;
        SceneManager.LoadScene("Scene" + selectedCar);
        CarSelectionCanvas.SetActive(false);
        playCanvas.SetActive(false);
    }
}

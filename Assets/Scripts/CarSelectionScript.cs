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
        SoundScript.PlaySound("Button");
        currentCar += switchCars;
        chooseCar(currentCar);
    }

    public void playButton()
    {
        StartCoroutine(ActivateCanvasWithDelay());
    }

    public void StartGame()
    {
        Debug.Log("Start playing Sound");
        SoundScript.PlaySound("StartButtonSound");
        selectedCar = currentCar + 1;
        SceneManager.LoadScene("Scene" + selectedCar);
        CarSelectionCanvas.SetActive(false);
        playCanvas.SetActive(false);
    }

    private IEnumerator ActivateCanvasWithDelay()
    {
        SoundScript.PlaySound("Button");
        yield return new WaitForSeconds(0.8f); // Wait for the specified delay
        CarSelectionCanvas.SetActive(true);
        playCanvas.SetActive(false);
    }

}

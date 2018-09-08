using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;

    public List<Rubbish> rubbishes = new List<Rubbish>();
    public bool onRedBin = false;
    public bool onGreenBin = false;
    public bool onYellowBin = false;

    public GameObject screenOne;
    public GameObject screenTwo;

    void Awake() {
        instance = this;
    }

    public void Destroy(Rubbish rubbish) {
        rubbishes.Remove(rubbish);
        Destroy(rubbish.gameObject);

        if (rubbishes.Count == 0) {
            screenOne.SetActive(false);
            screenTwo.SetActive(true);
        }
    }

    public void Restart () {
        SceneManager.LoadSceneAsync("SampleScene");
    }
}

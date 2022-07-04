using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingController : MonoBehaviour
{

    [SerializeField] private GameObject loadingScreen;
    
    public void StartLoading()
    {
        this.loadingScreen.SetActive(true);
    }

    public void EndLoading()
    {
        this.loadingScreen.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionSystem : Singleton<TransitionSystem>
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image image;
    private TransitionState _state;

    private void Start()
    {
        SceneManager.sceneLoaded += OutTransition;
    }

    public void LoadSceneWithTransition(string scene)
    {
        InTransition(scene);
    }

    void OutTransition(Scene scene, LoadSceneMode mode)
    {
        
    }
    
    void InTransition(string scene)
    {
        
    }
}

public enum TransitionState{
    NoTransition,
    FadeIn,
    FadeOut,
    TransitionMiddle
}
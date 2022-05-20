using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiController : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] confettiParticles;

    private void Awake()
    {
        GameManager.Instance.onGameOver.AddListener(OnGameOver);
    }

    private void OnGameOver(bool success)
    {
        if (success)
        {
            PlayConfettiParticles();
        }
    }

    private void PlayConfettiParticles()
    {
        for (int i = 0; i < confettiParticles.Length; i++)
        {
            confettiParticles[i].gameObject.SetActive(true);
            confettiParticles[i].Play();
        }
    }
}

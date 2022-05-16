using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour
{
    public ParticleSystem ParticleFire;
    public void StartButton()
    {
        StartCoroutine(startFire());
    }

    private IEnumerator startFire()
    {
        ParticleFire.Play();
        yield return new WaitForSeconds(30);
        ParticleFire.Stop();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}

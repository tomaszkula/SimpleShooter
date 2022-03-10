using UnityEngine;

public class TSG_Particle : MonoBehaviour
{
    [Header("Components")]
    ParticleSystem myParticleSystem = null;

    private void Awake()
    {
        myParticleSystem = GetComponent<ParticleSystem>();

        ParticleSystem.MainModule _mainModule = myParticleSystem.main;
        _mainModule.stopAction = ParticleSystemStopAction.Callback;
    }

    private void OnParticleSystemStopped()
    {
        gameObject.SetActive(false);
    }

    public void Play()
    {
        myParticleSystem?.Play(true);
    }
}

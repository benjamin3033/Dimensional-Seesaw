using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PlayerHealth : MonoBehaviour
{
    public float Health = 100;
    public PostProcessVolume _volume;
    Vignette _vignette;

    public float HitDuration = 1.25f;

    // Start is called before the first frame update
    void Start()
    {
        _volume.profile.TryGetSettings<Vignette>(out _vignette);
    }

    // Update is called once per frame
    void Update()
    {
        Health -= Time.deltaTime;

        if (Health > 100)
        {
            Health = 100;
        }

        if (Health <= 0)
        {
            // Die
        }
    }

    public void TakeDamage(int amount)
    {
        StartCoroutine(FlashFX());
        Health -= amount;
    }

    IEnumerator FlashFX()
    {
        float alpha = 0.5f;
        while (alpha > 0)
        {
            alpha -= 1 / HitDuration * Time.deltaTime;
            _vignette.intensity.value = alpha;
            yield return new WaitForEndOfFrame();
        }
    }
}
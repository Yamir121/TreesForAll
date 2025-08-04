using Oculus.Interaction;
using Sirenix.OdinInspector;
using UnityEngine;

    //Wateringcan object the player can select in scene
public class WateringCan : Selectable
{
    [SerializeField] private ParticleSystem streamParticles;
    [SerializeField] private Transform streamOrigin;
    [MinMaxSlider(-1f, 1f)][SerializeField] private Vector2 streamActivationRange;

    private void Update()
    {
        float zAngleNormalized = GetNormalizedZAngle();
        if (zAngleNormalized <= streamActivationRange.x || zAngleNormalized >= streamActivationRange.y)
        {
            if (!streamParticles.isPlaying)
            {
                streamParticles.Play();
            }
        }
        else
        {
            if (streamParticles.isPlaying)
            {
                streamParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
        }
    }

    private float GetNormalizedZAngle()
    {
        Vector3 up = streamOrigin.up;
        float angle = Mathf.Atan2(up.y, up.x) * Mathf.Rad2Deg;

        float normalized = angle / 180f;
        return Mathf.Clamp(normalized, -1f, 1f);
    }

public override void Select(InteractionManager.InteractionType type, InteractionManager.Hand hand, Holdable holdable)
    {
        
    }
}

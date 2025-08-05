using Oculus.Interaction;
using Sirenix.OdinInspector;
using UnityEngine;

//Wateringcan object the player can select in scene and use on plants in the grid.
public class WateringCan : Selectable
{
    [TitleGroup("References")]
    [SerializeField] private ParticleSystem streamParticles;
    [SerializeField] private Transform streamOrigin;
    [MinMaxSlider(-1f, 1f)][SerializeField] private Vector2 streamActivationRange;

    private void Update()
    {
        //Activate water visuals with the right angle
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

    /// <summary>
    /// Gets the Z angle normalized between -1 and 1 (-1 being -180 and 1 being 180 degrees)
    /// </summary>
    /// <returns></returns>
    private float GetNormalizedZAngle()
    {
        Vector3 up = streamOrigin.up;
        float angle = Mathf.Atan2(up.y, up.x) * Mathf.Rad2Deg;

        float normalized = angle / 180f;
        return Mathf.Clamp(normalized, -1f, 1f);
    }

    /// <summary>
    /// Waters plants giving them a short grow boost, effect depends on plant type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="hand"></param>
    /// <param name="holdable"></param>
    /// <exception cref="System.NotImplementedException"></exception>
public override void Select(InteractionManager.InteractionType type, InteractionManager.Hand hand, Holdable holdable)
    {
        throw new System.NotImplementedException();
    }
}

using UnityEngine;
using Zone.Core.Utils;

public class Universe : Singleton<Universe>
{
    // [SerializeField]public float GRAVITY_CONSTANT = 0.000000000006674f;
    [SerializeField] public float GRAVITY_CONSTANT = 0.000000006674f;

    [SerializeField] public GravitationalBody[] planets;

    public override void Awake() 
    {
        base.Awake();
        planets = FindObjectsOfType<GravitationalBody>();
        Time.timeScale = 5f; // TODO remove, this for faster debugging 
    }

    public void UpdateAllVel()
    {
        foreach (var planet in planets)
        {
            planet.UpdateVel(planets);
        }
    }

    private void FixedUpdate() 
    {
        UpdateAllVel();    
    }
}

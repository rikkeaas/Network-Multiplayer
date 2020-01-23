
using UnityEngine;

public class PlayerHealth : Bolt.EntityBehaviour<ICustomCubeState>
{
    public int localHealth = 3;

    // Same thing as start
    public override void Attached()
    {
        state.Health = localHealth;

        state.AddCallback("Health", HealthCallback);
    }

    private void HealthCallback()
    {
        localHealth = state.Health;

        if (localHealth <= 0)
        {
            // BoltNetwork.Destroy(gameObject);
            
        }
    }

    public bool IsAlive()
    {
        return localHealth > 0;
    }

    void OnTriggerEnter(Collider other)
    {
        state.Health -= 1;
        BoltNetwork.Destroy(other.gameObject);
    }
    // public void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         // state.Health -= 1;
    //     }
    // }
}

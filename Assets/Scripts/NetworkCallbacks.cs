
using UnityEngine;

[BoltGlobalBehaviour]
public class NetworkCallbacks : Bolt.GlobalEventListener
{
    public override void SceneLoadLocalDone(string scene)    
    {
        var spawnPosition = new Vector3(Random.Range(-8, 8), 0.5f, Random.Range(-8, 8));

        BoltNetwork.Instantiate(BoltPrefabs.Player, spawnPosition, Quaternion.identity);
    }

}

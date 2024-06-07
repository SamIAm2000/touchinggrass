using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public GameObject sheepPrefab; // Reference to the sheep prefab
    public Transform handPosition; // The position where sheep will be spawned

    public void OnSelectorActivated()
    {
        RemoveAllSheep();
        SpawnSheep(7, (float)0.5);
    }

    private void RemoveAllSheep()
    {
        GameObject[] sheepArray = GameObject.FindGameObjectsWithTag("Sheep");

        foreach (GameObject sheep in sheepArray)
        {
            Destroy(sheep);
        }
    }

    private void SpawnSheep(int numSheep, float spawnRadius)
{
    // Spawn multiple sheep
    for (int i = 0; i < numSheep; i++)
    {
        // Calculate a random position within the spawn radius
        Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
        Vector3 spawnPosition = handPosition.TransformPoint(randomOffset);

        // Spawn the sheep at the calculated position
        Quaternion spawnRotation = Quaternion.identity; // No rotation for simplicity
        GameObject newSheep = Instantiate(sheepPrefab, spawnPosition, spawnRotation);
        newSheep.tag = "Sheep";

        // Optionally, you can adjust the newly instantiated sheep further if needed
        // For example, you might want to set its parent or adjust its scale

        // Instantiate children of the sheepPrefab under the newly created sheep object
        foreach (Transform child in sheepPrefab.transform)
        {
            Instantiate(child.gameObject, newSheep.transform);
        }
    }
}



}

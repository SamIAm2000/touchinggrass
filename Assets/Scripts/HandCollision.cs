// using UnityEngine;

// public class HandCollision : MonoBehaviour
// {
//     public ScoreSystem score;
//     public int scoreValue = 10;

//     void OnTriggerEnter(Collider other)
//     {
//         if (other.gameObject.CompareTag("Grass"))
//         {
//             // Increment score
//             score.AddScore(scoreValue);
//         }
//     }

// }
using UnityEngine;

public class HandCollision : MonoBehaviour
{
    public ScoreSystem score;
    public int scoreValue = 10;

    public OVRSkeleton OVRSkeleton; // Reference to the OVRHand component

    void OnTriggerEnter(Collider other)
    {
        if (OVRSkeleton.IsDataHighConfidence && other.gameObject.CompareTag("Grass"))
        {
            // Increment score only if hand tracking data is high confidence
            score.AddScore(scoreValue);
        }
    }
}

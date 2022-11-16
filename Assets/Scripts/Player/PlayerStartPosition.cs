using Infrastructure.Data;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStartPosition : MonoBehaviour, ISavedProgress
{
    [SerializeField]
    NavMeshAgent _agent;

    public void LoadProgress(PlayerProgress progress)
    {
        _agent.enabled = false;
        if (progress.PositionOnLevel.Position != null)
            transform.position = progress.PositionOnLevel.Position.ToUnityVector();
        else
        {
            Transform initialTransform = GameObject.FindGameObjectWithTag("InitialPoint").transform;
            transform.position = initialTransform.position;
            transform.rotation = initialTransform.rotation;
        }            
        _agent.enabled = true;
    }

    public void SaveProgress(PlayerProgress progress)
    {
        progress.PositionOnLevel.Position = transform.position.ToVectorData();
    }
}

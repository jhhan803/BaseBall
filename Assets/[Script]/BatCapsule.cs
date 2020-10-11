using UnityEngine;

public class BatCapsule : MonoBehaviour
{
	[SerializeField]
	private BatCapsuleFollower _batCapsuleFollowerPrefab;

	private void SpawnBatCapsuleFollower()
	{
		var follower = Instantiate(_batCapsuleFollowerPrefab);



		follower.transform.position = transform.position;
		follower.transform.localScale = transform.localScale*1.2f;
		follower.SetFollowTarget(this);
	}

	private void Start()
	{
		SpawnBatCapsuleFollower();
	}
}

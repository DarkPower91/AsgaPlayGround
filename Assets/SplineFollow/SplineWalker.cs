using UnityEngine;

public class SplineWalker : MonoBehaviour
{

	public BezierSpline spline;

	public float duration;
	public float maxDistance = 5.0f;

	public bool lookForward;

	public SplineWalkerMode mode;

	private float progress;
	private bool goingForward = true;

	private GameObject player = null;

    private void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
	{
		if(player != null && Vector2.Distance(player.transform.position, transform.position) > maxDistance)
        {
			return;
        }

		if (goingForward)
		{
			progress += Time.deltaTime / duration;
			if (progress > 1f)
			{
				if (mode == SplineWalkerMode.Once)
				{
					progress = 1f;
				}
				else if (mode == SplineWalkerMode.Loop)
				{
					progress -= 1f;
				}
				else
				{
					progress = 2f - progress;
					goingForward = false;
				}
			}
		}
		else
		{
			progress -= Time.deltaTime / duration;
			if (progress < 0f)
			{
				progress = -progress;
				goingForward = true;
			}
		}

		Vector3 position = spline.GetPoint(progress);
		transform.localPosition = position;

		if (lookForward)
		{
			Vector3 p = spline.GetDirection(progress);
			float rot_z = Mathf.Atan2(p.y, p.x) * Mathf.Rad2Deg;
			float sign = goingForward ? -1 : 1;
			transform.rotation = Quaternion.Euler(0f, 0f, rot_z + sign * 90);
		}
	}
}
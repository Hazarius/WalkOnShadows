using UnityEngine;


public static class Helpers 
{
	public static bool GetIntersection(out Vector3 intersectionPoint, Vector3 planeNormal, Vector3 planePosition, Ray ray)
	{
		if (Vector3.Dot(ray.direction, planeNormal) < 0f) {
			//calculate the distance between the linePoint and the line-plane intersection point
			var dotNumerator = Vector3.Dot((planePosition - ray.origin), planeNormal);
			var dotDenominator = Vector3.Dot(ray.direction, planeNormal);

			var length = dotNumerator / dotDenominator;

			var lineVec = ray.direction;
			var vector = lineVec * length;
			intersectionPoint = ray.origin + vector;

			return true;
		} else {
			intersectionPoint = Vector3.zero;
			return false;
		}
	}
}
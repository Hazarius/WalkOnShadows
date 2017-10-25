using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCastObject : MonoBehaviour
{
	const float MagnitudeTreshold = 0.0001f;
	Vector3 _initialPosition;

	List<Shadow> _shadows = new List<Shadow>();

	void Start ()
	{
		_initialPosition = transform.position;

		var lights = LightManager.Instance.Sources;

		foreach (var l in lights) {
			var clone = Instantiate(transform);
			var sc = clone.GetComponent<ShadowCastObject>();
			if (sc != null) {
				Destroy(sc);
			}
			var spRender = clone.GetComponent<SpriteRenderer>();
			if (spRender != null) {
				spRender.color = Color.black * 0.6f;
			}
			var shadow = clone.gameObject.AddComponent<Shadow>();
			shadow.Owner = this.transform;
			clone.name = transform.name + "_shadow_from_"+l.name;
			shadow.Light = l;
			_shadows.Add(shadow);
			WorldManager.Instance.Append(clone);
		}
		var selfCollider = GetComponent<PolygonCollider2D>();
		if (selfCollider != null) {
			Destroy(selfCollider);
		}

		UpdateShadow();
	}

	void Update()
	{
		if (Vector3.SqrMagnitude(transform.position - _initialPosition) > MagnitudeTreshold) {
			_initialPosition = transform.position;
			UpdateShadow();
		}
	}

	void UpdateShadow()
	{
		var mainPlaneTr = WorldManager.Instance.MainPlane.transform;
		foreach(var shadow in _shadows) {
			var lightDist = shadow.Light.transform.position.z - mainPlaneTr.position.z;
			var objDist = shadow.Light.transform.position.z - shadow.Owner.transform.position.z;
			var lightRay = new Ray(shadow.Light.transform.position, (shadow.Owner.transform.position - shadow.Light.transform.position).normalized);
			Vector3 intersection;
			if (Helpers.GetIntersection(out intersection, mainPlaneTr.forward, mainPlaneTr.position, lightRay ) && objDist > lightDist ) {
				if (!shadow.gameObject.activeSelf) {
					shadow.gameObject.SetActive(true);
				}
				shadow.transform.position = intersection;
				var scaleFactor = lightDist / objDist;

				shadow.transform.localScale = shadow.Owner.transform.localScale * scaleFactor;
			} else {
				shadow.gameObject.SetActive(false);
			}
		}
	}
}

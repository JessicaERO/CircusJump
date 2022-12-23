﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	[SerializeField]
	GameObject dustCloud;

	void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.gameObject.tag.Equals ("Platform"))
			Instantiate (dustCloud, transform.position, dustCloud.transform.rotation);
	}
}

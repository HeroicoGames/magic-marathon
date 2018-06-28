using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class FloorEditModeTest {

	private GameObject floor;
	private Floor floorComponent;

	[SetUp]
	public void SetUp ()
	{
		floor = new GameObject ();
		floor.AddComponent <Floor> ();

		floorComponent = floor.GetComponent <Floor> ();
	}

	[Test]
	public void TestConveyor ()
	{
		Assert.That ( floorComponent.conveyor, Is.False );
	}

}

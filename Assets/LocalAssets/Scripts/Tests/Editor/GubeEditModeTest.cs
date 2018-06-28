using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;

using MagicMarathon.Utils;

// TODO: Implementar Substitute (o algo parecido) como hace en el blog de Unity para hacer mocks
// TODO: Implement Assert.Multiple when unity 3D support this: https://github.com/nunit/docs/wiki/Multiple-Asserts
public class GubeEditModeTest {

	private GameObject gube;
	private Gube gubeComponent;

	[SetUp]
	public void SetUp () 
	{
		gube = new GameObject ();
		gube.AddComponent <Gube> ();

		gubeComponent = gube.GetComponent <Gube> ();
	}

	[Test]
	public void TestCurrentColor () 
	{
		gubeComponent.CurrentColor = Properties.Color.Red;

		Assert.That (gubeComponent.CurrentColor, Is.EqualTo (Properties.Color.Red));
		Assert.That (gubeComponent.ColorChange, Is.True);
	}

	[Test]
	public void TestColorChange () 
	{
		Assert.That (gubeComponent.ColorChange, Is.False);	
	}

	[Test]
	public void TestSpeed()
	{
		Assert.That (gubeComponent.Speed, Is.EqualTo(2));

		gubeComponent.Speed = 4;
		Assert.That (gubeComponent.Speed, Is.EqualTo(4));
	}

	[Test]
	public void TestTouchCorrectFloor () 
	{
		Assert.That (
			gubeComponent.TouchCorrectFloor, 
			Is.EqualTo (Properties.TouchStatus.Neutral)
		);

		gubeComponent.TouchCorrectFloor = Properties.TouchStatus.Successful;
		Assert.That (
			gubeComponent.TouchCorrectFloor,
			Is.EqualTo (Properties.TouchStatus.Successful)
		);
	}

	[Test]
	public void TestCheckTouchCorrectFloor () 
	{
		gubeComponent.CurrentColor = Properties.Color.Blue;

		Assert.That (
			gubeComponent.CheckTouchCorrectFloor (Properties.Color.Blue), 
			Is.EqualTo (Properties.TouchStatus.Successful)
		);

		Assert.That (
			gubeComponent.CheckTouchCorrectFloor (Properties.Color.Green), 
			Is.EqualTo (Properties.TouchStatus.Failed)
		);

		Assert.That (
			gubeComponent.CheckTouchCorrectFloor (Properties.Color.White),
			Is.EqualTo (Properties.TouchStatus.Neutral)
		);
	}

}


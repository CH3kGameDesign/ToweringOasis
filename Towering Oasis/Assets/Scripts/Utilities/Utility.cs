using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
	public static T[] ShuffleArray<T>(T[] array, int seed)
	{

		System.Random prng = new System.Random(seed);

		//We loop thrugh the array and shuffle them with the random index
		// Array.length - 1: because the last iteration doesnt matter
			// See https://youtu.be/q7BL-lboRXo?t=1m2s for explanation
		for (int i = 0; i < array.Length - 1; i++)
		{
			int nRandomIndex = prng.Next(i, array.Length);
			T TempVariable = array[nRandomIndex];
			array[nRandomIndex] = array[i];
			array[i] = TempVariable;
		}

		return array;
	}
}

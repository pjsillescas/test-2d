using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TopDownRace
{
	public class InputControl : MonoBehaviour
	{

		//--inputs
		[HideInInspector]
		public Vector3 m_Movement;

		public static InputControl m_Main;
		private InputActions inputActions;

		void Awake()
		{
			m_Main = this;
			inputActions = new InputActions();
			inputActions.Enable();
		}

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			m_Movement = Vector3.ClampMagnitude(inputActions.Player.Move.ReadValue<Vector2>(), 1.0f);
		}
	}
}
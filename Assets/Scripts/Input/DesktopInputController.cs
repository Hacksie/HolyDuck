using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
	namespace Input
	{

		public class DesktopInputController : IInputController
		{

		
			public bool ShowMobileInput()
			{
				return false;
			}


			public Vector2 GetMovementAxis()
			{
				//return new Vector2(UnityEngine.Input.Get)
				return new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
			}

			public void ResetInput()
			{
				UnityEngine.Input.ResetInputAxes();
			}

			public bool StartButtonUp()
			{
				return UnityEngine.Input.GetButtonUp("Start");
			}

			public bool SelectButtonUp()
			{
				return UnityEngine.Input.GetButtonUp("Select");
			}

			public bool AButtonUp()
			{
				throw new System.NotImplementedException();
			}

			public bool BButtonUp()
			{
				throw new System.NotImplementedException();
			}

			public bool XButtonUp()
			{
				throw new System.NotImplementedException();
			}

			public bool YButtonUp()
			{
				throw new System.NotImplementedException();
			}

			public bool UpButtonUp()
			{
				return UnityEngine.Input.GetButtonUp("Up");
			}

			public bool DownButtonUp()
			{
				return UnityEngine.Input.GetButtonUp("Down");
			}

			public bool LeftButtonUp()
			{
				return UnityEngine.Input.GetButtonUp("Left");
			}

			public bool RightButtonUp()
			{
				return UnityEngine.Input.GetButtonUp("Right");
			}
		}
	}
}
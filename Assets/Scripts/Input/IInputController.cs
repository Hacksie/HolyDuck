using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign.Input
{
    public interface IInputController
    {
        bool ShowMobileInput();
        Vector2 GetMovementAxis();
        bool UpButtonUp();
        bool DownButtonUp();
        bool LeftButtonUp();
        bool RightButtonUp();

        bool StartButtonUp();
        bool SelectButtonUp();
        void ResetInput();
        bool AButtonUp();
        bool BButtonUp();
        bool XButtonUp();
        bool YButtonUp();
    }

}
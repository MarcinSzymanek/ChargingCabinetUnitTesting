﻿using Cabinet_Library.ChargeControl;

namespace Cabinet_Library.ChargeControl.States;

public class StateFullyCharged : StateBase
{
    private const StateID Id = StateID.FULLY_CHARGED;
    private const string Message = "Device fully charged.";
    public StateFullyCharged(IUsbCharger charger, ChargeControl context) : base(charger, context, Id)
    {
        StopCharge();
        DisplayMessage = Message; ;
    }

    public sealed override void MonitorCurrentLevel(double current)
    {
        if (current > ThresholdError)
        {
            StopCharge();
            Context.ChangeState(new StateError(Context));
        }
    }
}
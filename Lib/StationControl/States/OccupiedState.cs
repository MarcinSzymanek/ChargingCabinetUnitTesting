﻿using Cabinet_Library.ChargeControl;
using Cabinet_Library.ChargeControl.States;
using Cabinet_Library.Display;
using Cabinet_Library.Door;

namespace Cabinet_Library.StationControl.States;

public class OccupiedState : StationStateBase
{
    private readonly StationStateID stateId = StationStateID.OCCUPIED;

    public OccupiedState(IStationControl context, IChargeControl chargeControl, IDisplay display, IDoor door,
        int? savedId)
        : base(context, chargeControl, display, door, savedId)
    {
        StateID = stateId;
    }

    public override void OnRfidDetected(int id)
    {
        if (id == SavedId)
        {
            Door.UnlockDoor();
            Context.LogDoorUnlocked(id);
            Display.SetMainText("Remove your phone, peasant");
            Context.ChargingFinished();
        }
        else
        {
            Display.SetMainText("Incorrect RFID!");
        }
    }
}
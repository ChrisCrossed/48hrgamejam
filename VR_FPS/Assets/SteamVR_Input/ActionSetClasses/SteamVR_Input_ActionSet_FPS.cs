//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Valve.VR
{
    using System;
    using UnityEngine;
    
    
    public class SteamVR_Input_ActionSet_FPS : Valve.VR.SteamVR_ActionSet
    {
        
        public virtual SteamVR_Action_Vector2 Movement
        {
            get
            {
                return SteamVR_Actions.fPS_Movement;
            }
        }
        
        public virtual SteamVR_Action_Skeleton SkeletonLeftHand
        {
            get
            {
                return SteamVR_Actions.fPS_SkeletonLeftHand;
            }
        }
        
        public virtual SteamVR_Action_Boolean RightHandTrigger
        {
            get
            {
                return SteamVR_Actions.fPS_RightHandTrigger;
            }
        }
        
        public virtual SteamVR_Action_Boolean LeftHandTrigger
        {
            get
            {
                return SteamVR_Actions.fPS_LeftHandTrigger;
            }
        }
    }
}

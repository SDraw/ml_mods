﻿using System.Linq;
using System.Reflection;
using UnhollowerRuntimeLib.XrefScans;

namespace ml_lme
{
    static class MethodsResolver
    {
        static MethodInfo ms_isInVRMode = null;
        /*static MethodInfo ms_setAvatarIntParam = null;
        static MethodInfo ms_setAvatarFloatParam = null;
        static MethodInfo ms_setAvatarBoolParam = null;*/

        public static void ResolveMethods()
        {
            // static bool VRCTrackingManager.IsInVRMode()
            if(ms_isInVRMode == null)
            {
                var l_methodsList = typeof(VRCTrackingManager).GetMethods().Where(m =>
                    m.Name.StartsWith("Method_Public_Static_Boolean_") && (m.ReturnType == typeof(bool)) && !m.GetParameters().Any() &&
                    XrefScanner.UsedBy(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(AvatarDebugConsole))).Any() &&
                    XrefScanner.UsedBy(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(VRCFlowManager))).Any() &&
                    XrefScanner.UsedBy(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(VRCInputManager))).Any() &&
                    XrefScanner.UsedBy(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(LocomotionInputController))).Any() &&
                    XrefScanner.UsedBy(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(VRCVrCamera))).Any()
                );

                if(l_methodsList.Any())
                {
                    ms_isInVRMode = l_methodsList.First();
                    Logger.DebugMessage("VRCTrackingManager.IsInVR -> VRCTrackingManager." + ms_isInVRMode.Name);
                }
                else
                    Logger.Warning("Can't resolve VRCTrackingManager.IsInVR");
            }

            /*
            // void AvatarPlayableController.SetAvatarIntParam(int paramHash, int val)
            if(ms_setAvatarIntParam == null)
            {
                var l_methodsList = typeof(AvatarPlayableController).GetMethods().Where(m =>
                    m.Name.StartsWith("Method_Public_Void_Int32_Int32_") && (m.ReturnType == typeof(void)) && (m.GetParameters().Count() == 2) &&
                    XrefScanner.XrefScan(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(VRC.Playables.AvatarParameter))).Any() &&
                    XrefScanner.UsedBy(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(AvatarAnimParamController))).Any() &&
                    XrefScanner.UsedBy(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(AvatarPlayableController))).Any() &&
                    XrefScanner.UsedBy(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(JawController))).Any() &&
                    XrefScanner.UsedBy(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(OVRLipSyncContextPlayableParam))).Any()
                );

                if(l_methodsList.Any())
                {
                    ms_setAvatarIntParam = l_methodsList.First();
                    Logger.DebugMessage("AvatarPlayableController.SetAvatarIntParam -> AvatarPlayableController." + ms_setAvatarIntParam.Name);
                }
                else
                    Logger.Warning("Can't resolve AvatarPlayableController.SetAvatarIntParam");
            }

            // void AvatarPlayableController.SetAvatarFloatParam(int paramHash, float val, bool debug = false)
            if(ms_setAvatarFloatParam == null)
            {
                var l_methodsList = typeof(AvatarPlayableController).GetMethods().Where(m =>
                    m.Name.StartsWith("Method_Public_Void_Int32_Single_Boolean_") && (m.ReturnType == typeof(void)) && (m.GetParameters().Count() == 3) &&
                    XrefScanner.XrefScan(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(VRC.Playables.AvatarParameter))).Any() &&
                    XrefScanner.UsedBy(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(AvatarAnimParamController))).Any() &&
                    XrefScanner.UsedBy(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(AvatarPlayableController))).Any()
                );

                if(l_methodsList.Any())
                {
                    ms_setAvatarFloatParam = l_methodsList.First();
                    Logger.DebugMessage("AvatarPlayableController.SetAvatarFloatParam -> AvatarPlayableController." + ms_setAvatarFloatParam.Name);
                }
                else
                    Logger.Warning("Can't resolve AvatarPlayableController.SetAvatarFloatParam");
            }

            // void AvatarPlayableController.SetAvatarBoolParam(int paramHash, bool val)
            if(ms_setAvatarBoolParam == null)
            {
                var l_methodsList = typeof(AvatarPlayableController).GetMethods().Where(m =>
                    m.Name.StartsWith("Method_Public_Void_Int32_Boolean_") && (m.ReturnType == typeof(void)) && (m.GetParameters().Count() == 2) &&
                    !XrefScanner.XrefScan(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(UnityEngine.Playables.PlayableExtensions))).Any() &&
                    XrefScanner.XrefScan(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(VRC.Playables.AvatarParameter))).Any() &&
                    XrefScanner.UsedBy(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(AvatarAnimParamController))).Any() &&
                    XrefScanner.UsedBy(m).Where(x => (x.Type == XrefType.Method) && (x.TryResolve()?.DeclaringType == typeof(AvatarPlayableController))).Any()
                );

                if(l_methodsList.Any())
                {
                    ms_setAvatarBoolParam = l_methodsList.First();
                    Logger.DebugMessage("AvatarPlayableController.SetAvatarBoolParam -> AvatarPlayableController." + ms_setAvatarBoolParam.Name);
                }
                else
                    Logger.Warning("Can't resolve AvatarPlayableController.SetAvatarBoolParam");
            }*/
        }

        public static MethodInfo IsInVRMode
        {
            get => ms_isInVRMode;
        }

        /*public static MethodInfo SetAvatarIntParam
        {
            get => ms_setAvatarIntParam;
        }

        public static MethodInfo SetAvatarFloatParam
        {
            get => ms_setAvatarFloatParam;
        }

        public static MethodInfo SetAvatarBoolParam
        {
            get => ms_setAvatarBoolParam;
        }*/
    }
}

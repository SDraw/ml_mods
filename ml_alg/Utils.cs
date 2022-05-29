﻿using UnityEngine;

namespace ml_alg
{
    static class Utils
    {
        // VRChat related
        static VRC.UI.Elements.QuickMenu ms_quickMenu = null;
        public static VRC.Player GetPlayerQM() // Thanks, now I hate this new menu
        {
            VRC.Player l_result = null;
            if(ms_quickMenu == null)
                ms_quickMenu = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)").GetComponent<VRC.UI.Elements.QuickMenu>();
            if((ms_quickMenu != null) && (ms_quickMenu.field_Private_UIPage_1 != null) && ms_quickMenu.field_Private_UIPage_1.isActiveAndEnabled)
            {
                var l_selectedUserQM = ms_quickMenu.field_Private_UIPage_1.TryCast<VRC.UI.Elements.Menus.SelectedUserMenuQM>();
                if((l_selectedUserQM != null) && (l_selectedUserQM.field_Private_IUser_0 != null))
                {
                    l_result = GetPlayerWithId(l_selectedUserQM.field_Private_IUser_0.prop_String_0);
                }
            }
            return l_result;
        }
        public static VRC.Player GetLocalPlayer() => VRC.Player.prop_Player_0;

        public static bool IsFriend(VRC.Player p_player)
        {
            bool l_result = false;
            if(p_player.field_Private_APIUser_0 != null)
                l_result = VRC.Core.APIUser.IsFriendsWith(p_player.field_Private_APIUser_0.id);
            if(p_player.field_Private_VRCPlayerApi_0 != null)
                l_result = (l_result && !p_player.field_Private_VRCPlayerApi_0.isLocal);
            return l_result;
        }

        public static Il2CppSystem.Collections.Generic.List<VRC.Player> GetPlayers() => VRC.PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0;

        public static VRC.Player GetPlayerWithId(string p_id)
        {
            return (VRC.Player)MethodsResolver.GetPlayerById?.Invoke(null, new object[] { p_id });
        }

        public static System.Collections.Generic.List<VRC.Player> GetFriendsInInstance()
        {
            System.Collections.Generic.List<VRC.Player> l_result = new System.Collections.Generic.List<VRC.Player>();
            var l_remotePlayers = GetPlayers();
            if(l_remotePlayers != null)
            {
                foreach(VRC.Player l_remotePlayer in l_remotePlayers)
                {
                    if((l_remotePlayer != null) && IsFriend(l_remotePlayer))
                        l_result.Add(l_remotePlayer);
                }
            }
            return l_result;
        }

        public static VRCTrackingManager GetVRCTrackingManager() => VRCTrackingManager.field_Private_Static_VRCTrackingManager_0;

        public static float GetTrackingScale() => GetVRCTrackingManager().transform.localScale.x;

        // Math extensions
        public static Matrix4x4 GetMatrix(this Transform p_transform, bool p_pos = true, bool p_rot = true, bool p_scl = false)
        {
            return Matrix4x4.TRS(p_pos ? p_transform.position : Vector3.zero, p_rot ? p_transform.rotation : Quaternion.identity, p_scl ? p_transform.localScale : Vector3.one);
        }
        public static Matrix4x4 AsMatrix(this Quaternion p_quat)
        {
            return Matrix4x4.Rotate(p_quat);
        }
    }
}

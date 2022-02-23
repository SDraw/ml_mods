﻿using System;

namespace ml_vsf
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    class VsfTracked : UnityEngine.MonoBehaviour
    {
        VRCPlayer m_player = null;
        RootMotion.FinalIK.IKSolverVR m_solver = null;

        float m_headHeight = 1f;

        public float HeadHeight
        {
            get => m_headHeight;
        }

        public VsfTracked(IntPtr ptr) : base(ptr) { }

        void Awake()
        {
            m_player = this.GetComponent<VRCPlayer>();
            m_player.field_Private_OnAvatarIsReady_0 += new Action(this.RecacheComponents);
        }

        // LateUpdate only
        public void UpdateHeadTransform(UnityEngine.Transform p_transform)
        {
            if((m_solver != null) && (m_solver.spine != null))
            {
                m_solver.spine.headPosition = p_transform.position;
                m_solver.spine.IKPositionHead = p_transform.position;
                m_solver.spine.headRotation = p_transform.rotation;
                m_solver.spine.IKRotationHead = p_transform.rotation;

                if(m_solver.spine.headTarget != null)
                {
                    m_solver.spine.headTarget.parent.position = p_transform.position;
                    m_solver.spine.headTarget.position = p_transform.position;

                    m_solver.spine.headTarget.rotation = p_transform.rotation;
                    m_solver.spine.headTarget.parent.rotation = p_transform.rotation;
                }
            }
        }

        void RecacheComponents()
        {
            if(m_player.field_Private_VRC_AnimationController_0.field_Private_VRIK_0 != null)
            {
                m_solver = m_player.field_Private_VRC_AnimationController_0.field_Private_VRIK_0.solver;
                if((m_solver.spine != null) && (m_solver.spine.headTarget != null) && (m_solver.spine.headTarget.parent != null))
                    m_headHeight = m_solver.spine.headTarget.parent.localPosition.y + m_solver.spine.headTarget.localPosition.y;
                else
                    m_headHeight = 1f;
            }
            else
            {
                m_solver = null;
                m_headHeight = 1f;
            }
        }
    }
}

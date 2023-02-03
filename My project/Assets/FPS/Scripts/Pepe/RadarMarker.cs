using Unity.FPS.AI;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.Pepe
{
    public class RadarMarker : MonoBehaviour
    {
        [Tooltip("Main marker image")] public Image MainImage;

        [Tooltip("Canvas group for the marker")]
        public CanvasGroup CanvasGroup;

        [Header("Enemy element")] [Tooltip("Default color for the marker")]
        public Color DefaultColor;

        [Tooltip("Alternative color for the marker")]
        public Color AltColor;
        EnemyController m_EnemyController;

        public void Initialize(RadarElement compassElement)
        {
            m_EnemyController = compassElement.transform.GetComponent<EnemyController>();

            if (m_EnemyController)
            {
                m_EnemyController.onDetectedTarget += DetectTarget;
                m_EnemyController.onLostTarget += LostTarget;

                LostTarget();
            }
        }

        public void DetectTarget()
        {
            MainImage.color = AltColor;
        }

        public void LostTarget()
        {
            MainImage.color = DefaultColor;
        }
    }
}

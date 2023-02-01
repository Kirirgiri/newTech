using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Pepe
{
    public class RadarElement : MonoBehaviour
    {
        [Tooltip("The marker on the compass for this element")]
        public RadarMarker CompassMarkerPrefab;

        [Tooltip("Text override for the marker, if it's a direction")]
        public string TextDirection;

        Radar m_Compass;

        void Awake()
        {
            m_Compass = FindObjectOfType<Radar>();
            DebugUtility.HandleErrorIfNullFindObject<UnityEngine.Compass, RadarElement>(m_Compass, this);

            var markerInstance = Instantiate(CompassMarkerPrefab);

            markerInstance.Initialize(this, TextDirection);
            m_Compass.RegisterCompassElement(transform, markerInstance);
        }

        void OnDestroy()
        {
            m_Compass.UnregisterCompassElement(transform);
        }
    }
}

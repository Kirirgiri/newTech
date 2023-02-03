using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Pepe
{
    public class RadarElement : MonoBehaviour
    {
        [Tooltip("The marker on the compass for this element")]

        Radar m_Compass;
        private bool awoken;

        void Awake()
        {
            m_Compass = FindObjectOfType<Radar>();
            DebugUtility.HandleErrorIfNullFindObject<UnityEngine.Compass, RadarElement>(m_Compass, this);

        }

        public void OnDestroy()
        {
            m_Compass.UnregisterCompassElement(transform);
            awoken = false;
        }

        public void OnCreate()
        {
            if(!awoken)
            {
                var i = 0;
                //depending on the tag, the dots will have different colors on radar screen
                switch (tag)
                {
                    case "target":
                    i = 0;
                    break;

                    case "pickups":
                    i=1;
                    break;
                }
                var markerInstance = Instantiate(m_Compass.markersPrefabs[i]);
                m_Compass.RegisterCompassElement(transform, markerInstance);
                awoken = true;
            }
        }
    }
}

using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;

namespace Unity.FPS.Pepe
{
    public class Radar : MonoBehaviour
    {
       public RectTransform CompasRect;
        public float HeightDifferenceMultiplier = 1.5f;
        public float MinScale = 0.5f;
        public float DistanceMinScale = 50f;
        public float CompasMarginRatio = 0.8f;

        [Tooltip("UI for Radar screen")]
        public RectTransform MarkerDirectionPrefab;
        public RadarMarker[] markersPrefabs;

        Transform m_PlayerTransform;
        Dictionary<Transform, RadarMarker> m_TargetDictionary = new Dictionary<Transform, RadarMarker>();

        float m_WidthMultiplier;
        float m_HeightOffset;

        void Awake()
        {
            PlayerCharacterController playerCharacterController = FindObjectOfType<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, UnityEngine.Compass>(playerCharacterController,
                this);
            m_PlayerTransform = playerCharacterController.transform;

            m_WidthMultiplier = CompasRect.rect.width/360f;
            m_HeightOffset = -CompasRect.rect.height / 2;
        }

        void Update()
        {
           // changed the axises to make it look like a topview radar
            foreach (var element in m_TargetDictionary)
            {
                float distanceRatio = 1;
                float heightDifference = 0;
                float widthDifference = 0;

                Vector3 directionVector = element.Key.transform.position - m_PlayerTransform.position;

                widthDifference = (directionVector.z) * HeightDifferenceMultiplier *-1;
                widthDifference = Mathf.Clamp(widthDifference, - CompasRect.rect.width / 2 * CompasMarginRatio,
                    CompasRect.rect.width / 2 * CompasMarginRatio);

                heightDifference = (directionVector.x) * HeightDifferenceMultiplier;
                heightDifference = Mathf.Clamp(heightDifference, - CompasRect.rect.height / 2 * CompasMarginRatio,
                    CompasRect.rect.height / 2 * CompasMarginRatio);

                distanceRatio = directionVector.magnitude / DistanceMinScale;
                distanceRatio = Mathf.Clamp01(distanceRatio);

                if(Mathf.Abs(directionVector.x)<DistanceMinScale)
                {
                    element.Value.CanvasGroup.alpha = 1;
                    element.Value.CanvasGroup.transform.localPosition = new Vector2(widthDifference+m_WidthMultiplier,
                        heightDifference + m_HeightOffset);
                    element.Value.CanvasGroup.transform.localScale =
                        Vector3.one * Mathf.Lerp(1, MinScale, distanceRatio);
                }else{
                    element.Value.CanvasGroup.alpha = 0;
                }
                if(Mathf.Abs(directionVector.x)<DistanceMinScale/2)
                {
                    
                }
                
            }
            //added rotation to the player dot as it would be confusing for the player once they rotate
            MarkerDirectionPrefab.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, m_PlayerTransform.rotation.y*90+180);//so the UI player would face the same direction as in reality
        }

        public void RegisterCompassElement(Transform element, RadarMarker marker)
        {
            marker.transform.SetParent(CompasRect);

            m_TargetDictionary.Add(element, marker);
        }

        public void UnregisterCompassElement(Transform element)
        {
            if (m_TargetDictionary.TryGetValue(element, out RadarMarker marker) && marker.CanvasGroup != null)
                Destroy(marker.CanvasGroup.gameObject);
            m_TargetDictionary.Remove(element);
        }
    }
}

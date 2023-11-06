using Cinemachine;
using UnityEngine;

namespace TwoDPlatformer
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCameraBase virtualCameraBase;
        private CinemachineConfiner2D cinemachineConfiner2D;

        public void Init()
        {
            virtualCameraBase = Instantiate(virtualCameraBase);
            virtualCameraBase.Follow = transform;
            SearchBounding();
        }

        private void SearchBounding()
        {
            virtualCameraBase.TryGetComponent(out cinemachineConfiner2D);
            cinemachineConfiner2D.m_BoundingShape2D = GameObject.Find(Constant.GameConst.CameraBound).GetComponent<Collider2D>();
        }
    }
}
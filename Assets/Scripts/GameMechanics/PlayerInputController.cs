using UnityEngine;
using UnityEngine.UI;

namespace GameMechanics
{
    public class PlayerInputController : MonoBehaviour, IInputController
    {
        [SerializeField] private GameObject objectToRotate;
        [SerializeField] private GameObject pushButton;
        [SerializeField] private Slider slider;
        [SerializeField] private RotateService _rotateService;

        public void DisablePlayerInput()
        {
            _rotateService.EnableRotation(false);
            pushButton.gameObject.SetActive(false);
            slider.gameObject.SetActive(false);
        }

        public void EnablePlayerInput()
        {
            _rotateService.EnableRotation(true, objectToRotate);
            pushButton.gameObject.SetActive(true);
            slider.gameObject.SetActive(true);
        }

        public void EnableInputService(bool enable)
        {
            _rotateService.EnableRotation(enable, objectToRotate);
        }
    }
}
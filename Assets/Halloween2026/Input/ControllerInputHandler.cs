using UnityEngine;
using UnityEngine.InputSystem;

namespace N_Awakening.Halloween
{
    public class ControllerInputHandler : MonoBehaviour
    {
        #region References

        [SerializeField] protected Player _myPlayer;

        #endregion

        #region CallbackContextMethods

        public void OnMove(InputAction.CallbackContext value)
        {
            _myPlayer.OnMove(value);
        }

        #endregion
    }
}


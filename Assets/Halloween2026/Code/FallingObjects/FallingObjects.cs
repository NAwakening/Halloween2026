using UnityEngine;

namespace N_Awakening.Halloween
{
    public class FallingObjects : MonoBehaviour
    {
        #region References

        [SerializeField] protected Rigidbody2D _rb;

        #endregion

        #region Knobs

        [SerializeField] protected float _fallSpeed;
        [SerializeField] protected bool _canRotate;

        #endregion

        #region LocalMethods

        protected void Fall()
        {
            _rb.linearVelocityY = -_fallSpeed;
        }

        protected void Rotate()
        {
            if (_canRotate)
                _rb.angularVelocity = -_fallSpeed * 50;
        }

        #endregion

        #region UnityMethods

        void Update()
        {
            Fall();
            Rotate();
        }

        #endregion
    }
}
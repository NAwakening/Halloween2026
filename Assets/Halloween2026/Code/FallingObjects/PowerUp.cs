using UnityEngine;

namespace N_Awakening.Halloween
{
    public enum PowerUps
    {
        SIZE,
        MULTIPLIER,
        SHIELD,
        EXTRALIFE
    }
    public class PowerUp : FallingObjects
    {
        #region Knobs

        [SerializeField] protected PowerUps powerUp;

        #endregion

        #region UnityMethods

        void Update()
        {
            Fall();
            Rotate();
        }

        #endregion

        #region GettersSetters

        public PowerUps GetPowerUP
        {
            get { return powerUp; }
        }

        #endregion
    }
}


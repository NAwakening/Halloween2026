using UnityEngine;

namespace N_Awakening.Halloween
{
    public class Candy : FallingObjects
    {
        #region Knobs

        [SerializeField] int _score;

        #endregion

        #region UnityMethods
       
        void Update()
        {
            Fall();
            Rotate();
        }

        #endregion

        #region GettersAndSetters

        public int GetScore
        {
            get { return _score; }
        }

        #endregion
    }
}
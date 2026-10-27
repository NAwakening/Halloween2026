using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

namespace N_Awakening.Halloween
{
    public class Player : MonoBehaviour
    {
        #region References

        [SerializeField] Rigidbody2D _rb;
        [SerializeField] Manager _manager;
        [SerializeField] GameObject _shield;

        #endregion

        #region Knobs

        [SerializeField] float _speed;

        #endregion

        #region RuntimeVariables

        bool _canMove;
        bool _gameEnded;
        float _direction;
        bool _hasMultiplier;
        bool _hasShield;
        Coroutine _sizeCoroutine;
        Coroutine _multiplierCoroutine;

        #endregion

        #region UnityMethods
        
        void Update()
        {
            if (_canMove && !_gameEnded)
                _rb.linearVelocityX = _direction * _speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Candy"))
            {
                if (_hasMultiplier) 
                    _manager.AddScore(other.gameObject.GetComponent<Candy>().GetScore * 2);
                else
                    _manager.AddScore(other.gameObject.GetComponent<Candy>().GetScore);
                other.gameObject.SetActive(false);
            }
            else if (other.CompareTag("Hurt"))
            {
                if (_hasShield)
                {
                    _hasShield = false;
                    _shield.SetActive(false);
                }
                else
                    _manager.ReduceHealth();
                other.gameObject.SetActive(false);
            }
            else if (other.CompareTag("PowerUP"))
            {
                switch (other.gameObject.GetComponent<PowerUp>().GetPowerUP)
                {
                    case PowerUps.SIZE:
                        transform.localScale = Vector3.one * 2;
                        if (_sizeCoroutine != null)
                        {
                            StopCoroutine( _sizeCoroutine);
                            _sizeCoroutine = null;
                        }
                        _sizeCoroutine = StartCoroutine(SizeCoroutine());
                        break;
                    case PowerUps.MULTIPLIER:
                        _hasMultiplier= true;
                        _manager.ChangeMultiplier(_hasMultiplier);
                        if (_multiplierCoroutine != null)
                        {
                            StopCoroutine( _multiplierCoroutine);
                            _multiplierCoroutine = null;
                        }
                        _multiplierCoroutine = StartCoroutine(MultiplierCoroutine());
                        break;
                    case PowerUps.SHIELD:
                        _hasShield = true;
                        _shield.SetActive(true);
                        break;
                    case PowerUps.EXTRALIFE:
                        _manager.AddHealth();
                        break;
                }
                other.gameObject.SetActive(false);
            }
        }

        #endregion

        #region PublicMethods

        public void OnMove(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                _canMove = true;
                _direction = value.ReadValue<float>();
            }
            else
            {
                _canMove = false;
                _direction = 0f;
                _rb.linearVelocityX = 0f;
            }
        }

        public void EndGame()
        {
            _gameEnded = true;
            _direction = 0f;
            _rb.linearVelocityX = 0f;
        }

        #endregion

        #region Coroutine

        IEnumerator SizeCoroutine()
        {
            yield return new WaitForSeconds(10);
            transform.localScale = Vector3.one;
        }

        IEnumerator MultiplierCoroutine()
        {
            yield return new WaitForSeconds(10);
            _hasMultiplier = false;
            _manager.ChangeMultiplier(_hasMultiplier);
        }

        #endregion
    }
}


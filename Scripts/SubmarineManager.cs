using System;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// 潜水艦にアタッチするクラス
    /// </summary>
    public class SubmarineManager : MonoBehaviour
    {
        /// <summary>
        /// Rigidbody2Dコンポーネント
        /// </summary>
        [SerializeField] private Rigidbody2D rb2D;
        /// <summary>
        /// 弾のPrefab
        /// </summary>
        [SerializeField] private BulletManager bulletPrefab;
        /// <summary>
        /// プレイヤの周りを照らすライト
        /// </summary>
        [SerializeField] private Light2D aroundLight2D;
        /// <summary>
        /// 前方向を照らすライト
        /// </summary>
        [SerializeField] private Light2D frontLight2D;
        /// <summary>
        /// お宝を照らすライト
        /// </summary>
        [SerializeField] private Light2D treasureLight2D;
        /// <summary>
        /// 移動スピード
        /// </summary>
        [SerializeField] private float movementSpeed;
        /// <summary>
        /// 回転スピード
        /// </summary>
        [SerializeField] private float rotationSpeed;
        /// <summary>
        /// セットされてるボタンの機能
        /// </summary>
        private ButtonAbilityBase buttonAbility;
        /// <summary>
        /// プレイヤの周りを照らすライトの明るさを開始時に格納したもの
        /// </summary>
        private float startAroundLight2D;
        /// <summary>
        /// 前方向を照らすライトの明るさを開始時に格納したもの
        /// </summary>
        private float startFrontLight2D;
        /// <summary>
        /// お宝を照らすライトの明るさ
        /// </summary>
        private float startTreasureLight2D;
        /// <summary>
        /// ゲーム開始時のライトの半径
        /// </summary>
        private float lightRadius;
        /// <summary>
        /// 周りを照らしているかどうか
        /// </summary>
        private bool isRightUp;
        /// <summary>
        /// UpdateAsObservableの戻り値
        /// </summary>
        private IDisposable dispose;

        private void Awake()
        {
            startAroundLight2D = aroundLight2D.intensity;
            startFrontLight2D = frontLight2D.intensity;
            startTreasureLight2D = treasureLight2D.intensity;

            aroundLight2D.intensity = 0;
            frontLight2D.intensity = 0;
            treasureLight2D.intensity = 0;

            isRightUp = false;
        }

        /// <summary>
        /// 潜水艦がマイフレーム行う処理
        /// </summary>
        private void MyUpdate()
        {
            //一旦速度をゼロにする
            rb2D.velocity = Vector2.zero;

            //ボタンが押されたとき
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(buttonAbility != null) buttonAbility.OnButtonPressed();
            }
            
            //ボタンが押されているとき
            if (Input.GetKey(KeyCode.Space))
            {
                if(buttonAbility != null) buttonAbility.OnButtonPressing();
            }
        }

        /// <summary>
        /// 潜水艦の初期化用処理
        /// </summary>
        public void Initialize()
        {
            //コイツが呼ばれたら操作可能にする
            dispose = this.UpdateAsObservable()
                                        .Subscribe(_ => MyUpdate())
                                        .AddTo(this);
        }

        /// <summary>
        /// ボタンがセットされた際に新しい機能に切り替える処理
        /// </summary>
        /// <param name="bAbility">新しいボタンの昨日</param>
        public void SetButtonAbility(ButtonAbilityBase bAbility)
        {
            buttonAbility = bAbility;
        }

        /// <summary>
        /// 潜水艦を前進させる処理
        /// </summary>
        /// <param name="isDirectionUp">移動方向、trueなら前進させる</param>
        public void MoveSubmarine(bool isDirectionUp)
        {
            if (isDirectionUp)
            {
                rb2D.velocity = transform.up.normalized * movementSpeed;
            }
            else
            {
                rb2D.velocity = -transform.up.normalized * movementSpeed;
            }
        }

        /// <summary>
        /// 潜水艦を回転させる処理
        /// </summary>
        /// <param name="isRotationDirectionRight">時計回りに回したいならtrueを渡す</param>
        public void RotateSubmarine(bool isRotationDirectionRight)
        {
            if (isRotationDirectionRight)
            {
                transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }
        }

        /// <summary>
        /// ゲーム開始時にライトを点灯させる処理
        /// </summary>
        public IEnumerator StartLightingUp()
        {
            for (var i = 0; i < 10; ++i)
            {
                aroundLight2D.intensity += startAroundLight2D * 0.1f;
                yield return new WaitForSeconds(0.05f);
            }    
            
            for (var i = 0; i < 10; ++i)
            {
                frontLight2D.intensity += startFrontLight2D * 0.1f;
                treasureLight2D.intensity += startTreasureLight2D * 0.1f;
                yield return new WaitForSeconds(0.05f);
            }

            lightRadius = aroundLight2D.pointLightOuterRadius;

            yield return new WaitForSeconds(0.5f);
        }

        /// <summary>
        /// 弾を発射する処理
        /// </summary>
        public void FireBullet()
        {
            var submarineTransform = transform;
            Instantiate(bulletPrefab, submarineTransform.position + submarineTransform.up * 1f, submarineTransform.rotation);
        }

        /// <summary>
        /// 周りを明るく照らす処理
        /// </summary>
        public void LightUpAround()
        {
            if(isRightUp) return;
            StartCoroutine(LightUpAroundCoroutine());
        }

        /// <summary>
        /// 周りをいい感じに明るくするコルーチン
        /// </summary>
        /// <returns></returns>
        private IEnumerator LightUpAroundCoroutine()
        {
            isRightUp = true;
            
            var difference = 18 - aroundLight2D.pointLightOuterRadius;
            for (var i = 0; i < 10; i++)
            {
                aroundLight2D.pointLightOuterRadius += difference / 10;
                aroundLight2D.pointLightInnerRadius = aroundLight2D.pointLightOuterRadius / 3;
                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(10);
            
            difference = aroundLight2D.pointLightOuterRadius - lightRadius;
            for (var i = 0; i < 10; i++)
            {
                aroundLight2D.pointLightOuterRadius -= difference / 10;
                aroundLight2D.pointLightInnerRadius = aroundLight2D.pointLightOuterRadius / 3;
                yield return new WaitForSeconds(0.05f);
            }

            isRightUp = false;
        }

        public void StopMoving()
        {
            rb2D.velocity = Vector2.zero;
            dispose?.Dispose();
        }
    }
}

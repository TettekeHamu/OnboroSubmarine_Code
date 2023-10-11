using System;
using System.Collections.Generic;
using naichilab.EasySoundPlayer.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// OneButtonImageにアタッチするクラス
    /// </summary>
    public class OneButtonManager : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
    {
        /// <summary>
        /// イメージコンポーネント
        /// </summary>
        [SerializeField] private Image image;
        /// <summary>
        /// ボタンの画像
        /// </summary>
        [SerializeField] private Sprite[] buttonSprites;
        /// <summary>
        /// ドラッグ開始地点
        /// </summary>
        private Vector2 startDragPos;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeButtonSprite(true);
            }
            else if(Input.GetKeyUp(KeyCode.Space))
            {
                ChangeButtonSprite(false);
            }
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            SePlayer.Instance.Play("SE_ButtonUp");
            //開始地点を記録
            startDragPos = transform.position;
        }
        
        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            //マウスに画像を追従させる
            transform.position = eventData.position;
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            //ドロップ先がボタンが置けない場所とする
            var isDropButtonPlace = false;
            
            //ドラッグが終わった箇所を取得
            var raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycastResults);
 
            //ドラッグが終わった箇所を調べる
            foreach (var hit in raycastResults)
            {
                //もしボタンが置ける場所なら
                var buttonPlace = hit.gameObject.GetComponent<ButtonPlaceManager>();
                if (buttonPlace != null)
                {
                    SePlayer.Instance.Play("SE_ButtonDown");
                    //ボタンをセットする
                    transform.position = hit.gameObject.transform.position;
                    buttonPlace.OnDropButton();
                    isDropButtonPlace = true;
                }
            }
            
            //ボタンが置けない場所なら元の場所に戻す
            if (!isDropButtonPlace)
            {
                transform.position = startDragPos;
            }
        }

        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            
        }

        /// <summary>
        /// ボタンが押されているときに画像を変える処理
        /// </summary>
        /// <param name="isPressed">押されているときはtrueにする</param>
        public void ChangeButtonSprite(bool isPressed)
        {
            if (isPressed)
            {
                image.sprite = buttonSprites[1];
            }
            else
            {
                image.sprite = buttonSprites[0];
            }
        }
    }
}

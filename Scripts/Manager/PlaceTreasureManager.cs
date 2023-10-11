using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// お宝を配置するクラス
    /// </summary>
    public class PlaceTreasureManager : MonoBehaviour
    {
        /// <summary>
        /// プレイヤーの真ん前にだすお宝
        /// </summary>
        [SerializeField] private TreasureManager tutorialPrefab;
        /// <summary>
        /// お宝のPrefab
        /// </summary>
        [SerializeField] private TreasureManager[] treasurePrefab;

        private void Awake()
        {
            PlaceTreasureObject();
        }

        /// <summary>
        /// お宝を配置する処理
        /// </summary>
        private void PlaceTreasureObject()
        {
            //プレイヤーを中心に遠いほど良いアイテムを置くようにする(チュートリアル含め7種類)
            //一番得点の低いアイテムから順に配置していく
            {
                var treasureObject = Instantiate(tutorialPrefab, new Vector3(0, 7.5f, 0), Quaternion.identity);
                treasureObject.transform.SetParent(this.transform);
            }
            for (var i = 0; i < 50; ++i)
            {
                var angle = Random.Range(0f, 360f);
                var rad = angle * Mathf.Deg2Rad;
                var distance = Random.Range(12, 30);
                var yDistance = distance * Mathf.Sin(rad);
                var xDistance = distance * Mathf.Cos(rad);
                var treasureObject = Instantiate(treasurePrefab[0], new Vector3(xDistance, yDistance, 0), Quaternion.identity);
                treasureObject.transform.SetParent(this.transform);
            }
            for (var i = 0; i < 30; ++i)
            {
                var angle = Random.Range(0f, 360f);
                var rad = angle * Mathf.Deg2Rad;
                var distance = Random.Range(25, 40);
                var yDistance = distance * Mathf.Sin(rad);
                var xDistance = distance * Mathf.Cos(rad);
                var treasureObject = Instantiate(treasurePrefab[1], new Vector3(xDistance, yDistance, 0), Quaternion.identity);
                treasureObject.transform.SetParent(this.transform);
            }
            for (var i = 0; i < 20; ++i)
            {
                var angle = Random.Range(0f, 360f);
                var rad = angle * Mathf.Deg2Rad;
                var distance = Random.Range(32, 50);
                var yDistance = distance * Mathf.Sin(rad);
                var xDistance = distance * Mathf.Cos(rad);
                var treasureObject = Instantiate(treasurePrefab[2], new Vector3(xDistance, yDistance, 0), Quaternion.identity);
                treasureObject.transform.SetParent(this.transform);
            }
            for (var i = 0; i < 15; ++i)
            {
                var angle = Random.Range(0f, 360f);
                var rad = angle * Mathf.Deg2Rad;
                var distance = Random.Range(40, 60);
                var yDistance = distance * Mathf.Sin(rad);
                var xDistance = distance * Mathf.Cos(rad);
                var treasureObject = Instantiate(treasurePrefab[3], new Vector3(xDistance, yDistance, 0), Quaternion.identity);
                treasureObject.transform.SetParent(this.transform);
            }
            for (var i = 0; i < 10; ++i)
            {
                var angle = Random.Range(0f, 360f);
                var rad = angle * Mathf.Deg2Rad;
                var distance = Random.Range(55, 70);
                var yDistance = distance * Mathf.Sin(rad);
                var xDistance = distance * Mathf.Cos(rad);
                var treasureObject = Instantiate(treasurePrefab[4], new Vector3(xDistance, yDistance, 0), Quaternion.identity);
                treasureObject.transform.SetParent(this.transform);
            }
            {
                var angle = Random.Range(0f, 360f);
                var rad = angle * Mathf.Deg2Rad;
                var distance = Random.Range(45, 65);
                var yDistance = distance * Mathf.Sin(rad);
                var xDistance = distance * Mathf.Cos(rad);
                var treasureObject = Instantiate(treasurePrefab[5], new Vector3(xDistance, yDistance, 0), Quaternion.identity);
                treasureObject.transform.SetParent(this.transform);
            }
        }
    }
}

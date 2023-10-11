using UnityEngine;

namespace Hamu.OnboroSubmarine
{
    [CreateAssetMenu(fileName = "Treasure", menuName = "ScriptableObjects/TreasureData")]
    public class TreasureData : ScriptableObject
    {
        /// <summary>
        /// 獲得した時のスコア
        /// </summary>
        [SerializeField] private int score;
        /// <summary>
        /// 画像データ
        /// </summary>
        [SerializeField] private Sprite[] itemSprites;

        public int Score => score;

        public int ItemSpritesLength => itemSprites.Length;

        /// <summary>
        /// 番号に合ったSpriteを返す処理
        /// </summary>
        /// <param name="num"></param>
        public Sprite GetSprite(int num)
        {
            return itemSprites[num];
        }
    }
}

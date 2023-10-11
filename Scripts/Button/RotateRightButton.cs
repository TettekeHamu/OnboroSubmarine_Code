using naichilab.EasySoundPlayer.Scripts;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// 右に回転させるボタン
    /// </summary>
    public class RotateRightButton : ButtonAbilityBase
    {
        public override void OnButtonPressed()
        {
            SePlayer.Instance.Play("SE_Rotate");
        }
        
        public override void OnButtonPressing()
        {
            Submarine.RotateSubmarine(true);
        }
    }
}

using naichilab.EasySoundPlayer.Scripts;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// 潜水艦を後退させるボタン
    /// </summary>
    public class MoveBackwardButton : ButtonAbilityBase
    {
        public override void OnButtonPressed()
        {
            SePlayer.Instance.Play("SE_Movement");
        }
        
        public override void OnButtonPressing()
        {
            Submarine.MoveSubmarine(false);
        }
    }
}

namespace SubClassSandBox {
    public class Class1 {
        /// <summary>
        /// 特殊能力の共通処理を管理する基底クラス。
        /// </summary>
        public abstract class Superpower {
            /// <summary>
            /// 特殊能力を実行する。
            /// </summary>
            public abstract void Activate();

            /// <summary>
            /// 効果音を再生する。
            /// </summary>
            protected void PlaySound(string soundId) {
                Console.WriteLine($"効果音を再生しました: {soundId}");
            }

            /// <summary>
            /// パーティクルを生成する。
            /// </summary>
            protected void SpawnParticles(string particleId) {
                Console.WriteLine($"パーティクルを生成しました: {particleId}");
            }

            /// <summary>
            /// キャラクターを移動させる。
            /// </summary>
            protected void Move(float x, float y) {
                Console.WriteLine($"キャラクターを移動しました: X={x}, Y={y}");
            }

            /// <summary>
            /// 空中へ飛び上がる特殊能力。
            /// </summary>
            public sealed class SkyLaunch : Superpower {
                /// <summary>
                /// 空中へ飛び上がる能力を実行する。
                /// </summary>
                public override void Activate() {
                    PlaySound("Launch");
                    SpawnParticles("Dust");
                    Move(0.0f, 10.0f);
                }
            }
        }
    }
}

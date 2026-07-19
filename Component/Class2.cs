using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DecouplingPatterns.Class1;

namespace DecouplingPatterns {
    internal class Class2 {
        /// <summary>
        /// プレイヤーの入力を処理するコンポーネント。
        /// </summary>
        public sealed class PlayerInputComponent : InputComponent {
            /// <summary>
            /// プレイヤーの入力状態を更新する。
            /// </summary>
            public override void Update(GameObject gameObject) {
                if (gameObject == null) {
                    Console.WriteLine("入力処理対象のゲームオブジェクトがnullです。");
                    return;
                }

                int velocityX = 0;
                int velocityY = 0;

                if (IsLeftPressed()) {
                    velocityX = -1;
                } else if (IsRightPressed()) {
                    velocityX = 1;
                }

                if (IsUpPressed()) {
                    velocityY = 1;
                } else if (IsDownPressed()) {
                    velocityY = -1;
                }

                gameObject.SetVelocity(velocityX, velocityY);
            }

            private bool IsLeftPressed() {
                return false;
            }

            private bool IsRightPressed() {
                return true;
            }

            private bool IsUpPressed() {
                return false;
            }

            private bool IsDownPressed() {
                return false;
            }
        }


        /// <summary>
        /// AIによる移動を処理するコンポーネント。
        /// </summary>
        public sealed class AiInputComponent : InputComponent {
            private bool moveRight_ = true;

            /// <summary>
            /// AIの入力状態を更新する。
            /// </summary>
            public override void Update(GameObject gameObject) {
                if (gameObject == null) {
                    Console.WriteLine("AI処理対象のゲームオブジェクトがnullです。");
                    return;
                }

                gameObject.GetPosition(out int x, out _);

                if (x >= 5) {
                    moveRight_ = false;
                } else if (x <= -5) {
                    moveRight_ = true;
                }

                int velocityX = moveRight_ ? 1 : -1;
                gameObject.SetVelocity(velocityX, 0);
            }
        }
    }
}

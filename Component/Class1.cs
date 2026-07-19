using System;

namespace DecouplingPatterns {
    public class Class1 {

        /// <summary>
        /// ゲーム内のオブジェクトを管理するクラス。
        /// </summary>
        public sealed class GameObject {
            private readonly InputComponent inputComponent_;
            private readonly PhysicsComponent physicsComponent_;
            private readonly GraphicsComponent graphicsComponent_;

            private int x_;
            private int y_;
            private int velocityX_;
            private int velocityY_;

            /// <summary>
            /// ゲームオブジェクトを初期化する。
            /// </summary>
            public GameObject(
                InputComponent inputComponent,
                PhysicsComponent physicsComponent,
                GraphicsComponent graphicsComponent) {
                inputComponent_ = inputComponent
                    ?? throw new ArgumentNullException(nameof(inputComponent));

                physicsComponent_ = physicsComponent
                    ?? throw new ArgumentNullException(nameof(physicsComponent));

                graphicsComponent_ = graphicsComponent
                    ?? throw new ArgumentNullException(nameof(graphicsComponent));
            }

            /// <summary>
            /// ゲームオブジェクトを更新する。
            /// </summary>
            public void Update() {
                inputComponent_.Update(this);
                physicsComponent_.Update(this);
                graphicsComponent_.Update(this);
            }

            /// <summary>
            /// 位置を取得する。
            /// </summary>
            public void GetPosition(out int x, out int y) {
                x = x_;
                y = y_;
            }

            /// <summary>
            /// 速度を取得する。
            /// </summary>
            public void GetVelocity(out int velocityX, out int velocityY) {
                velocityX = velocityX_;
                velocityY = velocityY_;
            }

            /// <summary>
            /// 位置を設定する。
            /// </summary>
            public void SetPosition(int x, int y) {
                x_ = x;
                y_ = y;
            }

            /// <summary>
            /// 速度を設定する。
            /// </summary>
            public void SetVelocity(int velocityX, int velocityY) {
                velocityX_ = velocityX;
                velocityY_ = velocityY;
            }
        }
    }
}

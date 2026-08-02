namespace DataLocality {
    public class Class1 {
        /// <summary>
        /// ゲーム内のエンティティを表すクラス。
        /// </summary>
        public sealed class GameEntity {
            private readonly AIComponent aiComponent_;

            private int x_;
            private int y_;

            /// <summary>
            /// ゲームエンティティを初期化する。
            /// </summary>
            public GameEntity(AIComponent aiComponent) {
                this.aiComponent_ = aiComponent;
            }

            /// <summary>
            /// 毎フレーム更新する。
            /// </summary>
            public void Update() {
                aiComponent_.Update(this);
            }

            /// <summary>
            /// X座標を取得する。
            /// </summary>
            public int X {
                get => x_;
                set => x_ = value;
            }

            /// <summary>
            /// Y座標を取得する。
            /// </summary>
            public int Y {
                get => y_;
                set => y_ = value;
            }
        }

        /// <summary>
        /// AIコンポーネントの基底クラス。
        /// </summary>
        public abstract class AIComponent {
            /// <summary>
            /// AIを更新する。
            /// </summary>
            public abstract void Update(GameEntity entity);
        }

        /// <summary>
        /// プレイヤー入力を処理するAI。
        /// </summary>
        public sealed class PlayerAIComponent : AIComponent {
            /// <summary>
            /// AIを更新する。
            /// </summary>
            public override void Update(GameEntity entity) {
                if (entity == null) {
                    return;
                }

                // 入力処理
            }
        }

        /// <summary>
        /// 敵AIを処理するクラス。
        /// </summary>
        public sealed class MonsterAIComponent : AIComponent {
            /// <summary>
            /// AIを更新する。
            /// </summary>
            public override void Update(GameEntity entity) {
                if (entity == null) {
                    return;
                }

                entity.X++;
            }
        }

        public sealed class ParticleSystem {
            private readonly float[] positionsX_;
            private readonly float[] positionsY_;
            private readonly float[] velocitiesX_;
            private readonly float[] velocitiesY_;

            public ParticleSystem(int count) {
                positionsX_ = new float[count];
                positionsY_ = new float[count];
                velocitiesX_ = new float[count];
                velocitiesY_ = new float[count];
            }

            public void Update() {
                for (int i = 0; i < positionsX_.Length; i++) {
                    positionsX_[i] += velocitiesX_[i];
                    positionsY_[i] += velocitiesY_[i];
                }
            }
        }
    }
}

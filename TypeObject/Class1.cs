using System;

namespace TypeObject {
    public class Class1 {

        /// <summary>
        /// モンスターの種類を表すクラス。
        /// </summary>
        public sealed class Breed {
            private readonly string name_;
            private readonly int health_;
            private readonly string attack_;

            /// <summary>
            /// モンスターの種類を初期化する。
            /// </summary>
            public Breed(string name, int health, string attack) {
                if (string.IsNullOrWhiteSpace(name)) {
                    throw new ArgumentException("種類名が設定されていません。", nameof(name));
                }

                if (health <= 0) {
                    throw new ArgumentOutOfRangeException(
                        nameof(health),
                        "体力は1以上にしてください。");
                }

                if (string.IsNullOrWhiteSpace(attack)) {
                    throw new ArgumentException("攻撃名が設定されていません。", nameof(attack));
                }

                name_ = name;
                health_ = health;
                attack_ = attack;
            }

            /// <summary>
            /// モンスターを生成する。
            /// </summary>
            public Monster CreateMonster() {
                return new Monster(this);
            }

            /// <summary>
            /// 種類名を取得する。
            /// </summary>
            public string GetName() {
                return name_;
            }

            /// <summary>
            /// 初期体力を取得する。
            /// </summary>
            public int GetHealth() {
                return health_;
            }

            /// <summary>
            /// 攻撃名を取得する。
            /// </summary>
            public string GetAttack() {
                return attack_;
            }
        }
    }
}

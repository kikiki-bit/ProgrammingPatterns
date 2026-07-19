using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TypeObject.Class1;

namespace TypeObject {
    internal class Class2 {

        /// <summary>
        /// モンスターの個体を表すクラス。
        /// </summary>
        public sealed class Monster {
            private readonly Breed breed_;
            private int health_;

            /// <summary>
            /// モンスターを初期化する。
            /// </summary>
            public Monster(Breed breed) {
                breed_ = breed ?? throw new ArgumentNullException(nameof(breed));
                health_ = breed_.GetHealth();
            }

            /// <summary>
            /// 攻撃する。
            /// </summary>
            public void Attack() {
                Console.WriteLine(
                    $"{breed_.GetName()}は{breed_.GetAttack()}で攻撃しました。");
            }

            /// <summary>
            /// ダメージを受ける。
            /// </summary>
            public void TakeDamage(int damage) {
                if (damage <= 0) {
                    Console.WriteLine("ダメージは1以上にしてください。");
                    return;
                }

                health_ = Math.Max(health_ - damage, 0);

                Console.WriteLine(
                    $"{breed_.GetName()}の残り体力: {health_}");
            }
        }
    }
}

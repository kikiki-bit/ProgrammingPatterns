using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DecouplingPatterns.Class1;
using static DecouplingPatterns.Class3;

namespace DecouplingPatterns {
    internal class Class3 {

        /// <summary>
        /// 描画処理を表す基底クラス。
        /// </summary>
        public abstract class GraphicsComponent {
            /// <summary>
            /// オブジェクトを描画する。
            /// </summary>
            public abstract void Update(GameObject gameObject);
        }


        /// <summary>
        /// プレイヤーを描画するコンポーネント。
        /// </summary>
        public sealed class PlayerGraphicsComponent : GraphicsComponent {
            /// <summary>
            /// プレイヤーの現在位置を描画する。
            /// </summary>
            public override void Update(GameObject gameObject) {
                if (gameObject == null) {
                    Console.WriteLine("描画対象のゲームオブジェクトがnullです。");
                    return;
                }

                gameObject.GetPosition(out int x, out int y);

                Console.WriteLine(
                    $"プレイヤーを描画しました。X={x}, Y={y}");
            }
        }


        /// <summary>
        /// 敵を描画するコンポーネント。
        /// </summary>
        public sealed class EnemyGraphicsComponent : GraphicsComponent {
            /// <summary>
            /// 敵の現在位置を描画する。
            /// </summary>
            public override void Update(GameObject gameObject) {
                if (gameObject == null) {
                    Console.WriteLine("描画対象のゲームオブジェクトがnullです。");
                    return;
                }

                gameObject.GetPosition(out int x, out int y);

                Console.WriteLine(
                    $"敵を描画しました。X={x}, Y={y}");
            }
        }
    }
}
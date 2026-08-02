using System.Numerics;

namespace DirtyFlag {
    public class Class1 {

        /// <summary>
        /// 座標変換情報を表すクラス
        /// </summary>
        public sealed class TransformData {
            public Vector3 Position { get; }

            /// <summary>
            /// 座標変換情報を初期化する
            /// </summary>
            public TransformData(Vector3 position) {
                Position = position;
            }

            /// <summary>
            /// 原点を表す座標変換情報を生成する
            /// </summary>
            public static TransformData Origin() {
                return new TransformData(Vector3.Zero);
            }

            /// <summary>
            /// 別の座標変換情報と組み合わせる
            /// </summary>
            public TransformData Combine(TransformData other) {
                if (other == null) {
                    throw new ArgumentNullException(nameof(other));
                }

                Vector3 combinedPosition = Position + other.Position;
                return new TransformData(combinedPosition);
            }
        }

        /// <summary>
        /// 描画するメッシュを表すクラス
        /// </summary>
        public sealed class Mesh {
            public string Name { get; }

            /// <summary>
            /// メッシュを初期化する
            /// </summary>
            public Mesh(string name) {
                if (string.IsNullOrWhiteSpace(name)) {
                    throw new ArgumentException(
                        "メッシュ名が設定されていません。",
                        nameof(name));
                }

                Name = name;
            }
        }

        /// <summary>
        /// シーングラフのノードを表すクラス
        /// </summary>
        public sealed class GraphNode {
            private const int MaxChildren = 16;

            private readonly Mesh mesh_;
            private readonly List<GraphNode> children_;

            private TransformData local_;

            /// <summary>
            /// グラフノードを初期化する
            /// </summary>
            public GraphNode(Mesh mesh) {
                mesh_ = mesh ?? throw new ArgumentNullException(nameof(mesh));
                local_ = TransformData.Origin();
                children_ = new List<GraphNode>(MaxChildren);
            }

            /// <summary>
            /// ローカル座標変換を設定する
            /// </summary>
            public bool TrySetLocal(TransformData local) {
                if (local == null) {
                    Console.WriteLine("設定するローカル座標変換がnullです。");
                    return false;
                }

                local_ = local;
                return true;
            }

            /// <summary>
            /// 子ノードを追加する
            /// </summary>
            public bool TryAddChild(GraphNode child) {
                if (child == null) {
                    Console.WriteLine("追加する子ノードがnullです。");
                    return false;
                }

                if (ReferenceEquals(this, child)) {
                    Console.WriteLine("自分自身を子ノードには追加できません。");
                    return false;
                }

                if (children_.Count >= MaxChildren) {
                    Console.WriteLine("子ノードの最大数に達しています。");
                    return false;
                }

                if (children_.Contains(child)) {
                    Console.WriteLine("同じ子ノードがすでに登録されています。");
                    return false;
                }

                children_.Add(child);
                return true;
            }
        }
    }
}
}

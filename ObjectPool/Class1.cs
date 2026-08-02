namespace ObjectPool {
    public class Class1 {
        /// <summary>
        /// 再利用する弾を表すクラス
        /// </summary>
        public sealed class Bullet {
            public bool IsActive { get; private set; }
            public float X { get; private set; }
            public float Y { get; private set; }

            /// <summary>
            /// 弾を有効化する
            /// </summary>
            public bool TryActivate(float x, float y) {
                if (IsActive) {
                    Console.WriteLine("弾はすでに使用中です。");
                    return false;
                }

                X = x;
                Y = y;
                IsActive = true;
                return true;
            }

            /// <summary>
            /// 弾を更新する
            /// </summary>
            public void Update() {
                if (!IsActive) {
                    return;
                }

                X += 1.0f;

                if (X > 100.0f) {
                    Deactivate();
                }
            }

            /// <summary>
            /// 弾を無効化する
            /// </summary>
            public void Deactivate() {
                IsActive = false;
                X = 0.0f;
                Y = 0.0f;
            }

            /// <summary>
            /// 弾を再利用するオブジェクトプール
            /// </summary>
            public sealed class BulletPool {
                private readonly List<Bullet> bullets_;

                /// <summary>
                /// 指定した数の弾を事前生成する
                /// </summary>
                public BulletPool(int capacity) {
                    if (capacity <= 0) {
                        throw new ArgumentOutOfRangeException(
                            nameof(capacity),
                            "生成数は1以上にしてください。");
                    }

                    bullets_ = new List<Bullet>(capacity);

                    for (int i = 0; i < capacity; i++) {
                        bullets_.Add(new Bullet());
                    }
                }

                /// <summary>
                /// 未使用の弾を取得して有効化する
                /// </summary>
                public bool TrySpawn(float x, float y, out Bullet bullet) {
                    bullet = null;

                    for (int i = 0; i < bullets_.Count; i++) {
                        Bullet current = bullets_[i];

                        if (current.IsActive) {
                            continue;
                        }

                        if (!current.TryActivate(x, y)) {
                            continue;
                        }

                        bullet = current;
                        return true;
                    }

                    Console.WriteLine("使用できる弾がありません。");
                    return false;
                }

                /// <summary>
                /// 使用中の弾を更新する
                /// </summary>
                public void Update() {
                    for (int i = 0; i < bullets_.Count; i++) {
                        bullets_[i].Update();
                    }
                }
            }
        }
    }
}

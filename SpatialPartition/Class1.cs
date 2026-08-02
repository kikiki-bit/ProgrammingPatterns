

namespace SpatialPartition {
    public class Class1 {
        public sealed class MeleeSystem {
            /// <summary>
            /// 同じ位置にいるユニット同士の攻撃を処理する
            /// </summary>
            public bool TryHandleMelee(Unit[] units, int numUnits) {
                if (units == null) {
                    Console.WriteLine("ユニット配列がnullです。");
                    return false;
                }

                if (numUnits < 0 || numUnits > units.Length) {
                    Console.WriteLine("ユニット数が不正です。");
                    return false;
                }

                for (int a = 0; a < numUnits - 1; a++) {
                    if (units[a] == null) {
                        Console.WriteLine($"ユニットがnullです。インデックス: {a}");
                        continue;
                    }

                    for (int b = a + 1; b < numUnits; b++) {
                        if (units[b] == null) {
                            Console.WriteLine($"ユニットがnullです。インデックス: {b}");
                            continue;
                        }

                        if (units[a].Position == units[b].Position) {
                            HandleAttack(units[a], units[b]);
                        }
                    }
                }

                return true;
            }

            /// <summary>
            /// ユニット同士の攻撃を処理する
            /// </summary>
            private void HandleAttack(Unit attacker, Unit target) {
                Console.WriteLine(
                    $"{attacker.Name}と{target.Name}が同じ位置で戦闘しました。");
            }
        }

        public sealed class Unit {
            private Unit prev_;
            private Unit next_;
            private Grid grid_;

            /// <summary>
            /// X座標
            /// </summary>
            public int X { get; private set; }

            /// <summary>
            /// Y座標
            /// </summary>
            public int Y { get; private set; }

            /// <summary>
            /// ユニットを初期化する
            /// </summary>
            public Unit(Grid grid, int x, int y) {
                grid_ = grid ?? throw new ArgumentNullException(nameof(grid));

                X = x;
                Y = y;
            }

            /// <summary>
            /// ユニットを移動する
            /// </summary>
            public void Move(int x, int y) {
                grid_.Move(this, x, y);
            }

            /// <summary>
            /// 前のユニットを取得または設定する
            /// </summary>
            public Unit Prev {
                get => prev_;
                set => prev_ = value;
            }

            /// <summary>
            /// 次のユニットを取得または設定する
            /// </summary>
            public Unit Next {
                get => next_;
                set => next_ = value;
            }

            /// <summary>
            /// 座標を設定する
            /// </summary>
            public void SetPosition(int x, int y) {
                X = x;
                Y = y;
            }
        }

        /// <summary>
        /// 空間をグリッドで管理するクラス
        /// </summary>
        public sealed class Grid {
            private const int NUM_CELLS = 10;

            private readonly Unit[,] cells_ =
                new Unit[NUM_CELLS, NUM_CELLS];

            /// <summary>
            /// ユニットを追加する
            /// </summary>
            public bool TryAdd(Unit unit) {
                if (unit == null) {
                    Console.WriteLine("追加するユニットがnullです。");
                    return false;
                }

                int cellX = unit.X;
                int cellY = unit.Y;

                unit.Next = cells_[cellX, cellY];

                if (cells_[cellX, cellY] != null) {
                    cells_[cellX, cellY].Prev = unit;
                }

                cells_[cellX, cellY] = unit;

                return true;
            }

            /// <summary>
            /// ユニットを移動する
            /// </summary>
            public void Move(Unit unit, int x, int y) {
                if (unit == null) {
                    Console.WriteLine("移動するユニットがnullです。");
                    return;
                }

                Remove(unit);

                unit.SetPosition(x, y);

                TryAdd(unit);
            }

            /// <summary>
            /// ユニットを削除する
            /// </summary>
            public void Remove(Unit unit) {
                if (unit == null) {
                    return;
                }

                int cellX = unit.X;
                int cellY = unit.Y;

                if (unit.Prev != null) {
                    unit.Prev.Next = unit.Next;
                }

                if (unit.Next != null) {
                    unit.Next.Prev = unit.Prev;
                }

                if (cells_[cellX, cellY] == unit) {
                    cells_[cellX, cellY] = unit.Next;
                }

                unit.Prev = null;
                unit.Next = null;
            }

            /// <summary>
            /// 指定セルの先頭ユニットを取得する
            /// </summary>
            public Unit GetCell(int x, int y) {
                return cells_[x, y];
            }
        }
    }
}

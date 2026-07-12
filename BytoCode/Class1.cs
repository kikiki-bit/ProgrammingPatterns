namespace BytoCode {
    public class Class1 {
        public enum Instruction {
            SetHealth,
            SetWisdom,
            SetAgility,
            PlaySound,
            SpawnParticles
        }

        public sealed class VirtualMachine {
            public void Interpret(IReadOnlyList<Instruction> bytecode) {
                if (bytecode == null) {
                    throw new ArgumentNullException(nameof(bytecode));
                }

                foreach (Instruction instruction in bytecode) {
                    switch (instruction) {
                        case Instruction.SetHealth:
                            SetHealth();
                            break;

                        case Instruction.SetWisdom:
                            SetWisdom();
                            break;

                        case Instruction.SetAgility:
                            SetAgility();
                            break;

                        case Instruction.PlaySound:
                            PlaySound();
                            break;

                        case Instruction.SpawnParticles:
                            SpawnParticles();
                            break;

                        default:
                            throw new InvalidOperationException(
                                $"未対応の命令です: {instruction}");
                    }
                }
            }

            private void SetHealth() {
                Console.WriteLine("体力を設定しました。");
            }

            private void SetWisdom() {
                Console.WriteLine("知力を設定しました。");
            }

            private void SetAgility() {
                Console.WriteLine("素早さを設定しました。");
            }

            private void PlaySound() {
                Console.WriteLine("効果音を再生しました。");
            }

            private void SpawnParticles() {
                Console.WriteLine("パーティクルを生成しました。");
            }

            /// <summary>
            /// バイトコードを実行する簡単な仮想マシン。
            /// </summary>
            public sealed class VirtualMachine {
                private readonly Stack<int> stack_ = new();

                /// <summary>
                /// 数値をスタックへ積む。
                /// </summary>
                public void Push(int value) {
                    stack_.Push(value);
                }

                /// <summary>
                /// スタック上の2つの数値を加算する。
                /// </summary>
                public bool TryAdd(out int result) {
                    result = 0;

                    if (stack_.Count < 2) {
                        Console.WriteLine("加算に必要な値が不足しています。");
                        return false;
                    }

                    int right = stack_.Pop();
                    int left = stack_.Pop();

                    result = left + right;
                    stack_.Push(result);

                    return true;
                }
            }
        }
    }
}

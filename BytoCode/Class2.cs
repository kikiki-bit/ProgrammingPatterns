using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BytoCode {
    internal class Class2 {

        using System;
using System.Collections.Generic;

/// <summary>
/// 仮想マシンが実行する命令。
/// </summary>
public enum OpCode {
        Push,
        Add,
        Print
    }

    /// <summary>
    /// 命令と値をまとめたデータ。
    /// </summary>
    public sealed class Instruction {
        public OpCode OpCode { get; }
        public int Value { get; }

        public Instruction(OpCode opCode, int value = 0) {
            OpCode = opCode;
            Value = value;
        }
    }

    /// <summary>
    /// 命令列を解釈して実行する仮想マシン。
    /// </summary>
    public sealed class BytecodeMachine {
        private readonly Stack<int> stack_ = new();

        /// <summary>
        /// 命令列を順番に実行する。
        /// </summary>
        public bool TryExecute(
            IReadOnlyList<Instruction> instructions,
            out int result) {
            result = 0;

            if (instructions == null) {
                Console.WriteLine("命令列がnullです。");
                return false;
            }

            foreach (Instruction instruction in instructions) {
                if (instruction == null) {
                    Console.WriteLine("命令にnullが含まれています。");
                    return false;
                }

                switch (instruction.OpCode) {
                    case OpCode.Push:
                        stack_.Push(instruction.Value);
                        break;

                    case OpCode.Add:
                        if (!TryAdd()) {
                            return false;
                        }
                        break;

                    case OpCode.Print:
                        if (stack_.Count == 0) {
                            Console.WriteLine("表示する値がありません。");
                            return false;
                        }

                        result = stack_.Peek();
                        Console.WriteLine($"実行結果: {result}");
                        break;

                    default:
                        Console.WriteLine($"未対応の命令です: {instruction.OpCode}");
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// スタック上の2つの値を加算する。
        /// </summary>
        private bool TryAdd() {
            if (stack_.Count < 2) {
                Console.WriteLine("加算に必要な値が不足しています。");
                return false;
            }

            int right = stack_.Pop();
            int left = stack_.Pop();

            stack_.Push(left + right);
            return true;
        }
    }
}
}

using System;
using static EventQue.Class1;

namespace EventQue {
    public class Class1 {

        /// <summary>
        /// 再生する音声イベントを表すクラス。
        /// </summary>
        public sealed class PlaySoundEvent {
            /// <summary>
            /// 音声IDを取得する。
            /// </summary>
            public string SoundId { get; }

            /// <summary>
            /// 音量を取得する。
            /// </summary>
            public float Volume { get; }

            /// <summary>
            /// 音声イベントを初期化する。
            /// </summary>
            public PlaySoundEvent(string soundId, float volume) {
                if (string.IsNullOrWhiteSpace(soundId)) {
                    throw new ArgumentException(
                        "音声IDが設定されていません。",
                        nameof(soundId));
                }

                if (volume < 0.0f || volume > 1.0f) {
                    throw new ArgumentOutOfRangeException(
                        nameof(volume),
                        "音量は0から1の範囲で指定してください。");
                }

                SoundId = soundId;
                Volume = volume;
            }
        }

        /// <summary>
        /// 音声イベントを順番に管理するキュー。
        /// </summary>
        public sealed class AudioEventQueue {
            private readonly Queue<PlaySoundEvent> events_ = new();

            /// <summary>
            /// キューに登録されているイベント数を取得する。
            /// </summary>
            public int Count => events_.Count;

            /// <summary>
            /// 音声イベントをキューへ追加する。
            /// </summary>
            public bool TryEnqueue(string soundId, float volume) {
                if (string.IsNullOrWhiteSpace(soundId)) {
                    Console.WriteLine("音声IDが設定されていません。");
                    return false;
                }

                if (volume < 0.0f || volume > 1.0f) {
                    Console.WriteLine("音量は0から1の範囲で指定してください。");
                    return false;
                }

                PlaySoundEvent soundEvent = new(soundId, volume);
                events_.Enqueue(soundEvent);

                return true;
            }

            /// <summary>
            /// 先頭の音声イベントを取り出す。
            /// </summary>
            public bool TryDequeue(out PlaySoundEvent soundEvent) {
                soundEvent = null;

                if (events_.Count == 0) {
                    return false;
                }

                soundEvent = events_.Dequeue();
                return true;
            }

            /// <summary>
            /// すべての音声イベントを削除する。
            /// </summary>
            public void Clear() {
                events_.Clear();
            }
        }


        /// <summary>
        /// 音声イベントを処理するクラス。
        /// </summary>
        public sealed class AudioSystem {
            private readonly AudioEventQueue eventQueue_;

            /// <summary>
            /// 音声システムを初期化する。
            /// </summary>
            public AudioSystem(AudioEventQueue eventQueue) {
                eventQueue_ = eventQueue
                    ?? throw new ArgumentNullException(nameof(eventQueue));
            }

            /// <summary>
            /// 登録された音声イベントをすべて処理する。
            /// </summary>
            public void Update() {
                while (eventQueue_.TryDequeue(out PlaySoundEvent soundEvent)) {
                    PlaySound(soundEvent.SoundId, soundEvent.Volume);
                }
            }

            /// <summary>
            /// 指定された音声を再生する。
            /// </summary>
            private void PlaySound(string soundId, float volume) {
                Console.WriteLine(
                    $"音声を再生しました。ID={soundId}, 音量={volume}");
            }
        }

        /// <summary>
        /// 音声イベントを重複確認しながら管理するキュー。
        /// </summary>
        public sealed class AudioEventQueue {
            private readonly Queue<PlaySoundEvent> events_ = new();
            private readonly HashSet<string> registeredSoundIds_ = new();

            /// <summary>
            /// 音声イベントをキューへ追加する。
            /// </summary>
            public bool TryEnqueue(string soundId, float volume) {
                if (string.IsNullOrWhiteSpace(soundId)) {
                    Console.WriteLine("音声IDが設定されていません。");
                    return false;
                }

                if (volume < 0.0f || volume > 1.0f) {
                    Console.WriteLine("音量は0から1の範囲で指定してください。");
                    return false;
                }

                if (registeredSoundIds_.Contains(soundId)) {
                    return false;
                }

                PlaySoundEvent soundEvent = new(soundId, volume);

                events_.Enqueue(soundEvent);
                registeredSoundIds_.Add(soundId);

                return true;
            }

            /// <summary>
            /// 先頭の音声イベントを取り出す。
            /// </summary>
            public bool TryDequeue(out PlaySoundEvent soundEvent) {
                soundEvent = null;

                if (events_.Count == 0) {
                    return false;
                }

                soundEvent = events_.Dequeue();
                registeredSoundIds_.Remove(soundEvent.SoundId);

                return true;
            }

            /// <summary>
            /// すべての音声イベントを削除する。
            /// </summary>
            public void Clear() {
                events_.Clear();
                registeredSoundIds_.Clear();
            }
        }
    }
}

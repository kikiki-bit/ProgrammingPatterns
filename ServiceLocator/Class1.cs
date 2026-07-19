namespace ServiceLocator {
    public class Class1 {

        /// <summary>
        /// ゲーム全体で利用するサービスを管理するクラス。
        /// </summary>
        public static class ServiceLocator {
            private static IAudioService audioService_;

            /// <summary>
            /// 音声サービスを登録する。
            /// </summary>
            public static bool TryRegisterAudio(IAudioService audioService) {
                if (audioService == null) {
                    Console.WriteLine("登録する音声サービスがnullです。");
                    return false;
                }

                audioService_ = audioService;
                return true;
            }

            /// <summary>
            /// 登録されている音声サービスを取得する。
            /// </summary>
            public static bool TryGetAudio(out IAudioService audioService) {
                audioService = audioService_;

                if (audioService == null) {
                    Console.WriteLine("音声サービスが登録されていません。");
                    return false;
                }

                return true;
            }

            /// <summary>
            /// 音声サービスの登録を解除する。
            /// </summary>
            public static void UnregisterAudio() {
                audioService_ = null;
            }
        }
    }
}

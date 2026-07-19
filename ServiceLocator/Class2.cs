using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 音声機能を提供するインターフェース。
/// </summary>
public interface IAudioService {
    /// <summary>
    /// 指定された音声を再生する。
    /// </summary>
    void PlaySound(string soundId);

    /// <summary>
    /// 指定された音声を停止する。
    /// </summary>
    void StopSound(string soundId);

    /// <summary>
    /// すべての音声を停止する。
    /// </summary>
    void StopAll();
}
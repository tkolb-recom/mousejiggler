﻿using System.Runtime.InteropServices;

namespace MouseJiggler.PInvoke;

public class Kernel32
{
    /// <summary>
    /// allocates a new console for the calling process.
    /// </summary>
    /// <returns>If the function succeeds, the return value is nonzero.
    /// If the function fails, the return value is zero.
    /// To get extended error information, call Marshal.GetLastWin32Error.</returns>
    [DllImport("kernel32", SetLastError = true)]
    public static extern bool AllocConsole();

    /// <summary>
    /// Detaches the calling process from its console
    /// </summary>
    /// <returns>If the function succeeds, the return value is nonzero.
    /// If the function fails, the return value is zero.
    /// To get extended error information, call Marshal.GetLastWin32Error.</returns>
    [DllImport("kernel32", SetLastError = true)]
    public static extern bool FreeConsole();

    /// <summary>
    /// Attaches the calling process to the console of the specified process.
    /// </summary>
    /// <param name="dwProcessId">[in] Identifier of the process, usually will be ATTACH_PARENT_PROCESS</param>
    /// <returns>If the function succeeds, the return value is nonzero.
    /// If the function fails, the return value is zero.
    /// To get extended error information, call Marshal.GetLastWin32Error.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool AttachConsole(uint dwProcessId);

    /// <summary>Identifies the console of the parent of the current process as the console to be attached.
    /// always pass this with AttachConsole in .NET for stability reasons and mainly because
    /// I have NOT tested interprocess attaching in .NET so dont blame me if it doesnt work! </summary>
    public const uint ATTACH_PARENT_PROCESS = 0x0ffffffff;

    /// <summary>
    /// calling process is already attached to a console
    /// </summary>
    public const int ERROR_ACCESS_DENIED = 5;
}
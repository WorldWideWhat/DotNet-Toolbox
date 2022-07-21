using System.IO.Ports;
using worldwidewhat.CommonTools.Threading;

/// <summary>
/// Extension of the Serialport class object.
/// Created : 2022-02-12
/// </summary>

namespace worldwidewhat.CommonTools.Extensions;

public static partial class SerialExtension
{
    private static readonly SemaphoreSlim semaphore = new(1);

    /// <summary> Flush serial port async</summary>
    /// <param name="token">Optional cancel token</param>
    /// <returns>Success</returns>
    public static async Task<int> FlushAsync(this SerialPort port, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested) return -1;
        await semaphore.WaitAsync(cancellationToken);
        if (cancellationToken.IsCancellationRequested) return -1;
        port.DiscardInBuffer();
        port.DiscardOutBuffer();

        await port.BaseStream.FlushAsync(cancellationToken);
        if (cancellationToken.IsCancellationRequested) return -1;
        semaphore.Release();
        return 0;
    }

    /// <summary> Flush serial port </summary>
    /// <param name="token">Optional cancel token</param>
    /// <returns>Success</returns>
    public static int Flush(this SerialPort port, CancellationToken cancellationToken=default)
    {
        return AsyncUtil.RunSync<int>(()=>FlushAsync(port, cancellationToken));
    }

    /// <summary> Transmit data to the serial async </summary>
    /// <param name="bffr">Buffer to transmit</param>
    /// <param name="offset">Offset in the buffer</param>
    /// <param name="length">Number of bytes to transmit</param>
    /// <param name="token">Optional cancel token</param>
    /// <returns>Success</returns>
    public static async Task<int> TransmitAsync(this SerialPort port, byte[] bffr, int offset, int length, CancellationToken token = default)
    {
        int n_success = -1;

        if (port == null) return n_success;
        if (!port.IsOpen) return n_success;
        if (token.IsCancellationRequested) return n_success;

        if (await FlushAsync(port, token) != 0) return n_success;

        await port.BaseStream.WriteAsync(bffr.AsMemory(offset, length), token);
        if (token.IsCancellationRequested) return n_success;

        await port.BaseStream.FlushAsync(token);
        if (token.IsCancellationRequested) return n_success;

        n_success = 0;
        return n_success;
    }

    /// <summary> Transmit data to the serial </summary>
    /// <param name="bffr">Buffer to transmit</param>
    /// <param name="offset">Offset in the buffer</param>
    /// <param name="length">Number of bytes to transmit</param>
    /// <param name="token">Optional cancel token</param>
    /// <returns>Success</returns>
    public static int Transmit(this SerialPort port, byte[] bffr, int offset, int length, CancellationToken token = default)
    {
        return AsyncUtil.RunSync<int>(() => TransmitAsync(port, bffr, offset, length, token));
    }

    /// <summary> Read data from serial async </summary>
    /// <param name="bffr">Buffer to read data into</param>
    /// <param name="offset">Offset in buffer </param>
    /// <param name="length">Number of bytes to read </param>
    /// <param name="timeout">Read timeout in ms</param>
    /// <param name="token">Optional Cancel token</param>
    /// <returns>Tuple[Success, number of bytes read]</returns>
    public static async Task<(int Success, int BytesRead)> ReadAsync(this SerialPort port, byte[] bffr, int offset, int length, int timeout, CancellationToken token = default)
    {
        int n_success = -1;
        int n_read = -1;
        if (port == null) return (n_success, n_read);
        if (!port.IsOpen) return (n_success, n_read);
        if (token.IsCancellationRequested) return (n_success, n_read);

        await semaphore.WaitAsync(token);
        try
        {
            if (!token.IsCancellationRequested)
                n_read = await port.BaseStream.ReadAsync(bffr, offset, length, token).Timeout(timeout);
        }
        finally
        {
            if (!token.IsCancellationRequested)
                n_success = 0;
            semaphore.Release();
        }
        return (n_success, n_read);
    }

    /// <summary> Read data from serial </summary>
    /// <param name="bffr">Buffer to read data into</param>
    /// <param name="offset">Offset in buffer </param>
    /// <param name="length">Number of bytes to read </param>
    /// <param name="timeout">Read timeout in ms</param>
    /// <param name="token">Optional Cancel token</param>
    /// <returns>Tuple[Success, number of bytes read]</returns>        
    public static (int Success, int BytesRead) Read(this SerialPort port,  byte[] bffr, int offset, int length, int timeout, CancellationToken token = default)
    {
        return AsyncUtil.RunSync<(int, int)>(() => ReadAsync(port, bffr, offset, length, timeout, token));
    }
}

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static partial class SerialExtension
{
    private static readonly SemaphoreSlim semaphore = new(1);

    /// <summary> Flush serial port async</summary>
    /// <param name="token">Optional cancel token</param>
    /// <returns>Success</returns>
    public static async Task<int> FlushAsync(this SerialPort @this, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested) return -1;
        await semaphore.WaitAsync(cancellationToken);
        if (cancellationToken.IsCancellationRequested) return -1;
        @this.DiscardInBuffer();
        @this.DiscardOutBuffer();

        await @this.BaseStream.FlushAsync(cancellationToken);
        if (cancellationToken.IsCancellationRequested) return -1;
        semaphore.Release();
        return 0;
    }

    /// <summary> Flush serial port </summary>
    /// <param name="token">Optional cancel token</param>
    /// <returns>Success</returns>
    public static int Flush(this SerialPort @this, CancellationToken cancellationToken=default)
    {
        return worldwidewhat.CommonTools.Threading.AsyncUtil.RunSync<int>(()=>FlushAsync(@this, cancellationToken));
    }

    /// <summary> Transmit data to the serial async </summary>
    /// <param name="bffr">Buffer to transmit</param>
    /// <param name="offset">Offset in the buffer</param>
    /// <param name="length">Number of bytes to transmit</param>
    /// <param name="token">Optional cancel token</param>
    /// <returns>Success</returns>
    public static async Task<int> TransmitAsync(this SerialPort @this, byte[] bffr, int offset, int length, CancellationToken token = default)
    {
        int n_success = -1;

        if (@this == null) goto ExitTransmitAsync;
        if (!@this.IsOpen) goto ExitTransmitAsync;
        if (token.IsCancellationRequested) goto ExitTransmitAsync;

        if (await FlushAsync(@this, token) != 0) goto ExitTransmitAsync;

        await @this.BaseStream.WriteAsync(bffr.AsMemory(offset, length), token);
        if (token.IsCancellationRequested) goto ExitTransmitAsync;

        await @this.BaseStream.FlushAsync(token);
        if (token.IsCancellationRequested) goto ExitTransmitAsync;

        n_success = 0;
    ExitTransmitAsync:
        return (int)n_success;
    }

    /// <summary> Transmit data to the serial </summary>
    /// <param name="bffr">Buffer to transmit</param>
    /// <param name="offset">Offset in the buffer</param>
    /// <param name="length">Number of bytes to transmit</param>
    /// <param name="token">Optional cancel token</param>
    /// <returns>Success</returns>
    public static int Transmit(this SerialPort @this, byte[] bffr, int offset, int length, CancellationToken token = default)
    {
        return worldwidewhat.CommonTools.Threading.AsyncUtil.RunSync<int>(() => TransmitAsync(@this, bffr, offset, length, token));
    }

    /// <summary> Read data from serial async </summary>
    /// <param name="bffr">Buffer to read data into</param>
    /// <param name="offset">Offset in buffer </param>
    /// <param name="length">Number of bytes to read </param>
    /// <param name="timeout">Read timeout in ms</param>
    /// <param name="token">Optional Cancel token</param>
    /// <returns>Tuple[Success, number of bytes read]</returns>
    public static async Task<(int Success, int BytesRead)> ReadAsync(this SerialPort @this, byte[] bffr, int offset, int length, int timeout, CancellationToken token = default)
    {
        int n_success = -1;
        int n_read = -1;
        if (@this == null) goto ExitReadAsync;
        if (!@this.IsOpen) goto ExitReadAsync;
        if (token.IsCancellationRequested) goto ExitReadAsync;

        await semaphore.WaitAsync(token);
        if (token.IsCancellationRequested) goto ExitReadAsync;

        try
        {
            n_read = await @this.BaseStream.ReadAsync(bffr, offset, length, token).Timeout(timeout);
        }
        finally
        {
            if (!token.IsCancellationRequested)
                n_success = 0;
        }


    ExitReadAsync:
        semaphore.Release();
        return (n_success, n_read);
    }

    /// <summary> Read data from serial </summary>
    /// <param name="bffr">Buffer to read data into</param>
    /// <param name="offset">Offset in buffer </param>
    /// <param name="length">Number of bytes to read </param>
    /// <param name="timeout">Read timeout in ms</param>
    /// <param name="token">Optional Cancel token</param>
    /// <returns>Tuple[Success, number of bytes read]</returns>        
    public static (int Success, int BytesRead) Read(this SerialPort @this,  byte[] bffr, int offset, int length, int timeout, CancellationToken token = default)
    {
        return worldwidewhat.CommonTools.Threading.AsyncUtil.RunSync<(int, int)>(() => ReadAsync(@this, bffr, offset, length, timeout, token));
    }
}

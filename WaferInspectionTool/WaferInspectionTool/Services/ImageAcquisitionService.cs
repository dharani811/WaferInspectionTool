using System;
using System.Threading;
using System.Threading.Tasks;
using WaferInspectionTool.Models;

namespace WaferInspectionTool.Services
{
    // Simulates the image acquisition system for the wafer inspection tool
    public class ImageAcquisitionService
    {
        // Event raised when a new image frame is acquired
        public event Action<ImageFrame> FrameAcquired;

        private int _frameId = 0;
        private bool _isRunning = false;
        private CancellationTokenSource _cts;

        // Starts the image acquisition simulation
        public void Start()
        {
            if (_isRunning) return;
            _isRunning = true;
            _cts = new CancellationTokenSource();
            Task.Run(() => AcquireLoop(_cts.Token));
        }

        // Stops the image acquisition simulation
        public void Stop()
        {
            _isRunning = false;
            _cts?.Cancel();
        }

        // Simulates continuous image acquisition
        private async Task AcquireLoop(CancellationToken token)
        {
            Random rand = new Random();
            while (!token.IsCancellationRequested)
            {
                // Simulate frame data (e.g., 10x10 grid with random values)
                int[,] data = new int[10, 10];
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                        data[i, j] = rand.Next(0, 256);

                var frame = new ImageFrame
                {
                    Data = data,
                    FrameId = _frameId++,
                    Timestamp = DateTime.Now
                };
                FrameAcquired?.Invoke(frame);
                await Task.Delay(1000, token); // 1 frame per second
            }
        }
    }
}
using Microsoft.Band;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandConnectorWinApp
{
    public class BandEvent
    {
        public DateTime TimeStamp { get; set; }
        public double GSR { get; set; }
        public string UnixTimeSecondsDotMilliseconds { get; internal set; }
    }

    class GSR
    {
        public List<BandEvent> Events = new List<BandEvent>();
        public async void GetBand()
        {
            IBandInfo[] pairedBands = await
            BandClientManager.Instance.GetBandsAsync();

            if (pairedBands.Length == 0)
                return;
            try
            {
                await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {
                    using (IBandClient client = await BandClientManager.Instance.ConnectAsync(pairedBands[0]))
                    {
                        var sensorManager = client.SensorManager;

                        // get the heart rate sensor
                        var heartRate = sensorManager.HeartRate;
                        Debug.WriteLine(string.Join(",", heartRate.SupportedReportingIntervals.Select(r => r.ToString())));

                        heartRate.ReadingChanged += (o, args) => {
                            var quality = args.SensorReading.Quality;
                            Debug.WriteLine("HR:" + args.SensorReading.HeartRate + " " + args.SensorReading.Timestamp);
                        };
                        if (heartRate.GetCurrentUserConsent() != UserConsent.Granted)
                        {
                            await client.SensorManager.HeartRate.RequestUserConsentAsync();
                        }

                        // GSR sensor
                        var gsr = sensorManager.Gsr;
                        Debug.WriteLine(string.Join(",", gsr.SupportedReportingIntervals.Select(r => r.ToString())));

                        gsr.ReadingChanged += (o, args) =>
                        {
                            Debug.WriteLine("GSR:" + args.SensorReading.Resistance + " " + args.SensorReading.Timestamp);
                            this.Events.Add(new BandEvent()
                            {
                                TimeStamp = args.SensorReading.Timestamp.LocalDateTime,
                                UnixTimeSecondsDotMilliseconds = args.SensorReading.Timestamp.ToUnixTimeSeconds()
                                    + "." + args.SensorReading.Timestamp.Millisecond,
                                GSR = args.SensorReading.Resistance
                            });
                        };
                        if (gsr.GetCurrentUserConsent() != UserConsent.Granted)
                        {
                            await client.SensorManager.Gsr.RequestUserConsentAsync();
                        }

                        // RR 
                        var rr = sensorManager.RRInterval;

                        Debug.WriteLine(string.Join(",", rr.SupportedReportingIntervals.Select(r => r.ToString())));
                        rr.ReadingChanged += (o, args) =>
                        {
                            Debug.WriteLine("RR:" + args.SensorReading.Interval + " " + args.SensorReading.Timestamp);
                        };
                        if (rr.GetCurrentUserConsent() != UserConsent.Granted)
                        {
                            await client.SensorManager.RRInterval.RequestUserConsentAsync();
                        }


                        bool running = await client.SensorManager.HeartRate.StartReadingsAsync();
                        bool gsrRunning = await client.SensorManager.Gsr.StartReadingsAsync();
                        bool rrRunning = await client.SensorManager.RRInterval.StartReadingsAsync();

                        while (running || gsrRunning || rrRunning)
                        {
                            await Task.Delay(TimeSpan.FromSeconds(1));
                        }
                    }
                });
            }
            catch (BandException ex)
            {
                Debug.Write(ex.Message);
            }
        }

    }
}
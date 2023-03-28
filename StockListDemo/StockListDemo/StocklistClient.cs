#region License
/*
 * Copyright (c) Lightstreamer Srl
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion License


using Lightstreamer.DotNet.Client.Test;
using com.lightstreamer.client;
using com.lightstreamer.log;


namespace DotNetStockListDemo
{
    
    public class StocklistClient
    {
        private DemoForm demoForm;
        private LightstreamerUpdateDelegate updateDelegate;
        private LightstreamerStatusChangedDelegate statusChangeDelegate;

        private LightstreamerClient client;
        private Subscription subscription;
        private Dictionary<ChartQuotes, Subscription> charts = new Dictionary<ChartQuotes, Subscription>();

        public StocklistClient(
                string pushServerUrl,
                string forceT,
                DemoForm form,
                LightstreamerUpdateDelegate lsUpdateDelegate,
                LightstreamerStatusChangedDelegate lsStatusChangeDelegate)
        {
            
            demoForm = form;
            updateDelegate = lsUpdateDelegate;
            statusChangeDelegate = lsStatusChangeDelegate;

            LightstreamerClient.setLoggerProvider(new Log4NetLoggerProviderWrapper());
            LightstreamerClient.setLoggerProvider(new ConsoleLoggerProvider(ConsoleLogLevel.DEBUG));

            client = new LightstreamerClient(pushServerUrl, "DEMO");

            client.connectionOptions.RetryDelay = 3500;
            switch (forceT)
            {
                case "websocket":
                    client.connectionOptions.ForcedTransport = "WS";
                    break;

                case "http":
                    client.connectionOptions.ForcedTransport = "HTTP";
                    break;

                case "polling":
                    client.connectionOptions.ForcedTransport = "HTTP-POLLING";
                    break;
                default:
                    break;
            }
            
        }


        private int phase = 0;

        private int reset = 0;

        public void Start(int ph)
        {
            if (ph != this.phase)
            {
                // ignore old calls
                return;
            }
            this.Start();
        }

        public void Start()
        {
            int ph = Interlocked.Increment(ref this.phase);
            Thread t = new Thread(new ThreadStart(delegate()
            {
                Execute(ph);
            }));
            t.Start();
        }

        public void Reset()
        {
            if ( Interlocked.CompareExchange(ref this.reset, 1, 0) == 0 )
            {
                Disconnect(this.phase);
            }
        }

        private void Execute(int ph) {
            if (ph != this.phase)
            {
                return;
            }
            ph = Interlocked.Increment(ref this.phase);
            this.Connect(ph);
            this.Subscribe();
        }

        public void StatusChanged(int ph, int cStatus, string status)
        {
            /* if (ph != this.phase)
                return;
                */
            demoForm.Invoke(statusChangeDelegate, new Object[] { cStatus, status });
            if ( cStatus == 0 )
            {
                if ( Interlocked.CompareExchange(ref this.reset, 0, 1) == 1 )
                {
                    int phs = Interlocked.Increment(ref this.phase);
                    Thread t = new Thread(new ThreadStart(delegate ()
                    {
                        Execute(phs);
                    }));
                    t.Start();
                }
            }
        }

        public void UpdateReceived(int ph, int itemPos, ItemUpdate update)
        {
            if (ph != this.phase)
                return;
            if ( demoForm.IsHandleCreated )
                demoForm.BeginInvoke(updateDelegate, new Object[] { itemPos, update });
        }

        public void subscribeChart(string item, ChartQuotes receiver)
        {
            try
            {
                if (charts.ContainsKey(receiver)) return; 

                // We subscribes it again because we don't want any
                // restriction to updates frequecy of the main subscription.

                Subscription s_stocks = new Subscription("MERGE");

                s_stocks.Fields = new string[3] { "last_price", "time", "stock_name" };
                s_stocks.Items = new string[1] { item };

                s_stocks.DataAdapter = "QUOTE_ADAPTER";
                s_stocks.RequestedSnapshot = "yes";
                s_stocks.RequestedMaxFrequency = "3.0";

                s_stocks.addListener(new ChartListener(">> ", receiver));

                charts.Add(receiver, s_stocks);

                client.subscribe(s_stocks);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while subscribing: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void stopSubscribeChart(ChartQuotes receiver)
        {
            try
            {
                Subscription s_stocks = charts[receiver];
                
                client.unsubscribe(s_stocks);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while subscribing: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void Connect(int ph) {
            bool connected = false;
            //this method will not exit until the openConnection returns without throwing an exception
            while (!connected) {
                demoForm.Invoke(statusChangeDelegate, new Object[] { 
                    StocklistConnectionListener.VOID,
                    "Connecting to Lightstreamer Server @ " + client.connectionDetails.ServerAddress
                });
                try {
                    if (ph != this.phase)
                        return;
                    ph = Interlocked.Increment(ref this.phase);
                    client.addListener(new StocklistConnectionListener(this, ph));
                    client.connect();
                    connected = true;
                } catch (Exception e) {
                    demoForm.Invoke(statusChangeDelegate, new Object[] {
                        StocklistConnectionListener.VOID, e.Message
                    });
                }
            
                if (!connected) {
                    Thread.Sleep(5000);
                }
                }
        }

        private void Disconnect(int ph)
        {
            demoForm.Invoke(statusChangeDelegate, new Object[] {
                    StocklistConnectionListener.VOID,
                    "Disconnecting to Lightstreamer Server @ " + client.connectionDetails.ServerAddress
                });
            try
            {                
                client.disconnect();
            }
            catch (Exception e)
            {
                demoForm.Invoke(statusChangeDelegate, new Object[] {
                        StocklistConnectionListener.VOID, e.Message
                    });
            }
        }

        private void Subscribe() {
            //this method will try just one subscription.
            //we know that when this method executes we should be already connected
            //If we're not or we disconnect while subscribing we don't have to do anything here as an
            //event will be (or was) sent to the ConnectionListener that will handle the case.
            //If we're connected but the subscription fails we can't do anything as the same subscription 
            //would fail again and again (btw this should never happen)

            try
            {
                subscription = new Subscription("MERGE", new string[30] { "item1", "item2", "item3", "item4", "item5", "item6", "item7", "item8", "item9", "item10", "item11", "item12", "item13", "item14", "item15", "item16", "item17", "item18", "item19", "item20", "item21", "item22", "item23", "item24", "item25", "item26", "item27", "item28", "item29", "item30" },
                    new string[12]{ "stock_name", "last_price", "time", "pct_change", "bid_quantity", "bid", "ask", "ask_quantity", "min", "max", "ref_price", "open_price"});
                subscription.DataAdapter = "QUOTE_ADAPTER";
                subscription.RequestedSnapshot = "yes";

                subscription.addListener(new StocklistSubscriptionListener(this, this.phase));
                client.subscribe(subscription);
            } catch (Exception e)
            {
                demoForm.Invoke(statusChangeDelegate, new Object[] {
                        StocklistConnectionListener.VOID, e.Message
                    });
            }
        }

        internal void ForceTransport(string selectedText)
        {
            if (selectedText.StartsWith("no"))
            {
                client.connectionOptions.ForcedTransport = null;
            } else
            {
                client.connectionOptions.ForcedTransport = selectedText;
            }
            
        }

        internal void MaxFrequency(int value)
        {
            switch (value)
            {
                case 0:
                    subscription.RequestedMaxFrequency = "unlimited";
                    break;
                case 1:
                    subscription.RequestedMaxFrequency = "5";
                    break;
                case 2:
                    subscription.RequestedMaxFrequency = "2";
                    break;
                case 3:
                    subscription.RequestedMaxFrequency = "1";
                    break;
                case 4:
                    subscription.RequestedMaxFrequency = "0.5";
                    break;
                case 5:
                    subscription.RequestedMaxFrequency = "0.3";
                    break;
                case 6:
                    subscription.RequestedMaxFrequency = "0.2";
                    break;
                case 7:
                    subscription.RequestedMaxFrequency = "0.1";
                    break;
                case 8:
                    subscription.RequestedMaxFrequency = "0.05";
                    break;
                case 9:
                    subscription.RequestedMaxFrequency = "0.01";
                    break;
                default:
                    subscription.RequestedMaxFrequency = "0.01";
                    break;
            }
            
            // client.subscribe(subscription);
        }
    }
}
